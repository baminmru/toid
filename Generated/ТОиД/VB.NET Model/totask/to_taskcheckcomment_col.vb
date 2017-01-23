
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace totask


''' <summary>
'''Реализация раздела Комментарии к проверкев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_taskcheckcomment_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "to_taskcheckcomment"
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
            dt.TableName="to_taskcheckcomment"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("the_operator_ID" , GetType(System.guid))
            dt.Columns.Add("the_operator", Gettype(System.string))
            dt.Columns.Add("the_date", GetType(System.DateTime))
            dt.Columns.Add("info", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New to_taskcheckcomment
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As totask.to_taskcheckcomment
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(totask.to_taskcheckcomment))
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
        Public Shadows Function Item( vIndex as object ) As totask.to_taskcheckcomment
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("to_taskcheckcommentID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("the_operator") 
           mFieldList =mFieldList+","+.Date2Base("the_date") 
           mFieldList =mFieldList+ ", info" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
