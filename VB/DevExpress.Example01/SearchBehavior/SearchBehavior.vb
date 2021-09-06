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

		Public ReadOnly Property Search() As DelegateCommand
			Get
				If Me._Search Is Nothing Then
					Me._Search = New DelegateCommand(AddressOf Me.SearchExecute)
				End If

				Return Me._Search
			End Get
		End Property

		Protected Sub SearchExecute()
			If Me._SearchWindow Is Nothing Then
				Me._SearchWindow = New SearchWindow(Me.AssociatedObject)
				Me._SearchWindow.Owner = Application.Current.MainWindow

			End If

			Me._SearchWindow.Show()
		End Sub

		#End Region ' SearchCommand

		#Region "HideSearch"

		Protected _HideSearch As DelegateCommand

		Public ReadOnly Property HideSearch() As DelegateCommand
			Get
				If Me._HideSearch Is Nothing Then
					Me._HideSearch = New DelegateCommand(AddressOf Me.HideSearchExecute)
				End If

				Return Me._HideSearch
			End Get
		End Property

		Protected Sub HideSearchExecute()
			If Me._SearchWindow IsNot Nothing Then
				Me._SearchWindow.Close()
			End If
		End Sub

		#End Region ' HideSearch

		#End Region ' Commands

		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			Me.AssociatedObject.InputBindings.Add(New KeyBinding(Me.Search, New KeyGesture(Key.F, ModifierKeys.Control)))
			Me.AssociatedObject.InputBindings.Add(New KeyBinding(Me.HideSearch, New KeyGesture(Key.Escape)))
		End Sub

	End Class
End Namespace
