
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace tocard


''' <summary>
'''Реализация раздела Описаниев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_cardinfo_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "to_cardinfo"
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
            dt.TableName="to_cardinfo"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("the_machine_ID" , GetType(System.guid))
            dt.Columns.Add("the_machine", Gettype(System.string))
            dt.Columns.Add("card_date", GetType(System.DateTime))
            dt.Columns.Add("card_archived_VAL" , Gettype(System.Int16))
            dt.Columns.Add("card_archived", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New to_cardinfo
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As tocard.to_cardinfo
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(tocard.to_cardinfo))
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
        Public Shadows Function Item( vIndex as object ) As tocard.to_cardinfo
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("to_cardinfoID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("the_machine") 
           mFieldList =mFieldList+","+.Date2Base("card_date") 
           mFieldList =mFieldList+ ", card_archived" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
