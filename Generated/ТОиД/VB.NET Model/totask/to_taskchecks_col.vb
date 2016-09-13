
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace totask


''' <summary>
'''Реализация раздела Проверкив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_taskchecks_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "to_taskchecks"
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
            dt.TableName="to_taskchecks"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("the_system_ID" , GetType(System.guid))
            dt.Columns.Add("the_system", Gettype(System.string))
            dt.Columns.Add("the_check", Gettype(System.string))
            dt.Columns.Add("normochas", GetType(System.double))
            dt.Columns.Add("ValueType_ID" , GetType(System.guid))
            dt.Columns.Add("ValueType", Gettype(System.string))
            dt.Columns.Add("lowvalue", Gettype(System.string))
            dt.Columns.Add("hivalue", Gettype(System.string))
            dt.Columns.Add("the_comment", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New to_taskchecks
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As totask.to_taskchecks
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(totask.to_taskchecks))
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
        Public Shadows Function Item( vIndex as object ) As totask.to_taskchecks
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("to_taskchecksID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("the_system") 
           mFieldList =mFieldList+ ", the_check" 
           mFieldList =mFieldList+ ", normochas" 
           mFieldList =mFieldList+","+.ID2Base("ValueType") 
           mFieldList =mFieldList+ ", lowvalue" 
           mFieldList =mFieldList+ ", hivalue" 
           mFieldList =mFieldList+ ", the_comment" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
