
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace totrn


''' <summary>
'''Реализация раздела Описание трендав виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class totrn_def_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "totrn_def"
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
            dt.TableName="totrn_def"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("themachine_ID" , GetType(System.guid))
            dt.Columns.Add("themachine", Gettype(System.string))
            dt.Columns.Add("trandtype_ID" , GetType(System.guid))
            dt.Columns.Add("trandtype", Gettype(System.string))
            dt.Columns.Add("topvalue", GetType(System.double))
            dt.Columns.Add("bottomval", GetType(System.double))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New totrn_def
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As totrn.totrn_def
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(totrn.totrn_def))
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
        Public Shadows Function Item( vIndex as object ) As totrn.totrn_def
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("totrn_defID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+","+.ID2Base("themachine") 
           mFieldList =mFieldList+","+.ID2Base("trandtype") 
           mFieldList =mFieldList+ ", topvalue" 
           mFieldList =mFieldList+ ", bottomval" 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
