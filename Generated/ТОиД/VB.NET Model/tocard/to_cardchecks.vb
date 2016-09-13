
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace tocard


''' <summary>
'''Реализация строки раздела Проверки
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_cardchecks
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Узел
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_system  as System.Guid


''' <summary>
'''Локальная переменная для поля Показатель
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_check  as String


''' <summary>
'''Локальная переменная для поля Нормочас
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_normochas  as double


''' <summary>
'''Локальная переменная для поля Измерение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_ValueType  as System.Guid


''' <summary>
'''Локальная переменная для поля Нижняя граница ()=)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_lowvalue  as String


''' <summary>
'''Локальная переменная для поля Верхняя граница ((=)
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_hivalue  as String


''' <summary>
'''Локальная переменная для поля Примечание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_comment  as STRING


''' <summary>
'''Локальная переменная для поля Метка
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_tagid  as String


''' <summary>
'''Локальная переменная для поля Фото
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_image  as String


''' <summary>
'''Локальная переменная для поля Документация
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_doc  as String


''' <summary>
'''Локальная переменная для дочернего раздела Инструменты и материалы
''' </summary>
''' <remarks>
'''
''' </remarks>
        private m_to_carddevices As to_carddevices_col



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_the_system=   
            ' m_the_check=   
            ' m_normochas=   
            ' m_ValueType=   
            ' m_lowvalue=   
            ' m_hivalue=   
            ' m_the_comment=   
            ' m_tagid=   
            ' m_the_image=   
            ' m_the_doc=   
        End Sub



''' <summary>
'''Количество полей в строке раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides ReadOnly Property Count() As Long
        Get
           Count = 10
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
                    Value = the_system
                Case 2
                    Value = the_check
                Case 3
                    Value = normochas
                Case 4
                    Value = ValueType
                Case 5
                    Value = lowvalue
                Case 6
                    Value = hivalue
                Case 7
                    Value = the_comment
                Case 8
                    Value = tagid
                Case 9
                    Value = the_image
                Case 10
                    Value = the_doc
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
                    the_system = value
                Case 2
                    the_check = value
                Case 3
                    normochas = value
                Case 4
                    ValueType = value
                Case 5
                    lowvalue = value
                Case 6
                    hivalue = value
                Case 7
                    the_comment = value
                Case 8
                    tagid = value
                Case 9
                    the_image = value
                Case 10
                    the_doc = value
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
                    Return "the_system"
                Case 2
                    Return "the_check"
                Case 3
                    Return "normochas"
                Case 4
                    Return "ValueType"
                Case 5
                    Return "lowvalue"
                Case 6
                    Return "hivalue"
                Case 7
                    Return "the_comment"
                Case 8
                    Return "tagid"
                Case 9
                    Return "the_image"
                Case 10
                    Return "the_doc"
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
             if the_system is nothing then
               dr("the_system") =system.dbnull.value
               dr("the_system_ID") =System.Guid.Empty
             else
               dr("the_system") =the_system.BRIEF
               dr("the_system_ID") =the_system.ID
             end if 
             dr("the_check") =the_check
             dr("normochas") =normochas
             if ValueType is nothing then
               dr("ValueType") =system.dbnull.value
               dr("ValueType_ID") =System.Guid.Empty
             else
               dr("ValueType") =ValueType.BRIEF
               dr("ValueType_ID") =ValueType.ID
             end if 
             dr("lowvalue") =lowvalue
             dr("hivalue") =hivalue
             dr("the_comment") =the_comment
             dr("tagid") =tagid
             dr("the_image") =the_image
             dr("the_doc") =the_doc
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
            mFindInside = to_carddevices.FindObject(table,RowID)
            if not mFindInside is nothing then return mFindInside
            Return Nothing
        End Function



''' <summary>
'''Заполнить коллекцю именованных полей
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub Pack(ByVal nv As LATIR2.NamedValues)
          if m_the_system.Equals(System.Guid.Empty) then
            nv.Add("the_system", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("the_system", Application.Session.GetProvider.ID2Param(m_the_system), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("the_check", the_check, dbtype.string)
          nv.Add("normochas", normochas, dbtype.double)
          if m_ValueType.Equals(System.Guid.Empty) then
            nv.Add("ValueType", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("ValueType", Application.Session.GetProvider.ID2Param(m_ValueType), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("lowvalue", lowvalue, dbtype.string)
          nv.Add("hivalue", hivalue, dbtype.string)
          nv.Add("the_comment", the_comment, dbtype.string)
          nv.Add("tagid", tagid, dbtype.string)
          nv.Add("the_image", the_image, dbtype.string)
          nv.Add("the_doc", the_doc, dbtype.string)
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
      If reader.Table.Columns.Contains("the_system") Then
          if isdbnull(reader.item("the_system")) then
            If reader.Table.Columns.Contains("the_system") Then m_the_system = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("the_system") Then m_the_system= New System.Guid(reader.item("the_system").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("the_check") Then m_the_check=reader.item("the_check").ToString()
          If reader.Table.Columns.Contains("normochas") Then m_normochas=reader.item("normochas")
      If reader.Table.Columns.Contains("ValueType") Then
          if isdbnull(reader.item("ValueType")) then
            If reader.Table.Columns.Contains("ValueType") Then m_ValueType = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("ValueType") Then m_ValueType= New System.Guid(reader.item("ValueType").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("lowvalue") Then m_lowvalue=reader.item("lowvalue").ToString()
          If reader.Table.Columns.Contains("hivalue") Then m_hivalue=reader.item("hivalue").ToString()
          If reader.Table.Columns.Contains("the_comment") Then m_the_comment=reader.item("the_comment").ToString()
          If reader.Table.Columns.Contains("tagid") Then m_tagid=reader.item("tagid").ToString()
          If reader.Table.Columns.Contains("the_image") Then m_the_image=reader.item("the_image").ToString()
          If reader.Table.Columns.Contains("the_doc") Then m_the_doc=reader.item("the_doc").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Узел
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_system() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                the_system = me.application.Findrowobject("tod_system",m_the_system)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_the_system = Value.id
                else
                   m_the_system=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Показатель
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_check() As String
            Get
                LoadFromDatabase()
                the_check = m_the_check
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_the_check = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Нормочас
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property normochas() As double
            Get
                LoadFromDatabase()
                normochas = m_normochas
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_normochas = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Измерение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property ValueType() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                ValueType = me.application.Findrowobject("tod_valtype",m_ValueType)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_ValueType = Value.id
                else
                   m_ValueType=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Нижняя граница ()=)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property lowvalue() As String
            Get
                LoadFromDatabase()
                lowvalue = m_lowvalue
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_lowvalue = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Верхняя граница ((=)
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property hivalue() As String
            Get
                LoadFromDatabase()
                hivalue = m_hivalue
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_hivalue = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Примечание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_comment() As STRING
            Get
                LoadFromDatabase()
                the_comment = m_the_comment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_the_comment = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Метка
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property tagid() As String
            Get
                LoadFromDatabase()
                tagid = m_tagid
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_tagid = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Фото
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_image() As String
            Get
                LoadFromDatabase()
                the_image = m_the_image
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_the_image = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Документация
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_doc() As String
            Get
                LoadFromDatabase()
                the_doc = m_the_doc
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_the_doc = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к дочернему разделу Инструменты и материалы
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public readonly Property to_carddevices() As to_carddevices_col
            Get
                if  m_to_carddevices is nothing then
                  m_to_carddevices = new to_carddevices_col
                  m_to_carddevices.Parent = me
                  m_to_carddevices.Application = me.Application
                  m_to_carddevices.Refresh
                end if
                to_carddevices = m_to_carddevices
                AccessTime = Now
            End Get
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
            m_the_system = new system.guid(node.Attributes.GetNamedItem("the_system").Value)
            the_check = node.Attributes.GetNamedItem("the_check").Value
            normochas = node.Attributes.GetNamedItem("normochas").Value
            m_ValueType = new system.guid(node.Attributes.GetNamedItem("ValueType").Value)
            lowvalue = node.Attributes.GetNamedItem("lowvalue").Value
            hivalue = node.Attributes.GetNamedItem("hivalue").Value
            the_comment = node.Attributes.GetNamedItem("the_comment").Value
            tagid = node.Attributes.GetNamedItem("tagid").Value
            the_image = node.Attributes.GetNamedItem("the_image").Value
            the_doc = node.Attributes.GetNamedItem("the_doc").Value
            e_list = node.SelectNodes("to_carddevices_COL")
            to_carddevices.XMLLoad(e_list,LoadMode)
             Changed = true
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End sub
        Public Overrides Sub Dispose()
            to_carddevices.Dispose
        End Sub


''' <summary>
'''Записать данные раздела в XML файл
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides sub XLMPack(ByVal node As System.Xml.XmlElement, ByVal Xdom As System.Xml.XmlDocument)
           try 
          node.SetAttribute("the_system", m_the_system.tostring)  
          node.SetAttribute("the_check", the_check)  
          node.SetAttribute("normochas", normochas)  
          node.SetAttribute("ValueType", m_ValueType.tostring)  
          node.SetAttribute("lowvalue", lowvalue)  
          node.SetAttribute("hivalue", hivalue)  
          node.SetAttribute("the_comment", the_comment)  
          node.SetAttribute("tagid", tagid)  
          node.SetAttribute("the_image", the_image)  
          node.SetAttribute("the_doc", the_doc)  
            to_carddevices.XMLSave(node,xdom)
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
            to_carddevices.BatchUpdate
End Sub


''' <summary>
'''Количество дочерних разделов
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides ReadOnly Property CountOfParts() As Long
            Get
                CountOfParts = 1
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
         Case 1
            return to_carddevices
            End Select
            return nothing
        End Function
    End Class
End Namespace
