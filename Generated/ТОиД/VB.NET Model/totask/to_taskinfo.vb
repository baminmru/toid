
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
'''Локальная переменная для поля Задача завершена
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_taskfinished  as enumBoolean


''' <summary>
'''Локальная переменная для поля Дата создания
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_crdate  as DATE


''' <summary>
'''Локальная переменная для поля Время завершения задачи
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_finishtime  as DATE


''' <summary>
'''Локальная переменная для поля Пункт расписания
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_themachine  as System.Guid


''' <summary>
'''Локальная переменная для поля Диагностическая карта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_thecard  as System.Guid


''' <summary>
'''Локальная переменная для поля Оператор
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_oper  as System.Guid



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_taskfinished=   
            ' m_crdate=   
            ' m_finishtime=   
            ' m_themachine=   
            ' m_thecard=   
            ' m_oper=   
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
                    Value = themachine
                Case 2
                    Value = oper
                Case 3
                    Value = thecard
                Case 4
                    Value = crdate
                Case 5
                    Value = taskfinished
                Case 6
                    Value = finishtime
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
                    oper = value
                Case 3
                    thecard = value
                Case 4
                    crdate = value
                Case 5
                    taskfinished = value
                Case 6
                    finishtime = value
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
                    Return "oper"
                Case 3
                    Return "thecard"
                Case 4
                    Return "crdate"
                Case 5
                    Return "taskfinished"
                Case 6
                    Return "finishtime"
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
             if oper is nothing then
               dr("oper") =system.dbnull.value
               dr("oper_ID") =System.Guid.Empty
             else
               dr("oper") =oper.BRIEF
               dr("oper_ID") =oper.ID
             end if 
             if thecard is nothing then
               dr("thecard") =system.dbnull.value
               dr("thecard_ID") =System.Guid.Empty
             else
               dr("thecard") =thecard.BRIEF
               dr("thecard_ID") =thecard.ID
             end if 
             dr("crdate") =crdate
             select case taskfinished
            case enumBoolean.Boolean_Da
              dr ("taskfinished")  = "Да"
              dr ("taskfinished_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("taskfinished")  = "Нет"
              dr ("taskfinished_VAL")  = 0
              end select 'taskfinished
             dr("finishtime") =finishtime
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
          if m_oper.Equals(System.Guid.Empty) then
            nv.Add("oper", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("oper", Application.Session.GetProvider.ID2Param(m_oper), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if m_thecard.Equals(System.Guid.Empty) then
            nv.Add("thecard", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("thecard", Application.Session.GetProvider.ID2Param(m_thecard), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if crdate=System.DateTime.MinValue then
            nv.Add("crdate", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("crdate", crdate, dbtype.DATETIME)
          end if 
          nv.Add("taskfinished", taskfinished, dbtype.int16)
          if finishtime=System.DateTime.MinValue then
            nv.Add("finishtime", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("finishtime", finishtime, dbtype.DATETIME)
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
      If reader.Table.Columns.Contains("themachine") Then
          if isdbnull(reader.item("themachine")) then
            If reader.Table.Columns.Contains("themachine") Then m_themachine = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("themachine") Then m_themachine= New System.Guid(reader.item("themachine").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("oper") Then
          if isdbnull(reader.item("oper")) then
            If reader.Table.Columns.Contains("oper") Then m_oper = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("oper") Then m_oper= New System.Guid(reader.item("oper").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("thecard") Then
          if isdbnull(reader.item("thecard")) then
            If reader.Table.Columns.Contains("thecard") Then m_thecard = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("thecard") Then m_thecard= New System.Guid(reader.item("thecard").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("crdate") Then
          if isdbnull(reader.item("crdate")) then
            If reader.Table.Columns.Contains("crdate") Then m_crdate = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("crdate") Then m_crdate=reader.item("crdate")
          end if 
      end if 
          If reader.Table.Columns.Contains("taskfinished") Then m_taskfinished=reader.item("taskfinished")
      If reader.Table.Columns.Contains("finishtime") Then
          if isdbnull(reader.item("finishtime")) then
            If reader.Table.Columns.Contains("finishtime") Then m_finishtime = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("finishtime") Then m_finishtime=reader.item("finishtime")
          end if 
      end if 
           catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Sub


''' <summary>
'''Доступ к полю Пункт расписания
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property themachine() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                themachine = me.application.Findrowobject("to_scheditems",m_themachine)
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
        Public Property thecard() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                thecard = me.application.Findrowobject("to_cardinfo",m_thecard)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_thecard = Value.id
                else
                   m_thecard=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата создания
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property crdate() As DATE
            Get
                LoadFromDatabase()
                crdate = m_crdate
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_crdate = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Задача завершена
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property taskfinished() As enumBoolean
            Get
                LoadFromDatabase()
                taskfinished = m_taskfinished
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_taskfinished = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Время завершения задачи
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property finishtime() As DATE
            Get
                LoadFromDatabase()
                finishtime = m_finishtime
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_finishtime = Value
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
            m_oper = new system.guid(node.Attributes.GetNamedItem("oper").Value)
            m_thecard = new system.guid(node.Attributes.GetNamedItem("thecard").Value)
            m_crdate = System.DateTime.MinValue
            crdate = m_crdate.AddTicks( node.Attributes.GetNamedItem("crdate").Value)
            taskfinished = node.Attributes.GetNamedItem("taskfinished").Value
            m_finishtime = System.DateTime.MinValue
            finishtime = m_finishtime.AddTicks( node.Attributes.GetNamedItem("finishtime").Value)
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
          node.SetAttribute("oper", m_oper.tostring)  
          node.SetAttribute("thecard", m_thecard.tostring)  
         ' if crdate = System.DateTime.MinValue then crdate=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("crdate", crdate.Ticks)  
          node.SetAttribute("taskfinished", taskfinished)  
         ' if finishtime = System.DateTime.MinValue then finishtime=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("finishtime", finishtime.Ticks)  
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
