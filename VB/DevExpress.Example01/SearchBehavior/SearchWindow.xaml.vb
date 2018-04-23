Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Documents

Namespace DevExpress.Example01.SearchBehavior

	Partial Public Class SearchWindow
		Inherits DXWindow
		Implements INotifyPropertyChanged

		#Region "Classes"

		Protected Class CellNode

			Public Sub New(ByVal rowHandle As Integer, ByVal column As ColumnBase)
				Me.RowHandle = rowHandle
				Me.Column = column
			End Sub

			Private privateRowHandle As Integer
			Public Property RowHandle() As Integer
				Get
					Return privateRowHandle
				End Get
				Set(ByVal value As Integer)
					privateRowHandle = value
				End Set
			End Property

			Private privateColumn As ColumnBase
			Public Property Column() As ColumnBase
				Get
					Return privateColumn
				End Get
				Set(ByVal value As ColumnBase)
					privateColumn = value
				End Set
			End Property
		End Class

		#End Region ' Classes

		Public Sub New(ByVal gridControl As GridControl)
			If gridControl Is Nothing Then
				Throw New ArgumentNullException("gridControl")
			End If

			Me._Grid = gridControl
			InitializeComponent()
			Me.DataContext = Me
			AddHandler Me.Activated, AddressOf WindowActivated
			AddHandler Me.IsVisibleChanged, AddressOf ThisIsVisibleChanged
			AddHandler Me._Grid.FilterChanged, AddressOf GridFilterChanged
			AddHandler ThemeManager.ThemeChanged, AddressOf ThemeChanged
		End Sub

		Protected Sub ThemeChanged(ByVal sender As DependencyObject, ByVal e As ThemeChangedRoutedEventArgs)
			Dim theme = ThemeManager.GetTheme(Me._Grid)
			ThemeManager.SetTheme(Me, theme)
		End Sub

		Protected Sub GridFilterChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If Me.IsVisible Then
				Me.Search()
			End If
		End Sub

		Protected lastSearch As String = String.Empty

		Protected Sub ThisIsVisibleChanged(ByVal sender As Object, ByVal e As DependencyPropertyChangedEventArgs)
			Me.ThemeChanged(Nothing, Nothing)
			If Me.SearchText Is Nothing Then
				Me.SearchText = String.Empty
			End If

			If Me.IsVisible Then
				Me.SearchText = Me.lastSearch
			Else
				Me.lastSearch = Me.SearchText
				Me.SearchText = String.Empty
			End If
			Me.Search()
		End Sub

		#Region "Fields"

		Protected _FoundCells As New ObservableCollection(Of CellNode)()

		Protected _SearchText As String

		Protected _Grid As GridControl

		Protected _CurrentCell As Integer

		#End Region ' Fields

		#Region "Properties"

		Public ReadOnly Property TotalEntries() As Integer
			Get
				Return Me._FoundCells.Count
			End Get
		End Property

		Public Property SearchText() As String
			Get
				Return Me._SearchText
			End Get

			Set(ByVal value As String)
				Me._SearchText = value
				Me.OnPropertyChanged("SearchText")
				Me.Search()
				Me.OnPropertyChanged("TotalEntries")
			End Set
		End Property

		#End Region ' Properties

		#Region "Commands"

		#Region "Next"

		Protected _Next As DelegateCommand

		Public ReadOnly Property [Next]() As DelegateCommand
			Get
				If Me._Next Is Nothing Then
					Me._Next = New DelegateCommand(AddressOf Me.NextExecute, AddressOf Me.NextCanExecute)
				End If

				Return Me._Next
			End Get
		End Property

		Protected Sub NextExecute()
			If Me._CurrentCell + 1 < Me.TotalEntries Then
				Me._CurrentCell += 1
				Me.SetActiveCell()
			End If
		End Sub

		Protected Function NextCanExecute() As Boolean
			Dim result As Boolean = True
			result = result And Me.SearchText <> String.Empty
			Return result
		End Function

		#End Region ' Next

		#Region "Previous"

		Protected _Previous As DelegateCommand

		Public ReadOnly Property Previous() As DelegateCommand
			Get
				If Me._Previous Is Nothing Then
					Me._Previous = New DelegateCommand(AddressOf Me.PreviousExecute, AddressOf Me.PreviousCanExecute)
				End If

				Return Me._Previous
			End Get
		End Property

		Protected Sub PreviousExecute()
			If Me._CurrentCell > 0 Then
				Me._CurrentCell -= 1
				Me.SetActiveCell()
			End If
		End Sub

		Protected Function PreviousCanExecute() As Boolean
			Dim result As Boolean = True
			result = result And Me.SearchText <> String.Empty
			Return result
		End Function

		#End Region ' Previous

		#Region "Close"

		Protected _Close As DelegateCommand

		Public ReadOnly Property CloseCommand() As DelegateCommand
			Get
				If Me._Close Is Nothing Then
					Me._Close = New DelegateCommand(AddressOf Me.CloseExecute)
				End If

				Return Me._Close
			End Get
		End Property

		Protected Sub CloseExecute()
			Me._Grid.View.SearchString = String.Empty
			Me.Hide()
		End Sub

		#End Region ' Close

		#End Region ' Commands

		#Region "Events"

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		#End Region ' Events

		#Region "Methods"

		Protected Sub Search()
			Me._FoundCells.Clear()
			Me._CurrentCell = 0
			Dim searchText As String = Me.SearchText.ToLower()
			If Not(TypeOf Me._Grid.View Is TableView) Then
				Return
			End If

			Dim tableView As TableView = (TryCast(Me._Grid.View, TableView))
			tableView.SearchString = Me.SearchText

			If Me.SearchText = String.Empty Then
				Return
			End If

			Dim rowHandles As List(Of Integer) = Me.GetDataRowHandles()
			For Each rowHandle In rowHandles
				For Each col In Me._Grid.Columns
					Dim cellText = Me._Grid.GetCellDisplayText(rowHandle, col).ToLower()
					If cellText.Contains(searchText) Then
						Me._FoundCells.Add(New CellNode(rowHandle, col))
					End If
				Next col
			Next rowHandle

			If Me.TotalEntries > 0 Then
				Me.SetActiveCell()
			End If
			Me.OnPropertyChanged("TotalEntries")
		End Sub

		Protected Sub SetActiveCell()
			Me._Grid.View.FocusedRowHandle = Me._FoundCells(Me._CurrentCell).RowHandle
			Me._Grid.CurrentColumn = Me._FoundCells(Me._CurrentCell).Column
		End Sub

		Protected Function GetDataRowHandles() As List(Of Integer)
			Dim rowHandles As New List(Of Integer)()
			Dim i As Integer = -1
'INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
'ORIGINAL LINE: while(++i < Me._Grid.VisibleRowCount)
			Do While ++i < Me._Grid.VisibleRowCount
				Dim rowHandle As Integer = Me._Grid.GetRowHandleByVisibleIndex(i)
				If Me._Grid.IsGroupRowHandle(rowHandle) Then
					If (Not Me._Grid.IsGroupRowExpanded(rowHandle)) Then
						rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle))
					End If
				Else
					rowHandles.Add(rowHandle)
				End If
			Loop

			Return rowHandles
		End Function

		Protected Function GetDataRowHandlesInGroup(ByVal groupRowHandle As Integer) As List(Of Integer)
			Dim rowHandles As New List(Of Integer)()
			Dim i As Integer = -1
'INSTANT VB TODO TASK: Assignments within expressions are not supported in VB.NET
'ORIGINAL LINE: while(++i < Me._Grid.GetChildRowCount(groupRowHandle))
			Do While ++i < Me._Grid.GetChildRowCount(groupRowHandle)
				Dim rowHandle As Integer = Me._Grid.GetChildRowHandle(groupRowHandle, i)
				If Me._Grid.IsGroupRowHandle(rowHandle) Then
					rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle))
				Else
					rowHandles.Add(rowHandle)
				End If
			Loop

			Return rowHandles
		End Function

		Protected Sub SearchWindowClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
			Me.CloseCommand.Execute(Nothing)
			e.Cancel = True
		End Sub

		Protected Sub WindowActivated(ByVal sender As Object, ByVal args As EventArgs)
			Me._Grid.View.SearchString = Me.SearchText
			txtFind.Focus()
		End Sub

		Protected Sub OnPropertyChanged(ByVal info As String)
			If Me.PropertyChangedEvent IsNot Nothing Then
				RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
			End If
		End Sub

		#End Region ' Methods
	End Class
End Namespace
