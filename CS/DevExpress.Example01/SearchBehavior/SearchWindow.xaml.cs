using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Documents;

namespace DevExpress.Example01.SearchBehavior {
    
    public partial class SearchWindow : DXWindow, INotifyPropertyChanged {

        #region Classes

        protected class CellNode {

            public CellNode(int rowHandle, ColumnBase column) { this.RowHandle = rowHandle; this.Column = column; }

            public int RowHandle { get; set; }

            public ColumnBase Column { get; set; }
        }

        #endregion Classes

        public SearchWindow(GridControl gridControl) {
            if(gridControl == null) {
                throw new ArgumentNullException("gridControl");
            }
            
            this._Grid = gridControl;
            InitializeComponent();
            this.DataContext = this;
            this.Activated += this.WindowActivated;
            this.IsVisibleChanged += ThisIsVisibleChanged;
            this._Grid.FilterChanged += GridFilterChanged;
            ThemeManager.ThemeChanged += ThemeChanged;
        }

        protected void ThemeChanged(DependencyObject sender, ThemeChangedRoutedEventArgs e) {
            var theme = ThemeManager.GetTheme(this._Grid);
            ThemeManager.SetTheme(this, theme);
        }

        protected void GridFilterChanged(object sender, RoutedEventArgs e) {
            if(this.IsVisible) {
                this.Search();
            }
        }

        protected string lastSearch = string.Empty;

        protected void ThisIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) {
            this.ThemeChanged(null, null);
            if(this.SearchText == null) {
                this.SearchText = string.Empty;
            }

            if(this.IsVisible) {
                this.SearchText = this.lastSearch;
            } else {
                this.lastSearch = this.SearchText;
                this.SearchText = string.Empty;
            }
            this.Search();
        }

        #region Fields

        protected ObservableCollection<CellNode> _FoundCells = new ObservableCollection<CellNode>();

        protected string _SearchText;

        protected GridControl _Grid;

        protected int _CurrentCell;

        #endregion Fields

        #region Properties

        public int TotalEntries {
            get {
                return this._FoundCells.Count;
            }
        }

        public string SearchText {
            get {
                return this._SearchText;
            }

            set {
                this._SearchText = value;
                this.OnPropertyChanged("SearchText");
                this.Search();
                this.OnPropertyChanged("TotalEntries");
            }
        }

        #endregion Properties

        #region Commands

        #region Next

        protected DelegateCommand _Next;

        public DelegateCommand Next {
            get {
                if(this._Next == null) {
                    this._Next = new DelegateCommand(this.NextExecute, this.NextCanExecute);
                }

                return this._Next;
            }
        }

        protected void NextExecute() {
            if(this._CurrentCell + 1 < this.TotalEntries) {
                this._CurrentCell++;
                this.SetActiveCell();
            }
        }

        protected bool NextCanExecute() {
            bool result = true;
            result &= this.SearchText != String.Empty;
            return result;
        }

        #endregion Next

        #region Previous

        protected DelegateCommand _Previous;

        public DelegateCommand Previous {
            get {
                if(this._Previous == null) {
                    this._Previous = new DelegateCommand(this.PreviousExecute, this.PreviousCanExecute);
                }

                return this._Previous;
            }
        }

        protected void PreviousExecute() {
            if(this._CurrentCell > 0) {
                this._CurrentCell--;
                this.SetActiveCell();
            }
        }

        protected bool PreviousCanExecute() {
            bool result = true;
            result &= this.SearchText != String.Empty;
            return result;
        }

        #endregion Previous

        #region Close

        protected DelegateCommand _Close;

        public DelegateCommand CloseCommand {
            get {
                if(this._Close == null) {
                    this._Close = new DelegateCommand(this.CloseExecute);
                }

                return this._Close;
            }
        }

        protected void CloseExecute() {
            this._Grid.View.SearchString = string.Empty;
            this.Hide();
        }

        #endregion Close

        #endregion Commands

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Methods

        protected void Search() {
            this._FoundCells.Clear();
            this._CurrentCell = 0;
            string searchText = this.SearchText.ToLower();
            if(!(this._Grid.View is TableView)) { return; }

            TableView tableView = (this._Grid.View as TableView);
            tableView.SearchString = this.SearchText;

            if(this.SearchText == string.Empty) { return; }

            List<int> rowHandles = this.GetDataRowHandles();
            foreach(var rowHandle in rowHandles) {
                foreach(var col in this._Grid.Columns) {
                    var cellText = this._Grid.GetCellDisplayText(rowHandle, col).ToLower();
                    if(cellText.Contains(searchText)) {
                        this._FoundCells.Add(new CellNode(rowHandle, col));
                    }
                }
            }

            if(this.TotalEntries > 0) { this.SetActiveCell(); }
            this.OnPropertyChanged("TotalEntries");
        }

        protected void SetActiveCell() {
            this._Grid.View.FocusedRowHandle = this._FoundCells[this._CurrentCell].RowHandle;
            this._Grid.CurrentColumn = this._FoundCells[this._CurrentCell].Column;
        }

        protected List<int> GetDataRowHandles() {
            List<int> rowHandles = new List<int>();
            int i = -1;
            while(++i < this._Grid.VisibleRowCount) {
                int rowHandle = this._Grid.GetRowHandleByVisibleIndex(i);
                if(this._Grid.IsGroupRowHandle(rowHandle)) {
                    if(!this._Grid.IsGroupRowExpanded(rowHandle)) {
                        rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle));
                    }
                } else
                    rowHandles.Add(rowHandle);
            }

            return rowHandles;
        }

        protected List<int> GetDataRowHandlesInGroup(int groupRowHandle) {
            List<int> rowHandles = new List<int>();
            int i = -1;
            while(++i < this._Grid.GetChildRowCount(groupRowHandle)) {
                int rowHandle = this._Grid.GetChildRowHandle(groupRowHandle, i);
                if(this._Grid.IsGroupRowHandle(rowHandle)) {
                    rowHandles.AddRange(GetDataRowHandlesInGroup(rowHandle));
                } else
                    rowHandles.Add(rowHandle);
            }

            return rowHandles;
        }

        protected void SearchWindowClosing(object sender, CancelEventArgs e) {
            this.CloseCommand.Execute(null);
            e.Cancel = true;
        }

        protected void WindowActivated(object sender, EventArgs args) {
            this._Grid.View.SearchString = this.SearchText;
            txtFind.Focus();
        }

        protected void OnPropertyChanged(string info) {
            if(this.PropertyChanged != null) {
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion Methods
    }
}
