Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.Windows
Imports System.Windows.Input

Namespace DevExpress.Example01.SearchBehavior

    Public Class SearchBehavior
        Inherits Behavior(Of GridControl)

        Protected _SearchWindow As SearchWindow

#Region "Commands"
#Region "SearchCommand"
        Protected _Search As DelegateCommand

        Public ReadOnly Property Search As DelegateCommand
            Get
                If _Search Is Nothing Then
                    _Search = New DelegateCommand(AddressOf SearchExecute)
                End If

                Return _Search
            End Get
        End Property

        Protected Sub SearchExecute()
            If _SearchWindow Is Nothing Then
                _SearchWindow = New SearchWindow(AssociatedObject)
                _SearchWindow.Owner = Application.Current.MainWindow
            End If

            _SearchWindow.Show()
        End Sub

#End Region  ' SearchCommand
#Region "HideSearch"
        Protected _HideSearch As DelegateCommand

        Public ReadOnly Property HideSearch As DelegateCommand
            Get
                If _HideSearch Is Nothing Then
                    _HideSearch = New DelegateCommand(AddressOf HideSearchExecute)
                End If

                Return _HideSearch
            End Get
        End Property

        Protected Sub HideSearchExecute()
            If _SearchWindow IsNot Nothing Then
                _SearchWindow.Close()
            End If
        End Sub

#End Region  ' HideSearch
#End Region  ' Commands
        Protected Overrides Sub OnAttached()
            MyBase.OnAttached()
            AssociatedObject.InputBindings.Add(New KeyBinding(Search, New KeyGesture(Key.F, ModifierKeys.Control)))
            AssociatedObject.InputBindings.Add(New KeyBinding(HideSearch, New KeyGesture(Key.Escape)))
        End Sub
    End Class
End Namespace
