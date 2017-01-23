
Option Explicit On

Imports LATIR2
Imports System
Imports System.xml
Imports System.Data
Imports System.Diagnostics

Namespace toimg


''' <summary>
'''Реализация раздела Картинкив виде коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Class toimg_data_col
        Inherits LATIR2.Document.DocCollection_Base



''' <summary>
'''Имя раздела в базе данных
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Overrides Function ChildPartName() As String
            ChildPartName = "toimg_data"
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
            dt.TableName="toimg_data"
            dt.Columns.Add("ID", GetType(System.guid))
            dt.Columns.Add("Brief", Gettype(System.string))
            dt.Columns.Add("fname", Gettype(System.string))
            dt.Columns.Add("link2part", Gettype(System.string))
            dt.Columns.Add("link2id", Gettype(System.string))
            dt.Columns.Add("filetype", Gettype(System.string))
            dt.Columns.Add("link1part", Gettype(System.string))
            dt.Columns.Add("link1id", Gettype(System.string))
            dt.Columns.Add("oper_ID" , GetType(System.guid))
            dt.Columns.Add("oper", Gettype(System.string))
            return dt
        End Function



''' <summary>
'''Создание нового элемента коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Protected Overrides Function NewItem() As LATIR2.Document.DocRow_Base
            NewItem = New toimg_data
        End Function


''' <summary>
'''Получить элемент коллекции
''' </summary>
''' <remarks>
'''
''' </remarks>
        Public Function GetItem( vIndex as object ) As toimg.toimg_data
            try
            GetItem = Convert.ChangeType(mybase.Item(vIndex), GetType(toimg.toimg_data))
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
        Public Shadows Function Item( vIndex as object ) As toimg.toimg_data
          try
            return GetItem(vIndex)
          catch ex as System.Exception
              Debug.Print( ex.Message + " >> " + ex.StackTrace)
          end try
        End Function
Public Overrides Function FieldList() As String
    If mFieldList = "*" Then
       with application.Session.GetProvider
       mFieldList=.ID2Base("toimg_dataID")
           mFieldList =mFieldList+","+.ID2Base("SecurityStyleID") 
           mFieldList =mFieldList+ ", fname" 
           mFieldList =mFieldList+ ", link2part" 
           mFieldList =mFieldList+ ", link2id" 
           mFieldList =mFieldList+ ", filetype" 
           mFieldList =mFieldList+ ", link1part" 
           mFieldList =mFieldList+ ", link1id" 
           mFieldList =mFieldList+","+.ID2Base("oper") 
       end with
    End If
    Return mFieldList
End Function

    End Class
End Namespace
