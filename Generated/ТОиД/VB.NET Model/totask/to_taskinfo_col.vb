
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace totask


''' <summary>
'''Реализация раздела Описаниев виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_taskinfo_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "to_taskinfo"
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
            dt.TableName="to_taskinfo"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("theMachine_ID" , GetType(System.guid))
            dt.Columns.Add("theMachine", Gettype(System.string))
            dt.Columns.Add("oper_ID" , GetType(System.guid))
            dt.Columns.Add("oper", Gettype(System.string))
            dt.Columns.Add("theCard_ID" , GetType(System.guid))
            dt.Columns.Add("theCard", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New to_taskinfo
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As totask.to_taskinfo
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(totask.to_taskinfo))
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
        Public Shadows Function Item( vIndex as object ) As totask.to_taskinfo
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("to_taskinfoID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("theMachine") 
           mFieldList =mFieldList+","+.ID2Base("oper") 
           mFieldList =mFieldList+","+.ID2Base("theCard") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
