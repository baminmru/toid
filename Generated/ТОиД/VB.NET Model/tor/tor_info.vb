
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace tor


''' <summary>
'''Реализация строки раздела Записи о рабочих станциях
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class tor_info
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Дата клиент
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_clientdata  as DATE


''' <summary>
'''Локальная переменная для поля Название станции
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Дата сервер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_serverdata  as DATE



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_clientdata=   
            ' m_name=   
            ' m_serverdata=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 3
        End Get
    End Property



''' <summary>
'''Получить \Задать поле по номеру 
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Property Value(ByVal Index As Object) As Object
    Get
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                    Value = ID
                Case 1
                    Value = name
                Case 2
                    Value = serverdata
                Case 3
                    Value = clientdata
            End Select
        else
        try
          Value = Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Get, Nothing)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
              Value=nothing
          end try
        End If
    End Get
    Set(ByVal value As Object)
    If Microsoft.VisualBasic.IsNumeric(Index) Then
        Dim l As Long
        l = CLng(Index)
        Select Case l
            Case 0
                 ID=value
                Case 1
                    name = value
                Case 2
                    serverdata = value
                Case 3
                    clientdata = value
        End Select
     Else
        Try
            Try
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Set, value)
            Catch ex As Exception
                Microsoft.VisualBasic.CallByName(Me, Index.ToString(), Microsoft.VisualBasic.CallType.Let, value)
            End Try
        Catch ex As Exception
        End Try
     End If
  End Set

End Property



''' <summary>
'''Название поля по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Function FieldNameByID(ByVal Index As long) As String
        If Microsoft.VisualBasic.IsNumeric(Index) Then
            Dim l As Long
            l = CLng(Index)
            Select Case l
                Case 0
                   Return "ID"
                Case 1
                    Return "name"
                Case 2
                    Return "serverdata"
                Case 3
                    Return "clientdata"
                Case else
                return "" 
            End Select
        End If
        return "" 
End Function



''' <summary>
'''Заполнить строку таблицы данными из полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub FillDataTable(ByRef DestDataTable As System.Data.DataTable)
            Dim dr As  DataRow
            dr = destdatatable.NewRow
            try
            dr("ID") =ID
            dr("Brief") =Brief
             dr("name") =name
             dr("serverdata") =serverdata
             dr("clientdata") =clientdata
            DestDataTable.Rows.Add (dr)
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub



''' <summary>
'''Найти строку в коллекции по идентификатору
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function FindInside(ByVal Table As String, ByVal RowID As String) As LATIR2.Document.DocRow_Base
            dim mFindInside As LATIR2.Document.DocRow_Base = Nothing
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          nv.Add("name", name, dbtype.string)
          if serverdata=System.DateTime.MinValue then
            nv.Add("serverdata", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("serverdata", serverdata, dbtype.DATETIME)
          end if 
          if clientdata=System.DateTime.MinValue then
            nv.Add("clientdata", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("clientdata", clientdata, dbtype.DATETIME)
          end if 
            nv.Add(PartName() & "id", Application.Session.GetProvider.ID2Param(ID),  Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
        End Sub




''' <summary>
'''Заполнить поля из именованной коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Unpack(ByVal reader As System.Data.DataRow)
            try  
            If IsDBNull(reader.item("SecurityStyleID")) Then
                SecureStyleID = System.guid.Empty
            Else
                SecureStyleID = new Guid(reader.item("SecurityStyleID").ToString())
            End If

            RowRetrived = True
            RetriveTime = Now
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
      If reader.Table.Columns.Contains("serverdata") Then
          if isdbnull(reader.item("serverdata")) then
            If reader.Table.Columns.Contains("serverdata") Then m_serverdata = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("serverdata") Then m_serverdata=reader.item("serverdata")
          end if 
      end if 
      If reader.Table.Columns.Contains("clientdata") Then
          if isdbnull(reader.item("clientdata")) then
            If reader.Table.Columns.Contains("clientdata") Then m_clientdata = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("clientdata") Then m_clientdata=reader.item("clientdata")
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Название станции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property name() As String
            Get
                LoadFromDatabase()
                name = m_name
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_name = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата сервер
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property serverdata() As DATE
            Get
                LoadFromDatabase()
                serverdata = m_serverdata
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_serverdata = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата клиент
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property clientdata() As DATE
            Get
                LoadFromDatabase()
                clientdata = m_clientdata
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_clientdata = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Заполнить поля данными из XML
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XMLUnpack(ByVal node As System.Xml.XmlNode, Optional ByVal LoadMode As Integer = 0)
          Dim e_list As XmlNodeList
          try 
            name = node.Attributes.GetNamedItem("name").Value
            m_serverdata = System.DateTime.MinValue
            serverdata = m_serverdata.AddTicks( node.Attributes.GetNamedItem("serverdata").Value)
            m_clientdata = System.DateTime.MinValue
            clientdata = m_clientdata.AddTicks( node.Attributes.GetNamedItem("clientdata").Value)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("name", name)  
         ' if serverdata = System.DateTime.MinValue then serverdata=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("serverdata", serverdata.Ticks)  
         ' if clientdata = System.DateTime.MinValue then clientdata=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("clientdata", clientdata.Ticks)  
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub


''' <summary>
'''Записать изменения в базу данных
''' </summary>
''' <remarks>
'''
''' </remarks>
Public Overrides Sub BatchUpdate()
  If Deleted Then
    Delete
    Exit Sub
  End If
  If Changed Then Save
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 0
            End Get
        End Property



''' <summary>
'''Доступ к дочернему разделу по номеру
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function GetDocCollection_Base(ByVal Index As Long) As LATIR2.Document.DocCollection_Base
            Select Case Index
            End Select
            return nothing
        End Function
    End Class
End Namespace
