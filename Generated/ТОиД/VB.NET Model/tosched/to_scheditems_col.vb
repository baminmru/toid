
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace tosched


''' <summary>
'''Реализация раздела Расписание ТОв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_scheditems_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "to_scheditems"
        End Function



''' <summary>
'''Вернуть даные текущей коллекции в виде DataTable
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function CreateDataTable() As System.Data.DataTable
            Dim dt As DataTable
            dt = New DataTable
            dt.TableName="to_scheditems"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("themachine_ID" , GetType(System.guid))
            dt.Columns.Add("themachine", Gettype(System.string))
            dt.Columns.Add("todate", GetType(System.DateTime))
            dt.Columns.Add("checkin", GetType(System.DateTime))
            dt.Columns.Add("oper_ID" , GetType(System.guid))
            dt.Columns.Add("oper", Gettype(System.string))
            dt.Columns.Add("isdone_VAL" , Gettype(System.Int16))
            dt.Columns.Add("isdone", Gettype(System.string))
            dt.Columns.Add("finishdate", GetType(System.DateTime))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New to_scheditems
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As tosched.to_scheditems
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(tosched.to_scheditems))
catch ex as System.Exception
 Debug.Print( ex.Message + " >> " + ex.StackTrace)
end try
        End Function


''' <summary>
'''Получить элемент коллекции, более свежий вариант
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Shadows Function Item( vIndex as object ) As tosched.to_scheditems
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("to_scheditemsID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("themachine") 
           mFieldList =mFieldList+","+.Date2Base("todate") 
           mFieldList =mFieldList+","+.Date2Base("checkin") 
           mFieldList =mFieldList+","+.ID2Base("oper") 
           mFieldList =mFieldList+ ", isdone" 
           mFieldList =mFieldList+","+.Date2Base("finishdate") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
