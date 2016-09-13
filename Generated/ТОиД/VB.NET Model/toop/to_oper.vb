
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace toop


''' <summary>
'''Реализация строки раздела Оператор
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_oper
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Имя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_Name  as String


''' <summary>
'''Локальная переменная для поля Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_FamilyName  as String


''' <summary>
'''Локальная переменная для поля Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_SurName  as String


''' <summary>
'''Локальная переменная для поля Табельный номер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_tnum  as String


''' <summary>
'''Локальная переменная для поля Логин
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_login  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_Name=   
            ' m_FamilyName=   
            ' m_SurName=   
            ' m_tnum=   
            ' m_login=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 5
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
                    Value = Name
                Case 2
                    Value = FamilyName
                Case 3
                    Value = SurName
                Case 4
                    Value = tnum
                Case 5
                    Value = login
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
                    Name = value
                Case 2
                    FamilyName = value
                Case 3
                    SurName = value
                Case 4
                    tnum = value
                Case 5
                    login = value
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
                    Return "Name"
                Case 2
                    Return "FamilyName"
                Case 3
                    Return "SurName"
                Case 4
                    Return "tnum"
                Case 5
                    Return "login"
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
             dr("Name") =Name
             dr("FamilyName") =FamilyName
             dr("SurName") =SurName
             dr("tnum") =tnum
             dr("login") =login
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
          nv.Add("Name", Name, dbtype.string)
          nv.Add("FamilyName", FamilyName, dbtype.string)
          nv.Add("SurName", SurName, dbtype.string)
          nv.Add("tnum", tnum, dbtype.string)
          nv.Add("login", login, dbtype.string)
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
          If reader.Table.Columns.Contains("Name") Then m_Name=reader.item("Name").ToString()
          If reader.Table.Columns.Contains("FamilyName") Then m_FamilyName=reader.item("FamilyName").ToString()
          If reader.Table.Columns.Contains("SurName") Then m_SurName=reader.item("SurName").ToString()
          If reader.Table.Columns.Contains("tnum") Then m_tnum=reader.item("tnum").ToString()
          If reader.Table.Columns.Contains("login") Then m_login=reader.item("login").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Имя
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property Name() As String
            Get
                LoadFromDatabase()
                Name = m_Name
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_Name = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property FamilyName() As String
            Get
                LoadFromDatabase()
                FamilyName = m_FamilyName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_FamilyName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property SurName() As String
            Get
                LoadFromDatabase()
                SurName = m_SurName
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_SurName = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Табельный номер
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property tnum() As String
            Get
                LoadFromDatabase()
                tnum = m_tnum
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_tnum = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Логин
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property login() As String
            Get
                LoadFromDatabase()
                login = m_login
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_login = Value
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
            Name = node.Attributes.GetNamedItem("Name").Value
            FamilyName = node.Attributes.GetNamedItem("FamilyName").Value
            SurName = node.Attributes.GetNamedItem("SurName").Value
            tnum = node.Attributes.GetNamedItem("tnum").Value
            login = node.Attributes.GetNamedItem("login").Value
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
          node.SetAttribute("Name", Name)  
          node.SetAttribute("FamilyName", FamilyName)  
          node.SetAttribute("SurName", SurName)  
          node.SetAttribute("tnum", tnum)  
          node.SetAttribute("login", login)  
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
