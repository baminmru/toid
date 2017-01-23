
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
'''Реализация строки раздела Описание
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_cardinfo
        Inherits LATIR2.Document.DocRow_Base



''' <summary>
'''Локальная переменная для поля Станок
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_the_machine  as System.Guid


''' <summary>
'''Локальная переменная для поля Архивная карта
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_card_archived  as enumBoolean


''' <summary>
'''Локальная переменная для поля Дата составления карты
''' </summary>
''' <remarks>
'''
''' </remarks>
            private m_card_date  as DATE



''' <summary>
'''Очистить поля раздела
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Sub CleanFields()
            ' m_the_machine=   
            ' m_card_archived=   
            ' m_card_date=   
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
                    Value = the_machine
                Case 2
                    Value = card_date
                Case 3
                    Value = card_archived
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
                    the_machine = value
                Case 2
                    card_date = value
                Case 3
                    card_archived = value
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
                    Return "the_machine"
                Case 2
                    Return "card_date"
                Case 3
                    Return "card_archived"
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
             if the_machine is nothing then
               dr("the_machine") =system.dbnull.value
               dr("the_machine_ID") =System.Guid.Empty
             else
               dr("the_machine") =the_machine.BRIEF
               dr("the_machine_ID") =the_machine.ID
             end if 
             dr("card_date") =card_date
             select case card_archived
            case enumBoolean.Boolean_Da
              dr ("card_archived")  = "Да"
              dr ("card_archived_VAL")  = -1
            case enumBoolean.Boolean_Net
              dr ("card_archived")  = "Нет"
              dr ("card_archived_VAL")  = 0
              end select 'card_archived
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
          if m_the_machine.Equals(System.Guid.Empty) then
            nv.Add("the_machine", system.dbnull.value, Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          else
            nv.Add("the_machine", Application.Session.GetProvider.ID2Param(m_the_machine), Application.Session.GetProvider.ID2DbType, Application.Session.GetProvider.ID2Size)
          end if 
          if card_date=System.DateTime.MinValue then
            nv.Add("card_date", system.dbnull.value, dbtype.DATETIME)
          else
            nv.Add("card_date", card_date, dbtype.DATETIME)
          end if 
          nv.Add("card_archived", card_archived, dbtype.int16)
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
      If reader.Table.Columns.Contains("the_machine") Then
          if isdbnull(reader.item("the_machine")) then
            If reader.Table.Columns.Contains("the_machine") Then m_the_machine = System.GUID.Empty
          else
            If reader.Table.Columns.Contains("the_machine") Then m_the_machine= New System.Guid(reader.item("the_machine").ToString())
          end if 
      end if 
      If reader.Table.Columns.Contains("card_date") Then
          if isdbnull(reader.item("card_date")) then
            If reader.Table.Columns.Contains("card_date") Then m_card_date = System.DateTime.MinValue
          else
            If reader.Table.Columns.Contains("card_date") Then m_card_date=reader.item("card_date")
          end if 
      end if 
          If reader.Table.Columns.Contains("card_archived") Then m_card_archived=reader.item("card_archived")
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
        Public Property the_machine() As LATIR2.Document.docrow_base
            Get
                LoadFromDatabase()
                the_machine = me.application.Findrowobject("tod_st",m_the_machine)
                AccessTime = Now
            End Get
            Set(ByVal Value As LATIR2.Document.docrow_base )
                LoadFromDatabase()
                if not Value is nothing then
                    m_the_machine = Value.id
                else
                   m_the_machine=System.Guid.Empty
                end if
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Дата составления карты
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property card_date() As DATE
            Get
                LoadFromDatabase()
                card_date = m_card_date
                AccessTime = Now
            End Get
            Set(ByVal Value As DATE )
                LoadFromDatabase()
                m_card_date = Value
                ChangeTime = Now
            End Set
        End Property


''' <summary>
'''Доступ к полю Архивная карта
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Property card_archived() As enumBoolean
            Get
                LoadFromDatabase()
                card_archived = m_card_archived
                AccessTime = Now
            End Get
            Set(ByVal Value As enumBoolean )
                LoadFromDatabase()
                m_card_archived = Value
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
            m_the_machine = new system.guid(node.Attributes.GetNamedItem("the_machine").Value)
            m_card_date = System.DateTime.MinValue
            card_date = m_card_date.AddTicks( node.Attributes.GetNamedItem("card_date").Value)
            card_archived = node.Attributes.GetNamedItem("card_archived").Value
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
          node.SetAttribute("the_machine", m_the_machine.tostring)  
         ' if card_date = System.DateTime.MinValue then card_date=new Date(1899,12,30)  ' SQL Server trouble
          node.SetAttribute("card_date", card_date.Ticks)  
          node.SetAttribute("card_archived", card_archived)  
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
