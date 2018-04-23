using DevExpress.Example01.SearchBehavior;
using DevExpress.Mvvm;
using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DevExpress.Example01 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;
        }

        #region Items

        protected List<Task> _Items;

        public List<Task> Items {
            get {
                if(this._Items == null) {
                    this._Items = new List<Task>();
                    this._Items.Add(new Task() { Name = "Virginia Walsh", Company = "Fermentum Corp." });
                    this._Items.Add(new Task() { Name = "Nola Chapman", Company = "Auctor Velit Ltd" });
                    this._Items.Add(new Task() { Name = "Bert Evans", Company = "Lectus Pede Foundation" });
                    this._Items.Add(new Task() { Name = "Armando Collier", Company = "Nisl Incorporated" });
                    this._Items.Add(new Task() { Name = "Jasper Conley", Company = "Eleifend Corp." });
                    this._Items.Add(new Task() { Name = "Kamal Rosa", Company = "Etiam Imperdiet Dictum Ltd" });
                    this._Items.Add(new Task() { Name = "Julian Wilkins", Company = "Tempus Non Ltd" });
                    this._Items.Add(new Task() { Name = "Ignatius Henderson", Company = "Fringilla Company" });
                    this._Items.Add(new Task() { Name = "Desiree Mercer", Company = "Dui In Industries" });
                    this._Items.Add(new Task() { Name = "Tiger Santiago", Company = "Lacinia Orci Consectetuer Inc." });
                    this._Items.Add(new Task() { Name = "Philip Petersen", Company = "Egestas Urna LLP" });
                    this._Items.Add(new Task() { Name = "Mariam Medina", Company = "Orci Luctus Et Associates" });
                    this._Items.Add(new Task() { Name = "Kenneth Rollins", Company = "Nunc LLC" });
                    this._Items.Add(new Task() { Name = "Brittany Marks", Company = "Egestas Urna Justo Incorporated" });
                    this._Items.Add(new Task() { Name = "Scarlet Duncan", Company = "Quam A PC" });
                    this._Items.Add(new Task() { Name = "John Gonzales", Company = "Turpis Vitae Incorporated" });
                    this._Items.Add(new Task() { Name = "Meghan Whitney", Company = "Vehicula Et Rutrum Institute" });
                    this._Items.Add(new Task() { Name = "Hayden Delaney", Company = "Ac Mattis Limited" });
                    this._Items.Add(new Task() { Name = "Adria Richardson", Company = "Varius Ultrices Mauris Inc." });
                    this._Items.Add(new Task() { Name = "Dorothy Brock", Company = "Enim Commodo Hendrerit Institute" });
                    this._Items.Add(new Task() { Name = "Abigail Barnett", Company = "Quam Quis Foundation" });
                    this._Items.Add(new Task() { Name = "Shay Jefferson", Company = "Etiam Imperdiet Dictum PC" });
                    this._Items.Add(new Task() { Name = "Mufutau Dorsey", Company = "Habitant Morbi Tristique Limited" });
                    this._Items.Add(new Task() { Name = "Wing Galloway", Company = "Ut Lacus Nulla Consulting" });
                    this._Items.Add(new Task() { Name = "Minerva Houston", Company = "Lorem Luctus Ut LLP" });
                    this._Items.Add(new Task() { Name = "Lisandra Underwood", Company = "Aenean Gravida Nunc Company" });
                    this._Items.Add(new Task() { Name = "Palmer Case", Company = "Sem Corp." });
                    this._Items.Add(new Task() { Name = "Melinda Buchanan", Company = "Mollis Duis Corporation" });
                    this._Items.Add(new Task() { Name = "Hakeem Jarvis", Company = "Suspendisse Non Leo LLP" });
                    this._Items.Add(new Task() { Name = "Martha Hartman", Company = "Ipsum Dolor LLP" });
                    this._Items.Add(new Task() { Name = "Jamal Cameron", Company = "Nulla In Corporation" });
                    this._Items.Add(new Task() { Name = "Eric Burgess", Company = "Non Industries" });
                    this._Items.Add(new Task() { Name = "Sloane Spears", Company = "Rutrum Urna Industries" });
                    this._Items.Add(new Task() { Name = "Olympia Tyler", Company = "Mauris Quis Turpis Consulting" });
                    this._Items.Add(new Task() { Name = "Kim Palmer", Company = "Sagittis Felis Donec Ltd" });
                    this._Items.Add(new Task() { Name = "Palmer Hatfield", Company = "Aenean Egestas Associates" });
                    this._Items.Add(new Task() { Name = "Gannon Solis", Company = "Nonummy Ultricies Limited" });
                    this._Items.Add(new Task() { Name = "Yoshi Salinas", Company = "At Auctor Company" });
                    this._Items.Add(new Task() { Name = "Michael Schroeder", Company = "Nunc Institute" });
                    this._Items.Add(new Task() { Name = "Conan Perkins", Company = "Eu Associates" });
                    this._Items.Add(new Task() { Name = "Brynne Reid", Company = "Quisque Ornare Tortor Incorporated" });
                    this._Items.Add(new Task() { Name = "Veronica Rowland", Company = "A Corporation" });
                    this._Items.Add(new Task() { Name = "Clinton Horn", Company = "Ipsum Nunc Corp." });
                    this._Items.Add(new Task() { Name = "Jaden Petty", Company = "Enim Condimentum Foundation" });
                    this._Items.Add(new Task() { Name = "Xander Nicholson", Company = "Vel PC" });
                    this._Items.Add(new Task() { Name = "Christian Cantu", Company = "Ligula Company" });
                    this._Items.Add(new Task() { Name = "Francesca Garner", Company = "Ante PC" });
                    this._Items.Add(new Task() { Name = "Genevieve Walton", Company = "Eu Ltd" });
                    this._Items.Add(new Task() { Name = "Iris Dillard", Company = "Euismod In Associates" });
                    this._Items.Add(new Task() { Name = "Breanna Martin", Company = "Elit Dictum Eu LLC" });
                    this._Items.Add(new Task() { Name = "Dora Vazquez", Company = "Condimentum Eget Volutpat Corp." });
                    this._Items.Add(new Task() { Name = "Lenore Browning", Company = "Odio Consulting" });
                    this._Items.Add(new Task() { Name = "Nevada Ramsey", Company = "Malesuada Ltd" });
                    this._Items.Add(new Task() { Name = "Laith Pena", Company = "Pede Cras Company" });
                    this._Items.Add(new Task() { Name = "Clarke Lindsey", Company = "Risus Donec Associates" });
                    this._Items.Add(new Task() { Name = "Michelle Norton", Company = "Mi Inc." });
                    this._Items.Add(new Task() { Name = "Morgan Rivas", Company = "Ligula Eu Consulting" });
                    this._Items.Add(new Task() { Name = "Nissim Young", Company = "Tristique Inc." });
                    this._Items.Add(new Task() { Name = "Hedda Gonzalez", Company = "Eu Company" });
                    this._Items.Add(new Task() { Name = "Althea Holden", Company = "Erat Eget Foundation" });
                    this._Items.Add(new Task() { Name = "Jesse Lee", Company = "Ipsum Foundation" });
                    this._Items.Add(new Task() { Name = "Selma Alexander", Company = "Nulla In Tincidunt PC" });
                    this._Items.Add(new Task() { Name = "Olga Byers", Company = "Ullamcorper Inc." });
                    this._Items.Add(new Task() { Name = "Adena Burgess", Company = "Donec LLP" });
                    this._Items.Add(new Task() { Name = "Herrod Lucas", Company = "Eleifend Nec Malesuada Associates" });
                    this._Items.Add(new Task() { Name = "Noah Stone", Company = "Magnis Dis Parturient Ltd" });
                    this._Items.Add(new Task() { Name = "Jocelyn Cardenas", Company = "Eros Associates" });
                    this._Items.Add(new Task() { Name = "Ahmed Lawson", Company = "Ut Corp." });
                    this._Items.Add(new Task() { Name = "May Flynn", Company = "Nisi Inc." });
                    this._Items.Add(new Task() { Name = "Mariam Hampton", Company = "Lectus Cum Sociis Incorporated" });
                    this._Items.Add(new Task() { Name = "Mariko Mcconnell", Company = "Imperdiet Ullamcorper LLC" });
                    this._Items.Add(new Task() { Name = "Lucius Caldwell", Company = "Consectetuer Rhoncus Nullam Foundation" });
                    this._Items.Add(new Task() { Name = "Iona Nguyen", Company = "Varius Orci In Ltd" });
                    this._Items.Add(new Task() { Name = "Leigh Browning", Company = "Aliquet Odio Etiam Inc." });
                    this._Items.Add(new Task() { Name = "Quemby Marks", Company = "At Pretium Aliquet Ltd" });
                    this._Items.Add(new Task() { Name = "Blaze Wilcox", Company = "Curabitur Massa Vestibulum Incorporated" });
                    this._Items.Add(new Task() { Name = "Leila Gill", Company = "Lacus Aliquam Foundation" });
                    this._Items.Add(new Task() { Name = "Astra Carr", Company = "Quam Foundation" });
                    this._Items.Add(new Task() { Name = "Vielka Atkinson", Company = "Ante Corp." });
                    this._Items.Add(new Task() { Name = "Caryn Mason", Company = "Elit Foundation" });
                    this._Items.Add(new Task() { Name = "Drake Stephenson", Company = "Donec Sollicitudin Corporation" });
                    this._Items.Add(new Task() { Name = "Glenna Harrison", Company = "Phasellus At Company" });
                    this._Items.Add(new Task() { Name = "Morgan Knapp", Company = "Eget Ipsum Incorporated" });
                    this._Items.Add(new Task() { Name = "Connor Payne", Company = "Semper Nam Tempor LLP" });
                    this._Items.Add(new Task() { Name = "Richard Baker", Company = "Phasellus LLP" });
                    this._Items.Add(new Task() { Name = "Mia Fulton", Company = "Vitae Consulting" });
                    this._Items.Add(new Task() { Name = "Melyssa Robertson", Company = "Malesuada Fames Company" });
                    this._Items.Add(new Task() { Name = "Ahmed Humphrey", Company = "Sed Ltd" });
                    this._Items.Add(new Task() { Name = "Rashad Merrill", Company = "Laoreet Lectus Company" });
                    this._Items.Add(new Task() { Name = "Fitzgerald Hayden", Company = "Egestas Duis Corporation" });
                    this._Items.Add(new Task() { Name = "Mollie Holt", Company = "Ipsum Suspendisse Sagittis PC" });
                    this._Items.Add(new Task() { Name = "Olga Jacobs", Company = "Morbi Sit Amet Industries" });
                    this._Items.Add(new Task() { Name = "Ray Foreman", Company = "Quam Company" });
                    this._Items.Add(new Task() { Name = "Alexis Gallagher", Company = "Pellentesque LLP" });
                    this._Items.Add(new Task() { Name = "Yolanda Duke", Company = "Scelerisque LLP" });
                    this._Items.Add(new Task() { Name = "Hilel Barnett", Company = "Pharetra Felis Inc." });
                    this._Items.Add(new Task() { Name = "Roth Atkinson", Company = "Vulputate Velit Foundation" });
                    this._Items.Add(new Task() { Name = "Shea Stafford", Company = "Etiam Foundation" });
                    this._Items.Add(new Task() { Name = "Duncan Booker", Company = "Non Feugiat Corporation" });
                    this._Items.Add(new Task() { Name = "Lucy Rodgers", Company = "Mollis Non Institute" });
                }

                return this._Items;
            }
        }

        #endregion Items

    }
}