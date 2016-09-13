
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace totask


''' <summary>
'''Реализация строки раздела Измеренные значения
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_taskvalues
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Значение для проверки
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_checkvalue  as System.Guid


''' <summary>
'''Локальная переменная для поля Значение
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_theValue  as String


''' <summary>
'''Локальная переменная для поля Прмечание
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_theComment  as STRING



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_checkvalue=   
            ' m_theValue=   
            ' m_theComment=   
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
                    Value = checkvalue
                Case 2
                    Value = theValue
                Case 3
                    Value = theComment
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
                    checkvalue = value
                Case 2
                    theValue = value
                Case 3
                    theComment = value
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
                    Return "checkvalue"
                Case 2
                    Return "theValue"
                Case 3
                    Return "theComment"
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
             if checkvalue is nothing then
               dr("checkvalue") =system.dbnull.value
               dr("checkvalue_ID") =System.Guid.Empty
             else
               dr("checkvalue") =checkvalue.BRIEF
               dr("checkvalue_ID") =checkvalue.ID
             end if 
             dr("theValue") =theValue
             dr("theComment") =theComment
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
          if m_checkvalue.Equals(System.Guid.Empty) then
            nv.Add("checkvalue", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("checkvalue", Application.Session.GetProvider.ID2Param(m_checkvalue), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("theValue", theValue, dbtype.string)
          nv.Add("theComment", theComment, dbtype.string)
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
      If reader.Table.Columns.Contains("checkvalue") Then
          if isdbnull(reader.item("checkvalue")) then
            If reader.Table.Columns.Contains("checkvalue") Then m_checkvalue = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("checkvalue") Then m_checkvalue= New System.Guid(reader.item("checkvalue").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("theValue") Then m_theValue=reader.item("theValue").ToString()
          If reader.Table.Columns.Contains("theComment") Then m_theComment=reader.item("theComment").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Значение для проверки
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property checkvalue() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                checkvalue = me.application.Findrowobject("to_taskchecks",m_checkvalue)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_checkvalue = Value.id
                else
                   m_checkvalue=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Значение
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property theValue() As String
            Get
                LoadFromDatabase()
                theValue = m_theValue
                AccessTime = Now
            End Get
            Set(ByVal Value As String )
                LoadFromDatabase()
                m_theValue = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Прмечание
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property theComment() As STRING
            Get
                LoadFromDatabase()
                theComment = m_theComment
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_theComment = Value
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
            m_checkvalue = new system.guid(node.Attributes.GetNamedItem("checkvalue").Value)
            theValue = node.Attributes.GetNamedItem("theValue").Value
            theComment = node.Attributes.GetNamedItem("theComment").Value
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
          node.SetAttribute("checkvalue", m_checkvalue.tostring)  
          node.SetAttribute("theValue", theValue)  
          node.SetAttribute("theComment", theComment)  
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
