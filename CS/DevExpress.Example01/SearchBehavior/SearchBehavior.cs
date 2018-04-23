using DevExpress.Mvvm;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System.Windows;
using System.Windows.Input;

namespace DevExpress.Example01.SearchBehavior {
    
    public class SearchBehavior : Behavior<GridControl> {

        protected SearchWindow _SearchWindow;

        #region Commands

        #region SearchCommand

        protected DelegateCommand _Search;

        public DelegateCommand Search {
            get {
                if(this._Search == null) {
                    this._Search = new DelegateCommand(this.SearchExecute);
                }

                return this._Search;
            }
        }

        protected void SearchExecute() {
            if(this._SearchWindow == null) {
                this._SearchWindow = new SearchWindow(this.AssociatedObject);
                this._SearchWindow.Owner = Application.Current.MainWindow;

            }

            this._SearchWindow.Show();
        }

        #endregion SearchCommand

        #region HideSearch

        protected DelegateCommand _HideSearch;

        public DelegateCommand HideSearch {
            get {
                if(this._HideSearch == null) {
                    this._HideSearch = new DelegateCommand(this.HideSearchExecute);
                }

                return this._HideSearch;
            }
        }

        protected void HideSearchExecute() {
            if(this._SearchWindow != null) {
                this._SearchWindow.Close();
            }
        }

        #endregion HideSearch
 
        #endregion Commands

        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.InputBindings.Add(new KeyBinding(this.Search, new KeyGesture(Key.F, ModifierKeys.Control)));
            this.AssociatedObject.InputBindings.Add(new KeyBinding(this.HideSearch, new KeyGesture(Key.Escape)));
        }

    }
}
