
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace tod


''' <summary>
'''Реализация строки раздела Станки
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class tod_st
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Модель станка
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_model  as System.Guid


''' <summary>
'''Локальная переменная для поля Инвентарный номер
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_invn  as String


''' <summary>
'''Локальная переменная для поля Название
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_name  as String


''' <summary>
'''Локальная переменная для поля Цех
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_thebuilding  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_the_model=   
            ' m_invn=   
            ' m_name=   
            ' m_thebuilding=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 4
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
                    Value = invn
                Case 2
                    Value = name
                Case 3
                    Value = the_model
                Case 4
                    Value = thebuilding
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
                    invn = value
                Case 2
                    name = value
                Case 3
                    the_model = value
                Case 4
                    thebuilding = value
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
                    Return "invn"
                Case 2
                    Return "name"
                Case 3
                    Return "the_model"
                Case 4
                    Return "thebuilding"
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
             dr("invn") =invn
             dr("name") =name
             if the_model is nothing then
               dr("the_model") =system.dbnull.value
               dr("the_model_ID") =System.Guid.Empty
             else
               dr("the_model") =the_model.BRIEF
               dr("the_model_ID") =the_model.ID
             end if 
             if thebuilding is nothing then
               dr("thebuilding") =system.dbnull.value
               dr("thebuilding_ID") =System.Guid.Empty
             else
               dr("thebuilding") =thebuilding.BRIEF
               dr("thebuilding_ID") =thebuilding.ID
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
          nv.Add("invn", invn, dbtype.string)
          nv.Add("name", name, dbtype.string)
          if m_the_model.Equals(System.Guid.Empty) then
            nv.Add("the_model", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("the_model", Application.Session.GetProvider.ID2Param(m_the_model), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_thebuilding.Equals(System.Guid.Empty) then
            nv.Add("thebuilding", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("thebuilding", Application.Session.GetProvider.ID2Param(m_thebuilding), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
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
          If reader.Table.Columns.Contains("invn") Then m_invn=reader.item("invn").ToString()
          If reader.Table.Columns.Contains("name") Then m_name=reader.item("name").ToString()
      If reader.Table.Columns.Contains("the_model") Then
          if isdbnull(reader.item("the_model")) then
            If reader.Table.Columns.Contains("the_model") Then m_the_model = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("the_model") Then m_the_model= New System.Guid(reader.item("the_model").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("thebuilding") Then
          if isdbnull(reader.item("thebuilding")) then
            If reader.Table.Columns.Contains("thebuilding") Then m_thebuilding = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("thebuilding") Then m_thebuilding= New System.Guid(reader.item("thebuilding").ToString())
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Инвентарный номер
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property invn() As String
            Get
                LoadFromDatabase()
                invn = m_invn
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_invn = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Название
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
'''Доступ к полю Модель станка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_model() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                the_model = me.application.Findrowobject("tod_model",m_the_model)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_the_model = Value.id
                else
                   m_the_model=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Цех
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property thebuilding() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                thebuilding = me.application.Findrowobject("tod_building",m_thebuilding)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_thebuilding = Value.id
                else
                   m_thebuilding=System.Guid.Empty
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
            invn = node.Attributes.GetNamedItem("invn").Value
            name = node.Attributes.GetNamedItem("name").Value
            m_the_model = new system.guid(node.Attributes.GetNamedItem("the_model").Value)
            m_thebuilding = new system.guid(node.Attributes.GetNamedItem("thebuilding").Value)
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
          node.SetAttribute("invn", invn)  
          node.SetAttribute("name", name)  
          node.SetAttribute("the_model", m_the_model.tostring)  
          node.SetAttribute("thebuilding", m_thebuilding.tostring)  
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
