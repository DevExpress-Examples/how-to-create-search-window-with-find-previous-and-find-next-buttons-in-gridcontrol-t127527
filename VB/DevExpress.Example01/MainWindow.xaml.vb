Imports Microsoft.VisualBasic
Imports DevExpress.Example01.SearchBehavior
Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Core
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace DevExpress.Example01
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			Me.DataContext = Me
		End Sub

		#Region "Items"

		Protected _Items As List(Of Task)

		Public ReadOnly Property Items() As List(Of Task)
			Get
				If Me._Items Is Nothing Then
					Me._Items = New List(Of Task)()
					Me._Items.Add(New Task() With {.Name = "Virginia Walsh", .Company = "Fermentum Corp."})
					Me._Items.Add(New Task() With {.Name = "Nola Chapman", .Company = "Auctor Velit Ltd"})
					Me._Items.Add(New Task() With {.Name = "Bert Evans", .Company = "Lectus Pede Foundation"})
					Me._Items.Add(New Task() With {.Name = "Armando Collier", .Company = "Nisl Incorporated"})
					Me._Items.Add(New Task() With {.Name = "Jasper Conley", .Company = "Eleifend Corp."})
					Me._Items.Add(New Task() With {.Name = "Kamal Rosa", .Company = "Etiam Imperdiet Dictum Ltd"})
					Me._Items.Add(New Task() With {.Name = "Julian Wilkins", .Company = "Tempus Non Ltd"})
					Me._Items.Add(New Task() With {.Name = "Ignatius Henderson", .Company = "Fringilla Company"})
					Me._Items.Add(New Task() With {.Name = "Desiree Mercer", .Company = "Dui In Industries"})
					Me._Items.Add(New Task() With {.Name = "Tiger Santiago", .Company = "Lacinia Orci Consectetuer Inc."})
					Me._Items.Add(New Task() With {.Name = "Philip Petersen", .Company = "Egestas Urna LLP"})
					Me._Items.Add(New Task() With {.Name = "Mariam Medina", .Company = "Orci Luctus Et Associates"})
					Me._Items.Add(New Task() With {.Name = "Kenneth Rollins", .Company = "Nunc LLC"})
					Me._Items.Add(New Task() With {.Name = "Brittany Marks", .Company = "Egestas Urna Justo Incorporated"})
					Me._Items.Add(New Task() With {.Name = "Scarlet Duncan", .Company = "Quam A PC"})
					Me._Items.Add(New Task() With {.Name = "John Gonzales", .Company = "Turpis Vitae Incorporated"})
					Me._Items.Add(New Task() With {.Name = "Meghan Whitney", .Company = "Vehicula Et Rutrum Institute"})
					Me._Items.Add(New Task() With {.Name = "Hayden Delaney", .Company = "Ac Mattis Limited"})
					Me._Items.Add(New Task() With {.Name = "Adria Richardson", .Company = "Varius Ultrices Mauris Inc."})
					Me._Items.Add(New Task() With {.Name = "Dorothy Brock", .Company = "Enim Commodo Hendrerit Institute"})
					Me._Items.Add(New Task() With {.Name = "Abigail Barnett", .Company = "Quam Quis Foundation"})
					Me._Items.Add(New Task() With {.Name = "Shay Jefferson", .Company = "Etiam Imperdiet Dictum PC"})
					Me._Items.Add(New Task() With {.Name = "Mufutau Dorsey", .Company = "Habitant Morbi Tristique Limited"})
					Me._Items.Add(New Task() With {.Name = "Wing Galloway", .Company = "Ut Lacus Nulla Consulting"})
					Me._Items.Add(New Task() With {.Name = "Minerva Houston", .Company = "Lorem Luctus Ut LLP"})
					Me._Items.Add(New Task() With {.Name = "Lisandra Underwood", .Company = "Aenean Gravida Nunc Company"})
					Me._Items.Add(New Task() With {.Name = "Palmer Case", .Company = "Sem Corp."})
					Me._Items.Add(New Task() With {.Name = "Melinda Buchanan", .Company = "Mollis Duis Corporation"})
					Me._Items.Add(New Task() With {.Name = "Hakeem Jarvis", .Company = "Suspendisse Non Leo LLP"})
					Me._Items.Add(New Task() With {.Name = "Martha Hartman", .Company = "Ipsum Dolor LLP"})
					Me._Items.Add(New Task() With {.Name = "Jamal Cameron", .Company = "Nulla In Corporation"})
					Me._Items.Add(New Task() With {.Name = "Eric Burgess", .Company = "Non Industries"})
					Me._Items.Add(New Task() With {.Name = "Sloane Spears", .Company = "Rutrum Urna Industries"})
					Me._Items.Add(New Task() With {.Name = "Olympia Tyler", .Company = "Mauris Quis Turpis Consulting"})
					Me._Items.Add(New Task() With {.Name = "Kim Palmer", .Company = "Sagittis Felis Donec Ltd"})
					Me._Items.Add(New Task() With {.Name = "Palmer Hatfield", .Company = "Aenean Egestas Associates"})
					Me._Items.Add(New Task() With {.Name = "Gannon Solis", .Company = "Nonummy Ultricies Limited"})
					Me._Items.Add(New Task() With {.Name = "Yoshi Salinas", .Company = "At Auctor Company"})
					Me._Items.Add(New Task() With {.Name = "Michael Schroeder", .Company = "Nunc Institute"})
					Me._Items.Add(New Task() With {.Name = "Conan Perkins", .Company = "Eu Associates"})
					Me._Items.Add(New Task() With {.Name = "Brynne Reid", .Company = "Quisque Ornare Tortor Incorporated"})
					Me._Items.Add(New Task() With {.Name = "Veronica Rowland", .Company = "A Corporation"})
					Me._Items.Add(New Task() With {.Name = "Clinton Horn", .Company = "Ipsum Nunc Corp."})
					Me._Items.Add(New Task() With {.Name = "Jaden Petty", .Company = "Enim Condimentum Foundation"})
					Me._Items.Add(New Task() With {.Name = "Xander Nicholson", .Company = "Vel PC"})
					Me._Items.Add(New Task() With {.Name = "Christian Cantu", .Company = "Ligula Company"})
					Me._Items.Add(New Task() With {.Name = "Francesca Garner", .Company = "Ante PC"})
					Me._Items.Add(New Task() With {.Name = "Genevieve Walton", .Company = "Eu Ltd"})
					Me._Items.Add(New Task() With {.Name = "Iris Dillard", .Company = "Euismod In Associates"})
					Me._Items.Add(New Task() With {.Name = "Breanna Martin", .Company = "Elit Dictum Eu LLC"})
					Me._Items.Add(New Task() With {.Name = "Dora Vazquez", .Company = "Condimentum Eget Volutpat Corp."})
					Me._Items.Add(New Task() With {.Name = "Lenore Browning", .Company = "Odio Consulting"})
					Me._Items.Add(New Task() With {.Name = "Nevada Ramsey", .Company = "Malesuada Ltd"})
					Me._Items.Add(New Task() With {.Name = "Laith Pena", .Company = "Pede Cras Company"})
					Me._Items.Add(New Task() With {.Name = "Clarke Lindsey", .Company = "Risus Donec Associates"})
					Me._Items.Add(New Task() With {.Name = "Michelle Norton", .Company = "Mi Inc."})
					Me._Items.Add(New Task() With {.Name = "Morgan Rivas", .Company = "Ligula Eu Consulting"})
					Me._Items.Add(New Task() With {.Name = "Nissim Young", .Company = "Tristique Inc."})
					Me._Items.Add(New Task() With {.Name = "Hedda Gonzalez", .Company = "Eu Company"})
					Me._Items.Add(New Task() With {.Name = "Althea Holden", .Company = "Erat Eget Foundation"})
					Me._Items.Add(New Task() With {.Name = "Jesse Lee", .Company = "Ipsum Foundation"})
					Me._Items.Add(New Task() With {.Name = "Selma Alexander", .Company = "Nulla In Tincidunt PC"})
					Me._Items.Add(New Task() With {.Name = "Olga Byers", .Company = "Ullamcorper Inc."})
					Me._Items.Add(New Task() With {.Name = "Adena Burgess", .Company = "Donec LLP"})
					Me._Items.Add(New Task() With {.Name = "Herrod Lucas", .Company = "Eleifend Nec Malesuada Associates"})
					Me._Items.Add(New Task() With {.Name = "Noah Stone", .Company = "Magnis Dis Parturient Ltd"})
					Me._Items.Add(New Task() With {.Name = "Jocelyn Cardenas", .Company = "Eros Associates"})
					Me._Items.Add(New Task() With {.Name = "Ahmed Lawson", .Company = "Ut Corp."})
					Me._Items.Add(New Task() With {.Name = "May Flynn", .Company = "Nisi Inc."})
					Me._Items.Add(New Task() With {.Name = "Mariam Hampton", .Company = "Lectus Cum Sociis Incorporated"})
					Me._Items.Add(New Task() With {.Name = "Mariko Mcconnell", .Company = "Imperdiet Ullamcorper LLC"})
					Me._Items.Add(New Task() With {.Name = "Lucius Caldwell", .Company = "Consectetuer Rhoncus Nullam Foundation"})
					Me._Items.Add(New Task() With {.Name = "Iona Nguyen", .Company = "Varius Orci In Ltd"})
					Me._Items.Add(New Task() With {.Name = "Leigh Browning", .Company = "Aliquet Odio Etiam Inc."})
					Me._Items.Add(New Task() With {.Name = "Quemby Marks", .Company = "At Pretium Aliquet Ltd"})
					Me._Items.Add(New Task() With {.Name = "Blaze Wilcox", .Company = "Curabitur Massa Vestibulum Incorporated"})
					Me._Items.Add(New Task() With {.Name = "Leila Gill", .Company = "Lacus Aliquam Foundation"})
					Me._Items.Add(New Task() With {.Name = "Astra Carr", .Company = "Quam Foundation"})
					Me._Items.Add(New Task() With {.Name = "Vielka Atkinson", .Company = "Ante Corp."})
					Me._Items.Add(New Task() With {.Name = "Caryn Mason", .Company = "Elit Foundation"})
					Me._Items.Add(New Task() With {.Name = "Drake Stephenson", .Company = "Donec Sollicitudin Corporation"})
					Me._Items.Add(New Task() With {.Name = "Glenna Harrison", .Company = "Phasellus At Company"})
					Me._Items.Add(New Task() With {.Name = "Morgan Knapp", .Company = "Eget Ipsum Incorporated"})
					Me._Items.Add(New Task() With {.Name = "Connor Payne", .Company = "Semper Nam Tempor LLP"})
					Me._Items.Add(New Task() With {.Name = "Richard Baker", .Company = "Phasellus LLP"})
					Me._Items.Add(New Task() With {.Name = "Mia Fulton", .Company = "Vitae Consulting"})
					Me._Items.Add(New Task() With {.Name = "Melyssa Robertson", .Company = "Malesuada Fames Company"})
					Me._Items.Add(New Task() With {.Name = "Ahmed Humphrey", .Company = "Sed Ltd"})
					Me._Items.Add(New Task() With {.Name = "Rashad Merrill", .Company = "Laoreet Lectus Company"})
					Me._Items.Add(New Task() With {.Name = "Fitzgerald Hayden", .Company = "Egestas Duis Corporation"})
					Me._Items.Add(New Task() With {.Name = "Mollie Holt", .Company = "Ipsum Suspendisse Sagittis PC"})
					Me._Items.Add(New Task() With {.Name = "Olga Jacobs", .Company = "Morbi Sit Amet Industries"})
					Me._Items.Add(New Task() With {.Name = "Ray Foreman", .Company = "Quam Company"})
					Me._Items.Add(New Task() With {.Name = "Alexis Gallagher", .Company = "Pellentesque LLP"})
					Me._Items.Add(New Task() With {.Name = "Yolanda Duke", .Company = "Scelerisque LLP"})
					Me._Items.Add(New Task() With {.Name = "Hilel Barnett", .Company = "Pharetra Felis Inc."})
					Me._Items.Add(New Task() With {.Name = "Roth Atkinson", .Company = "Vulputate Velit Foundation"})
					Me._Items.Add(New Task() With {.Name = "Shea Stafford", .Company = "Etiam Foundation"})
					Me._Items.Add(New Task() With {.Name = "Duncan Booker", .Company = "Non Feugiat Corporation"})
					Me._Items.Add(New Task() With {.Name = "Lucy Rodgers", .Company = "Mollis Non Institute"})
				End If

				Return Me._Items
			End Get
		End Property

		#End Region ' Items

	End Class
End Namespace