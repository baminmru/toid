
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace totrn


''' <summary>
'''Реализация строки раздела Описание тренда
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class totrn_def
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Станок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_themachine  as System.Guid


''' <summary>
'''Локальная переменная для поля Верхняя граница
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_topvalue  as double


''' <summary>
'''Локальная переменная для поля Тип тренда
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_trandtype  as System.Guid


''' <summary>
'''Локальная переменная для поля Нижняя граница
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_bottomval  as double



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_themachine=   
            ' m_topvalue=   
            ' m_trandtype=   
            ' m_bottomval=   
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
                    Value = themachine
                Case 2
                    Value = trandtype
                Case 3
                    Value = topvalue
                Case 4
                    Value = bottomval
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
                    themachine = value
                Case 2
                    trandtype = value
                Case 3
                    topvalue = value
                Case 4
                    bottomval = value
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
                    Return "themachine"
                Case 2
                    Return "trandtype"
                Case 3
                    Return "topvalue"
                Case 4
                    Return "bottomval"
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
             if themachine is nothing then
               dr("themachine") =system.dbnull.value
               dr("themachine_ID") =System.Guid.Empty
             else
               dr("themachine") =themachine.BRIEF
               dr("themachine_ID") =themachine.ID
             end if 
             if trandtype is nothing then
               dr("trandtype") =system.dbnull.value
               dr("trandtype_ID") =System.Guid.Empty
             else
               dr("trandtype") =trandtype.BRIEF
               dr("trandtype_ID") =trandtype.ID
             end if 
             dr("topvalue") =topvalue
             dr("bottomval") =bottomval
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
          if m_themachine.Equals(System.Guid.Empty) then
            nv.Add("themachine", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("themachine", Application.Session.GetProvider.ID2Param(m_themachine), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_trandtype.Equals(System.Guid.Empty) then
            nv.Add("trandtype", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("trandtype", Application.Session.GetProvider.ID2Param(m_trandtype), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("topvalue", topvalue, dbtype.double)
          nv.Add("bottomval", bottomval, dbtype.double)
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
      If reader.Table.Columns.Contains("themachine") Then
          if isdbnull(reader.item("themachine")) then
            If reader.Table.Columns.Contains("themachine") Then m_themachine = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("themachine") Then m_themachine= New System.Guid(reader.item("themachine").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("trandtype") Then
          if isdbnull(reader.item("trandtype")) then
            If reader.Table.Columns.Contains("trandtype") Then m_trandtype = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("trandtype") Then m_trandtype= New System.Guid(reader.item("trandtype").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("topvalue") Then m_topvalue=reader.item("topvalue")
          If reader.Table.Columns.Contains("bottomval") Then m_bottomval=reader.item("bottomval")
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Станок
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property themachine() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                themachine = me.application.Findrowobject("tod_st",m_themachine)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_themachine = Value.id
                else
                   m_themachine=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Тип тренда
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property trandtype() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                trandtype = me.application.Findrowobject("tod_trand",m_trandtype)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_trandtype = Value.id
                else
                   m_trandtype=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Верхняя граница
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property topvalue() As double
            Get
                LoadFromDatabase()
                topvalue = m_topvalue
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_topvalue = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Нижняя граница
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property bottomval() As double
            Get
                LoadFromDatabase()
                bottomval = m_bottomval
                AccessTime = Now
            End Get
            Set(ByVal Value As double )
                LoadFromDatabase()
                m_bottomval = Value
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
            m_themachine = new system.guid(node.Attributes.GetNamedItem("themachine").Value)
            m_trandtype = new system.guid(node.Attributes.GetNamedItem("trandtype").Value)
            topvalue = node.Attributes.GetNamedItem("topvalue").Value
            bottomval = node.Attributes.GetNamedItem("bottomval").Value
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
          node.SetAttribute("themachine", m_themachine.tostring)  
          node.SetAttribute("trandtype", m_trandtype.tostring)  
          node.SetAttribute("topvalue", topvalue)  
          node.SetAttribute("bottomval", bottomval)  
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
