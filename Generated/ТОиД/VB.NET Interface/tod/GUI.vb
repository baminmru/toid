
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
        Return "tod"
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

            If RowItem.PartName.ToUpper = "TOD_MODEL" Then
                Dim f As frmtod_model
                f = New frmtod_model
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_ST" Then
                Dim f As frmtod_st
                f = New frmtod_st
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_SYSTEM" Then
                Dim f As frmtod_system
                f = New frmtod_system
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_EDIZM" Then
                Dim f As frmtod_edizm
                f = New frmtod_edizm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_BUG" Then
                Dim f As frmtod_bug
                f = New frmtod_bug
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_VALTYPE" Then
                Dim f As frmtod_valtype
                f = New frmtod_valtype
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_MATERIAL" Then
                Dim f As frmtod_material
                f = New frmtod_material
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_TRAND" Then
                Dim f As frmtod_trand
                f = New frmtod_trand
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_FACTORY" Then
                Dim f As frmtod_factory
                f = New frmtod_factory
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_BUILDING" Then
                Dim f As frmtod_building
                f = New frmtod_building
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_OPROLE" Then
                Dim f As frmtod_oprole
                f = New frmtod_oprole
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "main" Then

            If RowItem.PartName.ToUpper = "TOD_MODEL" Then
                Dim f As frmtod_modelmain
                f = New frmtod_modelmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_ST" Then
                Dim f As frmtod_stmain
                f = New frmtod_stmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_SYSTEM" Then
                Dim f As frmtod_systemmain
                f = New frmtod_systemmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_EDIZM" Then
                Dim f As frmtod_edizmmain
                f = New frmtod_edizmmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_BUG" Then
                Dim f As frmtod_bugmain
                f = New frmtod_bugmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_VALTYPE" Then
                Dim f As frmtod_valtypemain
                f = New frmtod_valtypemain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_MATERIAL" Then
                Dim f As frmtod_materialmain
                f = New frmtod_materialmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_TRAND" Then
                Dim f As frmtod_trandmain
                f = New frmtod_trandmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_FACTORY" Then
                Dim f As frmtod_factorymain
                f = New frmtod_factorymain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_BUILDING" Then
                Dim f As frmtod_buildingmain
                f = New frmtod_buildingmain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_OPROLE" Then
                Dim f As frmtod_oprolemain
                f = New frmtod_oprolemain
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

        End If
        If Mode = "adm" Then

            If RowItem.PartName.ToUpper = "TOD_MODEL" Then
                Dim f As frmtod_modeladm
                f = New frmtod_modeladm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_ST" Then
                Dim f As frmtod_stadm
                f = New frmtod_stadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_SYSTEM" Then
                Dim f As frmtod_systemadm
                f = New frmtod_systemadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_EDIZM" Then
                Dim f As frmtod_edizmadm
                f = New frmtod_edizmadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_BUG" Then
                Dim f As frmtod_bugadm
                f = New frmtod_bugadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_VALTYPE" Then
                Dim f As frmtod_valtypeadm
                f = New frmtod_valtypeadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_MATERIAL" Then
                Dim f As frmtod_materialadm
                f = New frmtod_materialadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_TRAND" Then
                Dim f As frmtod_trandadm
                f = New frmtod_trandadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_FACTORY" Then
                Dim f As frmtod_factoryadm
                f = New frmtod_factoryadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_BUILDING" Then
                Dim f As frmtod_buildingadm
                f = New frmtod_buildingadm
                f.Attach(RowItem, Me.GUIManager,FormReadOnly)
                ShowPartEditForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If

            If RowItem.PartName.ToUpper = "TOD_OPROLE" Then
                Dim f As frmtod_oproleadm
                f = New frmtod_oproleadm
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
                Dim f As frmtod
                f = New frmtod
                f.Attach(DocItem, Me.GUIManager, FormReadOnly)
                ShowForm = (f.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                f = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "main" Then
                Dim fmain As frmtodmain
                fmain = New frmtodmain
                fmain.Attach(DocItem, Me.GUIManager,FormReadOnly)
                ShowForm = (fmain.ShowDialog() = System.Windows.Forms.DialogResult.OK)
                fmain = Nothing
            End If
        End If
        If DocItem.TypeName.ToUpper = TypeName.ToUpper() Then
            If mode = "adm" Then
                Dim fadm As frmtodadm
                fadm = New frmtodadm
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
