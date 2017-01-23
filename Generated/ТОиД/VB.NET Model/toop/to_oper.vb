
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
'''Локальная переменная для поля Табельный номер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_tnum  as String


''' <summary>
'''Локальная переменная для поля Роль
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_therole  as System.Guid


''' <summary>
'''Локальная переменная для поля Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_surname  as String


''' <summary>
'''Локальная переменная для поля Логин
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_login  as String


''' <summary>
'''Локальная переменная для поля Имя
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_familyname  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_tnum=   
            ' m_therole=   
            ' m_surname=   
            ' m_login=   
            ' m_name=   
            ' m_familyname=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 6
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
                    Value = familyname
                Case 2
                    Value = name
                Case 3
                    Value = surname
                Case 4
                    Value = tnum
                Case 5
                    Value = therole
                Case 6
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
                    familyname = value
                Case 2
                    name = value
                Case 3
                    surname = value
                Case 4
                    tnum = value
                Case 5
                    therole = value
                Case 6
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
                    Return "familyname"
                Case 2
                    Return "name"
                Case 3
                    Return "surname"
                Case 4
                    Return "tnum"
                Case 5
                    Return "therole"
                Case 6
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
             dr("familyname") =familyname
             dr("name") =name
             dr("surname") =surname
             dr("tnum") =tnum
             if therole is nothing then
               dr("therole") =system.dbnull.value
               dr("therole_ID") =System.Guid.Empty
             else
               dr("therole") =therole.BRIEF
               dr("therole_ID") =therole.ID
             end if 
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
          nv.Add("familyname", familyname, dbtype.string)
          nv.Add("name", name, dbtype.string)
          nv.Add("surname", surname, dbtype.string)
          nv.Add("tnum", tnum, dbtype.string)
          if m_therole.Equals(System.Guid.Empty) then
            nv.Add("therole", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("therole", Application.Session.GetProvider.ID2Param(m_therole), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
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
          If reader.Table.Columns.Contains("familyname") Then m_familyname=reader.item("familyname").ToString()
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
          If reader.Table.Columns.Contains("surname") Then m_surname=reader.item("surname").ToString()
          If reader.Table.Columns.Contains("tnum") Then m_tnum=reader.item("tnum").ToString()
      If reader.Table.Columns.Contains("therole") Then
          if isdbnull(reader.item("therole")) then
            If reader.Table.Columns.Contains("therole") Then m_therole = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("therole") Then m_therole= New System.Guid(reader.item("therole").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("login") Then m_login=reader.item("login").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Фамилия
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property familyname() As String
            Get
                LoadFromDatabase()
                familyname = m_familyname
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_familyname = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Имя
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
'''Доступ к полю Отчество
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property surname() As String
            Get
                LoadFromDatabase()
                surname = m_surname
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_surname = Value
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
'''Доступ к полю Роль
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property therole() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                therole = me.application.Findrowobject("tod_oprole",m_therole)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_therole = Value.id
                else
                   m_therole=System.Guid.Empty
                end if
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
            familyname = node.Attributes.GetNamedItem("familyname").Value
            name = node.Attributes.GetNamedItem("name").Value
            surname = node.Attributes.GetNamedItem("surname").Value
            tnum = node.Attributes.GetNamedItem("tnum").Value
            m_therole = new system.guid(node.Attributes.GetNamedItem("therole").Value)
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
          node.SetAttribute("familyname", familyname)  
          node.SetAttribute("name", name)  
          node.SetAttribute("surname", surname)  
          node.SetAttribute("tnum", tnum)  
          node.SetAttribute("therole", m_therole.tostring)  
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
