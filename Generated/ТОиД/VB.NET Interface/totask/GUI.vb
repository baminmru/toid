
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
        Return "totask"
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

            If RowItem.PartName.ToUpper = "TO_TASKINFO" Then
                Dim f As frmto_taskinfo
                f = New frmto_taskinfo
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCHECKS" Then
                Dim f As frmto_taskchecks
                f = New frmto_taskchecks
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCHECKCOMMENT" Then
                Dim f As frmto_taskcheckcomment
                f = New frmto_taskcheckcomment
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCOMMENT" Then
                Dim f As frmto_taskcomment
                f = New frmto_taskcomment
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "main" Then

            If RowItem.PartName.ToUpper = "TO_TASKINFO" Then
                Dim f As frmto_taskinfomain
                f = New frmto_taskinfomain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCHECKS" Then
                Dim f As frmto_taskchecksmain
                f = New frmto_taskchecksmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCHECKCOMMENT" Then
                Dim f As frmto_taskcheckcommentmain
                f = New frmto_taskcheckcommentmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCOMMENT" Then
                Dim f As frmto_taskcommentmain
                f = New frmto_taskcommentmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "adm" Then

            If RowItem.PartName.ToUpper = "TO_TASKINFO" Then
                Dim f As frmto_taskinfoadm
                f = New frmto_taskinfoadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCHECKS" Then
                Dim f As frmto_taskchecksadm
                f = New frmto_taskchecksadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCHECKCOMMENT" Then
                Dim f As frmto_taskcheckcommentadm
                f = New frmto_taskcheckcommentadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TO_TASKCOMMENT" Then
                Dim f As frmto_taskcommentadm
                f = New frmto_taskcommentadm
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
                Dim f As frmtotask
                f = New frmtotask
                f.Attach(DocItem, Me.GUIManager, FormReadOnly)
                ShowForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "main" Then
                Dim fmain As frmtotaskmain
                fmain = New frmtotaskmain
                fmain.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fmain.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fmain = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "adm" Then
                Dim fadm As frmtotaskadm
                fadm = New frmtotaskadm
                fadm.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fadm.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fadm = Nothing
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
            If Mode = "main" Then
                Return New Tabviewmain
            End If
            If Mode = "adm" Then
                Return New Tabviewadm
            End If
      Return New Tabview
    End Function

    Public Overrides Sub Dispose()
        ' do nothing
    End Sub




End Class
