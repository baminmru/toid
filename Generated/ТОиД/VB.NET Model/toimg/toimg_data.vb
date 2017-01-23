
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace toimg


''' <summary>
'''Реализация строки раздела Картинки
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class toimg_data
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Раздел привязки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_link2part  as String


''' <summary>
'''Локальная переменная для поля Раздел2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_link1part  as String


''' <summary>
'''Локальная переменная для поля Оператор
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_oper  as System.Guid


''' <summary>
'''Локальная переменная для поля Идентификатор2
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_link1id  as String


''' <summary>
'''Локальная переменная для поля Идентификатор привязки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_link2id  as String


''' <summary>
'''Локальная переменная для поля Тип файла
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_filetype  as String


''' <summary>
'''Локальная переменная для поля Имя файла
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_fname  as String



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_link2part=   
            ' m_link1part=   
            ' m_oper=   
            ' m_link1id=   
            ' m_link2id=   
            ' m_filetype=   
            ' m_fname=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 7
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
                    Value = fname
                Case 2
                    Value = link2part
                Case 3
                    Value = link2id
                Case 4
                    Value = filetype
                Case 5
                    Value = link1part
                Case 6
                    Value = link1id
                Case 7
                    Value = oper
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
                    fname = value
                Case 2
                    link2part = value
                Case 3
                    link2id = value
                Case 4
                    filetype = value
                Case 5
                    link1part = value
                Case 6
                    link1id = value
                Case 7
                    oper = value
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
                    Return "fname"
                Case 2
                    Return "link2part"
                Case 3
                    Return "link2id"
                Case 4
                    Return "filetype"
                Case 5
                    Return "link1part"
                Case 6
                    Return "link1id"
                Case 7
                    Return "oper"
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
             dr("fname") =fname
             dr("link2part") =link2part
             dr("link2id") =link2id
             dr("filetype") =filetype
             dr("link1part") =link1part
             dr("link1id") =link1id
             if oper is nothing then
               dr("oper") =system.dbnull.value
               dr("oper_ID") =System.Guid.Empty
             else
               dr("oper") =oper.BRIEF
               dr("oper_ID") =oper.ID
             end if 
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
          nv.Add("fname", fname, dbtype.string)
          nv.Add("link2part", link2part, dbtype.string)
          nv.Add("link2id", link2id, dbtype.string)
          nv.Add("filetype", filetype, dbtype.string)
          nv.Add("link1part", link1part, dbtype.string)
          nv.Add("link1id", link1id, dbtype.string)
          if m_oper.Equals(System.Guid.Empty) then
            nv.Add("oper", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("oper", Application.Session.GetProvider.ID2Param(m_oper), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
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
          If reader.Table.Columns.Contains("fname") Then m_fname=reader.item("fname").ToString()
          If reader.Table.Columns.Contains("link2part") Then m_link2part=reader.item("link2part").ToString()
          If reader.Table.Columns.Contains("link2id") Then m_link2id=reader.item("link2id").ToString()
          If reader.Table.Columns.Contains("filetype") Then m_filetype=reader.item("filetype").ToString()
          If reader.Table.Columns.Contains("link1part") Then m_link1part=reader.item("link1part").ToString()
          If reader.Table.Columns.Contains("link1id") Then m_link1id=reader.item("link1id").ToString()
      If reader.Table.Columns.Contains("oper") Then
          if isdbnull(reader.item("oper")) then
            If reader.Table.Columns.Contains("oper") Then m_oper = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("oper") Then m_oper= New System.Guid(reader.item("oper").ToString())
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Имя файла
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property fname() As String
            Get
                LoadFromDatabase()
                fname = m_fname
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_fname = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Раздел привязки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property link2part() As String
            Get
                LoadFromDatabase()
                link2part = m_link2part
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_link2part = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Идентификатор привязки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property link2id() As String
            Get
                LoadFromDatabase()
                link2id = m_link2id
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_link2id = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип файла
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property filetype() As String
            Get
                LoadFromDatabase()
                filetype = m_filetype
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_filetype = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Раздел2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property link1part() As String
            Get
                LoadFromDatabase()
                link1part = m_link1part
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_link1part = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Идентификатор2
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property link1id() As String
            Get
                LoadFromDatabase()
                link1id = m_link1id
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_link1id = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Оператор
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property oper() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                oper = me.application.Findrowobject("to_oper",m_oper)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_oper = Value.id
                else
                   m_oper=System.Guid.Empty
                end if
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
            fname = node.Attributes.GetNamedItem("fname").Value
            link2part = node.Attributes.GetNamedItem("link2part").Value
            link2id = node.Attributes.GetNamedItem("link2id").Value
            filetype = node.Attributes.GetNamedItem("filetype").Value
            link1part = node.Attributes.GetNamedItem("link1part").Value
            link1id = node.Attributes.GetNamedItem("link1id").Value
            m_oper = new system.guid(node.Attributes.GetNamedItem("oper").Value)
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
          node.SetAttribute("fname", fname)  
          node.SetAttribute("link2part", link2part)  
          node.SetAttribute("link2id", link2id)  
          node.SetAttribute("filetype", filetype)  
          node.SetAttribute("link1part", link1part)  
          node.SetAttribute("link1id", link1id)  
          node.SetAttribute("oper", m_oper.tostring)  
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
