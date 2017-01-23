
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace tocard


''' <summary>
'''Реализация раздела Проверкив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_cardchecks_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "to_cardchecks"
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
            dt.TableName="to_cardchecks"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("the_system_ID" , GetType(System.guid))
            dt.Columns.Add("the_system", Gettype(System.string))
            dt.Columns.Add("thesubsystem", Gettype(System.string))
            dt.Columns.Add("the_check", Gettype(System.string))
            dt.Columns.Add("normochas", GetType(System.double))
            dt.Columns.Add("valuetype_ID" , GetType(System.guid))
            dt.Columns.Add("valuetype", Gettype(System.string))
            dt.Columns.Add("lowvalue", Gettype(System.string))
            dt.Columns.Add("hivalue", Gettype(System.string))
            dt.Columns.Add("the_comment", Gettype(System.string))
            dt.Columns.Add("tagid", Gettype(System.string))
            dt.Columns.Add("the_doc", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New to_cardchecks
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As tocard.to_cardchecks
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(tocard.to_cardchecks))
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
        Public Shadows Function Item( vIndex as object ) As tocard.to_cardchecks
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("to_cardchecksID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("the_system") 
           mFieldList =mFieldList+ ", thesubsystem" 
           mFieldList =mFieldList+ ", the_check" 
           mFieldList =mFieldList+ ", normochas" 
           mFieldList =mFieldList+","+.ID2Base("valuetype") 
           mFieldList =mFieldList+ ", lowvalue" 
           mFieldList =mFieldList+ ", hivalue" 
           mFieldList =mFieldList+ ", the_comment" 
           mFieldList =mFieldList+ ", tagid" 
           mFieldList =mFieldList+ ", the_doc" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
