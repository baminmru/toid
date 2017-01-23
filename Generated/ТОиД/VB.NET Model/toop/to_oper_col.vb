
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace toop


''' <summary>
'''Реализация раздела Операторв виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class to_oper_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "to_oper"
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
            dt.TableName="to_oper"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("familyname", Gettype(System.string))
            dt.Columns.Add("name", Gettype(System.string))
            dt.Columns.Add("surname", Gettype(System.string))
            dt.Columns.Add("tnum", Gettype(System.string))
            dt.Columns.Add("therole_ID" , GetType(System.guid))
            dt.Columns.Add("therole", Gettype(System.string))
            dt.Columns.Add("login", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New to_oper
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As toop.to_oper
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(toop.to_oper))
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
        Public Shadows Function Item( vIndex as object ) As toop.to_oper
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("to_operID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", familyname" 
           mFieldList =mFieldList+ ", name" 
           mFieldList =mFieldList+ ", surname" 
           mFieldList =mFieldList+ ", tnum" 
           mFieldList =mFieldList+","+.ID2Base("therole") 
           mFieldList =mFieldList+ ", login" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
