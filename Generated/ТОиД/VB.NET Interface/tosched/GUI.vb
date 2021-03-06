
Imports LATIR2GuiManager
Imports System.Windows.Forms
Imports System.Diagnostics


''' <summary>
'''Основной класс компонента
''' </summary>
''' <remarks>
'''Класс обслуживает визуальное редактирование 
''' </remarks>
Public Class GUI
    Inherits LATIR2GuiManager.Doc_GUIBase


''' <summary>
'''Имя типа
''' </summary>
''' <returns>
'''Строковое значение кода типа объекта 
''' </returns>
''' <remarks>
'''Код типа в метамодели
''' </remarks>
    Public Overrides Function TypeName() As String
        Return "tosched"
    End Function


''' <summary>
'''Форма редактирования раздела
''' </summary>
''' <returns>
'''Результат работы формы редактирования
''' </returns>
''' <remarks>
'''Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы
''' </remarks>
    Public Overrides Function ShowPartEditForm(ByVal Mode As String, ByRef RowItem As LATIR2.Document.DocRow_Base, optional byval FormReadOnly as boolean = false) As Boolean
        ' Mode
        If Mode = "" Then

            If RowItem.PartName.ToUpper = "TO_SCHEDINFO" Then
                Dim f As frmto_schedinfo
                f = New frmto_schedinfo
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_SCHEDITEMS" Then
                Dim f As frmto_scheditems
                f = New frmto_scheditems
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "adm" Then

            If RowItem.PartName.ToUpper = "TO_SCHEDINFO" Then
                Dim f As frmto_schedinfoadm
                f = New frmto_schedinfoadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_SCHEDITEMS" Then
                Dim f As frmto_scheditemsadm
                f = New frmto_scheditemsadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "main" Then

            If RowItem.PartName.ToUpper = "TO_SCHEDINFO" Then
                Dim f As frmto_schedinfomain
                f = New frmto_schedinfomain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_SCHEDITEMS" Then
                Dim f As frmto_scheditemsmain
                f = New frmto_scheditemsmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If

    End Function


''' <summary>
'''Форма редактирования документа
''' </summary>
''' <returns>
'''Резултат работы формы редактирования
''' </returns>
''' <remarks>
'''Определяется какая форма должна быть вызвана, происходит инициализация и вызов формы в модальном режиме
''' </remarks>
    Public Overrides Function ShowForm(ByVal Mode As String, ByRef DocItem As LATIR2.Document.Doc_Base, optional byval FormReadOnly as boolean = false) As Boolean
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "" Then
                Dim f As frmtosched
                f = New frmtosched
                f.Attach(DocItem, Me.GUIManager, FormReadOnly)
                ShowForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "adm" Then
                Dim fadm As frmtoschedadm
                fadm = New frmtoschedadm
                fadm.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fadm.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fadm = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "main" Then
                Dim fmain As frmtoschedmain
                fmain = New frmtoschedmain
                fmain.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fmain.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fmain = Nothing
            End If
        End If
    End Function


''' <summary>
'''Получить контрол, реализующий работу в заданном режиме
''' </summary>
''' <remarks>
'''
''' </remarks>
    Public Overrides Function GetObjectControl(ByVal Mode As String, ByVal TypeName As String) As Object
            If Mode = "adm" Then
                Return New Tabviewadm
            End If
            If Mode = "main" Then
                Return New Tabviewmain
            End If
      Return New Tabview
    End Function

    Public Overrides Sub Dispose()
        ' do nothing
    End Sub




End Class
