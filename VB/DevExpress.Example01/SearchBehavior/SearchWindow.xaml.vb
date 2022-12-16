Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows

Namespace DevExpress.Example01.SearchBehavior

    Public Partial Class SearchWindow
        Inherits DXWindow
        Implements INotifyPropertyChanged

#Region "Classes"
        Protected Class CellNode

            Public Sub New(ByVal rowHandle As Integer, ByVal column As ColumnBase)
                Me.RowHandle = rowHandle
                Me.Column = column
            End Sub

            Public Property RowHandle As Integer

            Public Property Column As ColumnBase
        End Class

#End Region  ' Classes
        Public Sub New(ByVal gridControl As GridControl)
            If gridControl Is Nothing Then
                Throw New ArgumentNullException("gridControl")
            End If

            _Grid = gridControl
            Me.InitializeComponent()
            DataContext = Me
            AddHandler Activated, AddressOf WindowActivated
            AddHandler IsVisibleChanged, AddressOf ThisIsVisibleChanged
            AddHandler _Grid.FilterChanged, AddressOf GridFilterChanged
            AddHandler ThemeManager.ThemeChanged, AddressOf ThemeChanged
        End Sub

        Protected Sub ThemeChanged(ByVal sender As DependencyObject, ByVal e As ThemeChangedRoutedEventArgs)
            Dim theme = ThemeManager.GetTheme(_Grid)
            ThemeManager.SetTheme(Me, theme)
        End Sub

        Protected Sub GridFilterChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
            If IsVisible Then
                Search()
            End If
        End Sub

        Protected lastSearch As String = String.Empty

        Protected Sub ThisIsVisibleChanged(ByVal sender As Object, ByVal e As DependencyPropertyChangedEventArgs)
            ThemeChanged(Nothing, Nothing)
            If Equals(SearchText, Nothing) Then
                SearchText = String.Empty
            End If

            If IsVisible Then
                SearchText = lastSearch
            Else
                lastSearch = SearchText
                SearchText = String.Empty
            End If

            Search()
        End Sub

#Region "Fields"
        Protected _FoundCells As ObservableCollection(Of CellNode) = New ObservableCollection(Of CellNode)()

        Protected _SearchText As String

        Protected _Grid As GridControl

        Protected _CurrentCell As Integer

#End Region  ' Fields
#Region "Properties"
        Public ReadOnly Property TotalEntries As Integer
            Get
                Return _FoundCells.Count
            End Get
        End Property

        Public Property SearchText As String
            Get
                Return _SearchText
            End Get

            Set(ByVal value As String)
                _SearchText = value
                OnPropertyChanged("SearchText")
                Search()
                OnPropertyChanged("TotalEntries")
            End Set
        End Property

#End Region  ' Properties
#Region "Commands"
#Region "Next"
        Protected _Next As DelegateCommand

        Public ReadOnly Property [Next] As DelegateCommand
            Get
                If _Next Is Nothing Then
                    _Next = New DelegateCommand(AddressOf NextExecute, AddressOf NextCanExecute)
                End If

                Return _Next
            End Get
        End Property

        Protected Sub NextExecute()
            If _CurrentCell + 1 < TotalEntries Then
                _CurrentCell += 1
                SetActiveCell()
            End If
        End Sub

        Protected Function NextCanExecute() As Boolean
            Dim result As Boolean = True
            result = result And Not Equals(SearchText, String.Empty)
            Return result
        End Function

#End Region  ' Next
#Region "Previous"
        Protected _Previous As DelegateCommand

        Public ReadOnly Property Previous As DelegateCommand
            Get
                If _Previous Is Nothing Then
                    _Previous = New DelegateCommand(AddressOf PreviousExecute, AddressOf PreviousCanExecute)
                End If

                Return _Previous
            End Get
        End Property

        Protected Sub PreviousExecute()
            If _CurrentCell > 0 Then
                _CurrentCell -= 1
                SetActiveCell()
            End If
        End Sub

        Protected Function PreviousCanExecute() As Boolean
            Dim result As Boolean = True
            result = result And Not Equals(SearchText, String.Empty)
            Return result
        End Function

#End Region  ' Previous
#Region "Close"
        Protected _Close As DelegateCommand

        Public ReadOnly Property CloseCommand As DelegateCommand
            Get
                If _Close Is Nothing Then
                    _Close = New DelegateCommand(AddressOf CloseExecute)
                End If

                Return _Close
            End Get
        End Property

        Protected Sub CloseExecute()
            _Grid.View.SearchString = String.Empty
            Hide()
        End Sub

#End Region  ' Close
#End Region  ' Commands
#Region "Events"
        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

#End Region  ' Events
#Region "Methods"
        Protected Sub Search()
            _FoundCells.Clear()
            _CurrentCell = 0
            Dim searchText As String = Me.SearchText.ToLower()
            If Not(TypeOf _Grid.View Is TableView) Then
                Return
            End If

            Dim tableView As TableView = TryCast(_Grid.View, TableView)
            tableView.SearchString = Me.SearchText
            If Equals(Me.SearchText, String.Empty) Then
                Return
            End If

            Dim rowHandles As List(Of Integer) = GetDataRowHandles()
            For Each rowHandle In rowHandles
                For Each col In _Grid.Columns
                    Dim cellText = _Grid.GetCellDisplayText(rowHandle, col).ToLower()
                    If cellText.Contains(searchText) Then
                        _FoundCells.Add(New CellNode(rowHandle, col))
                    End If
                Next
            Next

            If TotalEntries > 0 Then
                SetActiveCell()
            End If

            OnPropertyChanged("TotalEntries")
        End Sub

        Protected Sub SetActiveCell()
            _Grid.View.FocusedRowHandle = _FoundCells(_CurrentCell).RowHandle
            _Grid.CurrentColumn = _FoundCells(_CurrentCell).Column
        End Sub

        Protected Function GetDataRowHandles() As List(Of Integer)
            Dim rowHandles As List(Of Integer) = New List(Of Integer)()
            Dim i As Integer = -1
            While Threading.Interlocked.Increment(i) < _Grid.VisibleRowCount
                Dim rowHandle As Integer = _Grid.GetRowHandleByVisibleIndex(i)
                If _Grid.IsGroupRowHandle(rowHandle) Then
                    If Not _Grid.IsGroupRowExpanded(rowHandle) Then
                        rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle))
                    End If
                Else
                    rowHandles.Add(rowHandle)
                End If
            End While

            Return rowHandles
        End Function

        Protected Function GetDataRowHandlesInGroup(ByVal groupRowHandle As Integer) As List(Of Integer)
            Dim rowHandles As List(Of Integer) = New List(Of Integer)()
            Dim i As Integer = -1
            While Threading.Interlocked.Increment(i) < _Grid.GetChildRowCount(groupRowHandle)
                Dim rowHandle As Integer = _Grid.GetChildRowHandle(groupRowHandle, i)
                If _Grid.IsGroupRowHandle(rowHandle) Then
                    rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle))
                Else
                    rowHandles.Add(rowHandle)
                End If
            End While

            Return rowHandles
        End Function

        Protected Sub SearchWindowClosing(ByVal sender As Object, ByVal e As CancelEventArgs)
            CloseCommand.Execute(Nothing)
            e.Cancel = True
        End Sub

        Protected Sub WindowActivated(ByVal sender As Object, ByVal args As EventArgs)
            _Grid.View.SearchString = SearchText
            Me.txtFind.Focus()
        End Sub

        Protected Overloads Sub OnPropertyChanged(ByVal info As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(info))
        End Sub
#End Region  ' Methods
    End Class
End Namespace
