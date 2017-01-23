
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace tosched


''' <summary>
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_schedinfo
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля С
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_dfrom  as DATE


''' <summary>
'''Локальная переменная для поля По
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_dto  as DATE



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_dfrom=   
            ' m_dto=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 2
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
                    Value = dfrom
                Case 2
                    Value = dto
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
                    dfrom = value
                Case 2
                    dto = value
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
                    Return "dfrom"
                Case 2
                    Return "dto"
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
             dr("dfrom") =dfrom
             dr("dto") =dto
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
          if dfrom=System.DateTime.MinValue then
            nv.Add("dfrom", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("dfrom", dfrom, dbtype.DATETIME)
          end if 
          if dto=System.DateTime.MinValue then
            nv.Add("dto", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("dto", dto, dbtype.DATETIME)
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
      If reader.Table.Columns.Contains("dfrom") Then
          if isdbnull(reader.item("dfrom")) then
            If reader.Table.Columns.Contains("dfrom") Then m_dfrom = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("dfrom") Then m_dfrom=reader.item("dfrom")
          end if 
      end if 
      If reader.Table.Columns.Contains("dto") Then
          if isdbnull(reader.item("dto")) then
            If reader.Table.Columns.Contains("dto") Then m_dto = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("dto") Then m_dto=reader.item("dto")
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю С
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property dfrom() As DATE
            Get
                LoadFromDatabase()
                dfrom = m_dfrom
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_dfrom = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю По
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property dto() As DATE
            Get
                LoadFromDatabase()
                dto = m_dto
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_dto = Value
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
            m_dfrom = System.DateTime.MinValue
            dfrom = m_dfrom.AddTicks( node.Attributes.GetNamedItem("dfrom").Value)
            m_dto = System.DateTime.MinValue
            dto = m_dto.AddTicks( node.Attributes.GetNamedItem("dto").Value)
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
         ' if dfrom = System.DateTime.MinValue then dfrom=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("dfrom", dfrom.Ticks)  
         ' if dto = System.DateTime.MinValue then dto=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("dto", dto.Ticks)  
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
