
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
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_taskinfo
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Станок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_theMachine  as System.Guid


''' <summary>
'''Локальная переменная для поля Оператор
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_oper  as System.Guid


''' <summary>
'''Локальная переменная для поля Диагностическая карта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_theCard  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_theMachine=   
            ' m_oper=   
            ' m_theCard=   
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
                    Value = theMachine
                Case 2
                    Value = oper
                Case 3
                    Value = theCard
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
                    theMachine = value
                Case 2
                    oper = value
                Case 3
                    theCard = value
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
                    Return "theMachine"
                Case 2
                    Return "oper"
                Case 3
                    Return "theCard"
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
             if theMachine is nothing then
               dr("theMachine") =system.dbnull.value
               dr("theMachine_ID") =System.Guid.Empty
             else
               dr("theMachine") =theMachine.BRIEF
               dr("theMachine_ID") =theMachine.ID
             end if 
             if oper is nothing then
               dr("oper") =system.dbnull.value
               dr("oper_ID") =System.Guid.Empty
             else
               dr("oper") =oper.BRIEF
               dr("oper_ID") =oper.ID
             end if 
             if theCard is nothing then
               dr("theCard") =system.dbnull.value
               dr("theCard_ID") =System.Guid.Empty
             else
               dr("theCard") =theCard.BRIEF
               dr("theCard_ID") =theCard.ID
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
          if m_theMachine.Equals(System.Guid.Empty) then
            nv.Add("theMachine", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("theMachine", Application.Session.GetProvider.ID2Param(m_theMachine), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_oper.Equals(System.Guid.Empty) then
            nv.Add("oper", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("oper", Application.Session.GetProvider.ID2Param(m_oper), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_theCard.Equals(System.Guid.Empty) then
            nv.Add("theCard", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("theCard", Application.Session.GetProvider.ID2Param(m_theCard), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
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
      If reader.Table.Columns.Contains("theMachine") Then
          if isdbnull(reader.item("theMachine")) then
            If reader.Table.Columns.Contains("theMachine") Then m_theMachine = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("theMachine") Then m_theMachine= New System.Guid(reader.item("theMachine").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("oper") Then
          if isdbnull(reader.item("oper")) then
            If reader.Table.Columns.Contains("oper") Then m_oper = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("oper") Then m_oper= New System.Guid(reader.item("oper").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("theCard") Then
          if isdbnull(reader.item("theCard")) then
            If reader.Table.Columns.Contains("theCard") Then m_theCard = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("theCard") Then m_theCard= New System.Guid(reader.item("theCard").ToString())
          end if 
      end if 
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
        Public Property theMachine() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                theMachine = me.application.Findrowobject("tod_st",m_theMachine)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_theMachine = Value.id
                else
                   m_theMachine=System.Guid.Empty
                end if
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
'''Доступ к полю Диагностическая карта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property theCard() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                theCard = me.application.Findrowobject("to_cardinfo",m_theCard)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_theCard = Value.id
                else
                   m_theCard=System.Guid.Empty
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
            m_theMachine = new system.guid(node.Attributes.GetNamedItem("theMachine").Value)
            m_oper = new system.guid(node.Attributes.GetNamedItem("oper").Value)
            m_theCard = new system.guid(node.Attributes.GetNamedItem("theCard").Value)
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
          node.SetAttribute("theMachine", m_theMachine.tostring)  
          node.SetAttribute("oper", m_oper.tostring)  
          node.SetAttribute("theCard", m_theCard.tostring)  
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
