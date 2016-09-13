Imports System
Imports System.IO
Imports System.Runtime.InteropServices.WindowsRuntime
Imports System.Threading.Tasks
Imports Windows.Graphics.Imaging
Imports Windows.Storage
Imports Windows.Storage.Streams
Imports Windows.UI.Xaml.Media.Imaging
Imports NdefLibrary.Ndef



''' <summary>
''' Extended MIME / Image record for the WinRT APIs that integrates with
''' the platform's image handling to support convenient conversion to and
''' from various formats (WriteableBitmap, PNG, JPEG, etc.)
''' </summary>
''' <remarks>
''' If you are working on a platform that supports the WinRT APIs and you
''' need to interact with the image data, you can use this derived class 
''' instead of the base class.
''' 
''' It adds several convenient methods to directly construct this record
''' from a WriteableBitmap, from a stream containing image data or from
''' a file. If loading from a stream / file, the class will automatically
''' determine the correct MIME type and set it to the record.
''' 
''' When loading & parsing an existing record, just construct this class
''' based on a generic NdefRecord. You can then use convenient getter methods
''' to retrieve a WriteableBitmap from the image data payload, no matter
''' which encoding the image data is actually using.
''' </remarks>
Public Class NdefMimeImageRecord
        Inherits NdefMimeImageRecordBase
        
        ''' <summary>
        ''' Create a MIME / Image record based on the record passed
        ''' through the argument.
        ''' </summary>
        ''' <remarks>
        ''' The original record has to be a MIME / Image Record as well.
        ''' </remarks>
        ''' <param name="other">Record to copy into this Image record.</param>
        ''' <exception cref="NdefException">Thrown if attempting to create an Image record
        ''' based on an incompatible record type.</exception>
        Public Sub New(ByVal other As NdefRecord)
            MyBase.New(other)
            
        End Sub
        
        Protected Sub New()
            MyBase.New
            
        End Sub
        #Region "Public factory constructor methods"
        
        Public Shared Async Function CreateFromBitmap(ByVal bmp As WriteableBitmap, ByVal mimeType As ImageMimeType, Optional ByVal dpi As Double = 96) As Task(Of NdefMimeImageRecord)
            Dim imgRecord = New NdefMimeImageRecord
        Await imgRecord.SetImage(bmp, mimeType, dpi)
        Return imgRecord
        End Function
        
        ''' <summary>
        ''' Construct a new MIME / Image record based on a file.
        ''' </summary>
        ''' <param name="file">Reference to a file that will be opened and parsed
        ''' by this class, to load its contents into the Payload of this record
        ''' and set the MIME type correctly depending on the file contents.</param>
        ''' <returns>A newly constructed MIME / Image record with the file data
        ''' as payload and the MIME type automatically determined based on the 
        ''' image data.</returns>
        Public Shared Async Function CreateFromFile(ByVal file As StorageFile) As Task(Of NdefMimeImageRecord)
            Dim imgRecord = New NdefMimeImageRecord
        Await imgRecord.LoadFile(file)
        Return imgRecord
        End Function
        
        ''' <summary>
        ''' Construct a new MIME / Image record based on a stream.
        ''' </summary>
        ''' <param name="imgStream">Reference to a stream containing image data
        ''' (encoded for example as a PNG or JPEG). The stream will be parsed
        ''' by this class, to load its contents into the Payload of this record
        ''' and set the MIME type correctly depending on the stream contents.</param>
        ''' <returns>A newly constructed MIME / Image record with the stream data
        ''' as payload and the MIME type automatically determined based on the 
        ''' image data.</returns>
        Public Shared Async Function CreateFromStream(ByVal imgStream As IRandomAccessStream) As Task(Of NdefMimeImageRecord)
            Dim imgRecord = New NdefMimeImageRecord
        Await imgRecord.LoadStream(imgStream)
        Return imgRecord
        End Function
        #End Region
        #Region "Set and modify the image data"
        
        Public Async Function SetImage(ByVal bmp As WriteableBitmap, ByVal mimeType As ImageMimeType, Optional ByVal dpi As Double = 96) As Task
            Dim encoderId = NdefMimeImageRecord.GetBitmapEncoderIdForMimeType(mimeType)
            Dim pixels() As Byte
            Dim stream = bmp.PixelBuffer.AsStream
            pixels = New Byte((CType(stream.Length,UInteger)) - 1) {}
        Await stream.ReadAsync(pixels, 0, pixels.Length)
        Dim imgStream = New MemoryStream
            Dim raImgStream = imgStream.AsRandomAccessStream
            Dim encoder = Await BitmapEncoder.CreateAsync(encoderId, raImgStream)
            encoder.SetPixelData(BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied, CType(bmp.PixelWidth,UInteger), CType(bmp.PixelHeight,UInteger), dpi, dpi, pixels)
        Await encoder.FlushAsync
        Await raImgStream.FlushAsync
        Payload = imgStream.ToArray
            Type = ImageMimeTypes(mimeType)
        End Function
        
        ''' <summary>
        ''' Set an image to this class by specifying an input file that has to be one of the 
        ''' supported MIME types (e.g., a JPEG or PNG file).
        ''' </summary>
        ''' <remarks>
        ''' Specify the reference to a file that is one of the supported MIME types - e.g.,
        ''' a JPEG or PNG image. The file contents are set as the payload of this record.
        ''' This method will try to find out the MIME type of the referenced
        ''' file automatically and adapt the type of the NDEF record accordingly.
        ''' </remarks>
        ''' <returns>Task to await completion of the asynchronous image loading / parsing.</returns>
        Public Async Function LoadFile(ByVal file As StorageFile) As Task
            If (file Is Nothing) Then
                Throw New ArgumentNullException("file")
            End If
            
            Dim fileStream = Await file.OpenAsync(FileAccessMode.Read)
        Await LoadStream(fileStream)
    End Function
        
        ''' <summary>
        ''' Set an image to this class by specifying an input stream that contains image data
        ''' in one of the supported MIME types (e.g., JPEG or PNG file contents).
        ''' </summary>
        ''' <remarks>
        ''' The stream has to contain one of the supported MIME types - e.g.,
        ''' a JPEG or PNG image. The stream contents are set as the payload of this record.
        ''' This method will try to find out the MIME type of the referenced
        ''' stream contents automatically and adapt the type of the NDEF record accordingly.
        ''' </remarks>
        ''' <returns>Task to await completion of the asynchronous image loading / parsing.</returns>
        Public Async Function LoadStream(ByVal imgStream As IRandomAccessStream) As Task
            If (imgStream Is Nothing) Then
                Throw New ArgumentNullException("imgStream")
            End If
            
            Dim decoder = Await BitmapDecoder.CreateAsync(imgStream)
            Dim fileCodecId = decoder.DecoderInformation.CodecId
            Payload = New Byte((imgStream.Size) - 1) {}
        Await imgStream.ReadAsync(Payload.AsBuffer, CType(imgStream.Size, UInteger), InputStreamOptions.None)
        Type = ImageMimeTypes(NdefMimeImageRecord.GetMimeTypeForBitmapDecoderId(fileCodecId))
        End Function
        
        ''' <summary>
        ''' Utility method to determine & update the MIME type of the record according
        ''' to the current payload.
        ''' </summary>
        ''' <remarks>
        ''' Mostly for internal use, but can also be used externally if you
        ''' set the Payload directly and want the class to adapt its MIME type based
        ''' on the new Payload contents.
        ''' </remarks>
        ''' <returns>Task to await completion of determining the payload MIME type.</returns>
        Public Async Function DetermineMimeTypeFromPayload() As Task
            If (Payload Is Nothing) Then
                Return
            End If
            
            ' Determine image type of payload
            Dim payloadStream = NdefMimeImageRecord.ConvertArrayToStream(Payload)
            Dim decoder = Await BitmapDecoder.CreateAsync(payloadStream)
            Dim fileCodecId = decoder.DecoderInformation.CodecId
            Type = ImageMimeTypes(NdefMimeImageRecord.GetMimeTypeForBitmapDecoderId(fileCodecId))
        End Function
        #End Region
        #Region "Retrieve the image"
        
        Public Async Function GetImageAsBitmap() As Task(Of WriteableBitmap)
            If (Payload Is Nothing) Then
                Return Nothing
            End If
            
            ' Get stream from the payload
            Dim payloadStream = NdefMimeImageRecord.ConvertArrayToStream(Payload)
            ' Load the stream into the writable bitmap
            ' As we don't know the dimensions of the image yet,
            ' create the Writeable bitmap with a size of 1/1.
            ' This will be set according to the source when loading it.
            ' (as demonstrated in Microsoft examples)
            Dim bmp = New WriteableBitmap(1, 1)
        Await bmp.SetSourceAsync(payloadStream)
        Return bmp
        End Function
        #End Region
        #Region "Utility methods"
        
        Public Shared Function GetBitmapEncoderIdForMimeType(ByVal mimeType As ImageMimeType) As Guid
            Select Case (mimeType)
                Case ImageMimeType.Png
                    Return BitmapEncoder.PngEncoderId
                Case ImageMimeType.Jpg, ImageMimeType.Jpeg
                    Return BitmapEncoder.JpegEncoderId
                Case ImageMimeType.JpegXr
                    Return BitmapEncoder.JpegXREncoderId
                Case ImageMimeType.Bmp
                    Return BitmapEncoder.BmpEncoderId
                Case ImageMimeType.Gif
                    Return BitmapEncoder.GifEncoderId
                Case ImageMimeType.Tiff
                    Return BitmapEncoder.TiffEncoderId
                Case Else
                    Throw New ArgumentOutOfRangeException
            End Select
            
        End Function
        
        ''' <summary>
        ''' Utility method to convert the platform's Bitmap Decoder codec ID / GUID to the
        ''' MIME type enumeration used by this class.
        ''' </summary>
        ''' <param name="codecId">Bitmap decoder codec ID / GUID.</param>
        ''' <returns>MIME type enumeration that can be used by this class.</returns>
        Public Shared Function GetMimeTypeForBitmapDecoderId(ByVal codecId As Guid) As ImageMimeType
            If codecId.Equals(BitmapDecoder.PngDecoderId) Then
                Return ImageMimeType.Png
            End If
            
            If codecId.Equals(BitmapDecoder.JpegDecoderId) Then
                Return ImageMimeType.Jpeg
            End If
            
            If codecId.Equals(BitmapDecoder.GifDecoderId) Then
                Return ImageMimeType.Gif
            End If
            
            If codecId.Equals(BitmapDecoder.BmpDecoderId) Then
                Return ImageMimeType.Png
            End If
            
            If codecId.Equals(BitmapDecoder.TiffDecoderId) Then
                Return ImageMimeType.Tiff
            End If
            
            If codecId.Equals(BitmapDecoder.JpegXRDecoderId) Then
                Return ImageMimeType.JpegXr
            End If
            
            Throw New ArgumentOutOfRangeException
        End Function
        
        ''' <summary>
        ''' Utility method to access a byte array as a random access stream.
        ''' </summary>
        ''' <param name="arr">Byte array that you would like to access as a stream.</param>
        ''' <returns>Random access stream based on the specified byte array.</returns>
        Friend Shared Function ConvertArrayToStream(ByVal arr() As Byte) As IRandomAccessStream
            Dim stream = New MemoryStream(arr)
            Return stream.AsRandomAccessStream
        End Function
        #End Region
    End Class
