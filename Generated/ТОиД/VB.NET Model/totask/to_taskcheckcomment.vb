
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
'''Реализация строки раздела Комментарии к проверке
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_taskcheckcomment
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Дата комментария
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_date  as DATE


''' <summary>
'''Локальная переменная для поля Оператор
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_operator  as System.Guid


''' <summary>
'''Локальная переменная для поля Суть комментария
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_info  as STRING



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_the_date=   
            ' m_the_operator=   
            ' m_info=   
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
                    Value = the_operator
                Case 2
                    Value = the_date
                Case 3
                    Value = info
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
                    the_operator = value
                Case 2
                    the_date = value
                Case 3
                    info = value
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
                    Return "the_operator"
                Case 2
                    Return "the_date"
                Case 3
                    Return "info"
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
             if the_operator is nothing then
               dr("the_operator") =system.dbnull.value
               dr("the_operator_ID") =System.Guid.Empty
             else
               dr("the_operator") =the_operator.BRIEF
               dr("the_operator_ID") =the_operator.ID
             end if 
             dr("the_date") =the_date
             dr("info") =info
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
          if m_the_operator.Equals(System.Guid.Empty) then
            nv.Add("the_operator", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("the_operator", Application.Session.GetProvider.ID2Param(m_the_operator), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if the_date=System.DateTime.MinValue then
            nv.Add("the_date", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("the_date", the_date, dbtype.DATETIME)
          end if 
          nv.Add("info", info, dbtype.string)
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
      If reader.Table.Columns.Contains("the_operator") Then
          if isdbnull(reader.item("the_operator")) then
            If reader.Table.Columns.Contains("the_operator") Then m_the_operator = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("the_operator") Then m_the_operator= New System.Guid(reader.item("the_operator").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("the_date") Then
          if isdbnull(reader.item("the_date")) then
            If reader.Table.Columns.Contains("the_date") Then m_the_date = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("the_date") Then m_the_date=reader.item("the_date")
          end if 
      end if 
          If reader.Table.Columns.Contains("info") Then m_info=reader.item("info").ToString()
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Оператор
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_operator() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                the_operator = me.application.Findrowobject("to_oper",m_the_operator)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_the_operator = Value.id
                else
                   m_the_operator=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата комментария
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property the_date() As DATE
            Get
                LoadFromDatabase()
                the_date = m_the_date
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_the_date = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Суть комментария
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property info() As STRING
            Get
                LoadFromDatabase()
                info = m_info
                AccessTime = Now
            End Get
            Set(ByVal Value As STRING )
                LoadFromDatabase()
                m_info = Value
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
            m_the_operator = new system.guid(node.Attributes.GetNamedItem("the_operator").Value)
            m_the_date = System.DateTime.MinValue
            the_date = m_the_date.AddTicks( node.Attributes.GetNamedItem("the_date").Value)
            info = node.Attributes.GetNamedItem("info").Value
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
          node.SetAttribute("the_operator", m_the_operator.tostring)  
         ' if the_date = System.DateTime.MinValue then the_date=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("the_date", the_date.Ticks)  
          node.SetAttribute("info", info)  
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
