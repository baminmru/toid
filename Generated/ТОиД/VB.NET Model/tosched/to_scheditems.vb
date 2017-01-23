
Option Explicit On

Imports System
Imports System.IO
Imports LATIR2
Imports System.xml
Imports System.Data
Imports System.Convert
Imports System.DateTime
Imports System.Diagnostics

Namespace tosched


''' <summary>
'''Реализация строки раздела Расписание ТО
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_scheditems
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля ТО проведено
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_isdone  as enumBoolean


''' <summary>
'''Локальная переменная для поля Станок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_themachine  as System.Guid


''' <summary>
'''Локальная переменная для поля Дата завершения ТО
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_finishdate  as DATE


''' <summary>
'''Локальная переменная для поля Плановая дата ТО
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_todate  as DATE


''' <summary>
'''Локальная переменная для поля Взят в работу
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_checkin  as DATE


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
            ' m_isdone=   
            ' m_themachine=   
            ' m_finishdate=   
            ' m_todate=   
            ' m_checkin=   
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
                    Value = todate
                Case 3
                    Value = checkin
                Case 4
                    Value = oper
                Case 5
                    Value = isdone
                Case 6
                    Value = finishdate
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
                    todate = value
                Case 3
                    checkin = value
                Case 4
                    oper = value
                Case 5
                    isdone = value
                Case 6
                    finishdate = value
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
                    Return "todate"
                Case 3
                    Return "checkin"
                Case 4
                    Return "oper"
                Case 5
                    Return "isdone"
                Case 6
                    Return "finishdate"
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
             dr("todate") =todate
             dr("checkin") =checkin
             if oper is nothing then
               dr("oper") =system.dbnull.value
               dr("oper_ID") =System.Guid.Empty
             else
               dr("oper") =oper.BRIEF
               dr("oper_ID") =oper.ID
             end if 
             select case isdone
            case enumBoolean.Boolean_Da
              dr ("isdone")  = "Да"
              dr ("isdone_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("isdone")  = "Нет"
              dr ("isdone_VAL")  = 0
              end select 'isdone
             dr("finishdate") =finishdate
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
          if todate=System.DateTime.MinValue then
            nv.Add("todate", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("todate", todate, dbtype.DATETIME)
          end if 
          if checkin=System.DateTime.MinValue then
            nv.Add("checkin", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("checkin", checkin, dbtype.DATETIME)
          end if 
          if m_oper.Equals(System.Guid.Empty) then
            nv.Add("oper", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("oper", Application.Session.GetProvider.ID2Param(m_oper), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          nv.Add("isdone", isdone, dbtype.int16)
          if finishdate=System.DateTime.MinValue then
            nv.Add("finishdate", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("finishdate", finishdate, dbtype.DATETIME)
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
      If reader.Table.Columns.Contains("todate") Then
          if isdbnull(reader.item("todate")) then
            If reader.Table.Columns.Contains("todate") Then m_todate = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("todate") Then m_todate=reader.item("todate")
          end if 
      end if 
      If reader.Table.Columns.Contains("checkin") Then
          if isdbnull(reader.item("checkin")) then
            If reader.Table.Columns.Contains("checkin") Then m_checkin = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("checkin") Then m_checkin=reader.item("checkin")
          end if 
      end if 
      If reader.Table.Columns.Contains("oper") Then
          if isdbnull(reader.item("oper")) then
            If reader.Table.Columns.Contains("oper") Then m_oper = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("oper") Then m_oper= New System.Guid(reader.item("oper").ToString())
          end if 
      end if 
          If reader.Table.Columns.Contains("isdone") Then m_isdone=reader.item("isdone")
      If reader.Table.Columns.Contains("finishdate") Then
          if isdbnull(reader.item("finishdate")) then
            If reader.Table.Columns.Contains("finishdate") Then m_finishdate = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("finishdate") Then m_finishdate=reader.item("finishdate")
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
'''Доступ к полю Плановая дата ТО
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property todate() As DATE
            Get
                LoadFromDatabase()
                todate = m_todate
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_todate = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Взят в работу
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property checkin() As DATE
            Get
                LoadFromDatabase()
                checkin = m_checkin
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_checkin = Value
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
'''Доступ к полю ТО проведено
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property isdone() As enumBoolean
            Get
                LoadFromDatabase()
                isdone = m_isdone
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_isdone = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата завершения ТО
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property finishdate() As DATE
            Get
                LoadFromDatabase()
                finishdate = m_finishdate
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_finishdate = Value
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
            m_todate = System.DateTime.MinValue
            todate = m_todate.AddTicks( node.Attributes.GetNamedItem("todate").Value)
            m_checkin = System.DateTime.MinValue
            checkin = m_checkin.AddTicks( node.Attributes.GetNamedItem("checkin").Value)
            m_oper = new system.guid(node.Attributes.GetNamedItem("oper").Value)
            isdone = node.Attributes.GetNamedItem("isdone").Value
            m_finishdate = System.DateTime.MinValue
            finishdate = m_finishdate.AddTicks( node.Attributes.GetNamedItem("finishdate").Value)
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
         ' if todate = System.DateTime.MinValue then todate=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("todate", todate.Ticks)  
         ' if checkin = System.DateTime.MinValue then checkin=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("checkin", checkin.Ticks)  
          node.SetAttribute("oper", m_oper.tostring)  
          node.SetAttribute("isdone", isdone)  
         ' if finishdate = System.DateTime.MinValue then finishdate=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("finishdate", finishdate.Ticks)  
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
