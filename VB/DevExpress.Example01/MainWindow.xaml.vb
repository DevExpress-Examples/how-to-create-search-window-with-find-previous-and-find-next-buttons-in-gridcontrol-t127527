Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Controls

Namespace DevExpress.Example01

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            DataContext = Me
        End Sub

#Region "Items"
        Protected _Items As List(Of Task)

        Public ReadOnly Property Items As List(Of Task)
            Get
                If _Items Is Nothing Then
                    _Items = New List(Of Task)()
                    _Items.Add(New Task() With {.Name = "Virginia Walsh", .Company = "Fermentum Corp."})
                    _Items.Add(New Task() With {.Name = "Nola Chapman", .Company = "Auctor Velit Ltd"})
                    _Items.Add(New Task() With {.Name = "Bert Evans", .Company = "Lectus Pede Foundation"})
                    _Items.Add(New Task() With {.Name = "Armando Collier", .Company = "Nisl Incorporated"})
                    _Items.Add(New Task() With {.Name = "Jasper Conley", .Company = "Eleifend Corp."})
                    _Items.Add(New Task() With {.Name = "Kamal Rosa", .Company = "Etiam Imperdiet Dictum Ltd"})
                    _Items.Add(New Task() With {.Name = "Julian Wilkins", .Company = "Tempus Non Ltd"})
                    _Items.Add(New Task() With {.Name = "Ignatius Henderson", .Company = "Fringilla Company"})
                    _Items.Add(New Task() With {.Name = "Desiree Mercer", .Company = "Dui In Industries"})
                    _Items.Add(New Task() With {.Name = "Tiger Santiago", .Company = "Lacinia Orci Consectetuer Inc."})
                    _Items.Add(New Task() With {.Name = "Philip Petersen", .Company = "Egestas Urna LLP"})
                    _Items.Add(New Task() With {.Name = "Mariam Medina", .Company = "Orci Luctus Et Associates"})
                    _Items.Add(New Task() With {.Name = "Kenneth Rollins", .Company = "Nunc LLC"})
                    _Items.Add(New Task() With {.Name = "Brittany Marks", .Company = "Egestas Urna Justo Incorporated"})
                    _Items.Add(New Task() With {.Name = "Scarlet Duncan", .Company = "Quam A PC"})
                    _Items.Add(New Task() With {.Name = "John Gonzales", .Company = "Turpis Vitae Incorporated"})
                    _Items.Add(New Task() With {.Name = "Meghan Whitney", .Company = "Vehicula Et Rutrum Institute"})
                    _Items.Add(New Task() With {.Name = "Hayden Delaney", .Company = "Ac Mattis Limited"})
                    _Items.Add(New Task() With {.Name = "Adria Richardson", .Company = "Varius Ultrices Mauris Inc."})
                    _Items.Add(New Task() With {.Name = "Dorothy Brock", .Company = "Enim Commodo Hendrerit Institute"})
                    _Items.Add(New Task() With {.Name = "Abigail Barnett", .Company = "Quam Quis Foundation"})
                    _Items.Add(New Task() With {.Name = "Shay Jefferson", .Company = "Etiam Imperdiet Dictum PC"})
                    _Items.Add(New Task() With {.Name = "Mufutau Dorsey", .Company = "Habitant Morbi Tristique Limited"})
                    _Items.Add(New Task() With {.Name = "Wing Galloway", .Company = "Ut Lacus Nulla Consulting"})
                    _Items.Add(New Task() With {.Name = "Minerva Houston", .Company = "Lorem Luctus Ut LLP"})
                    _Items.Add(New Task() With {.Name = "Lisandra Underwood", .Company = "Aenean Gravida Nunc Company"})
                    _Items.Add(New Task() With {.Name = "Palmer Case", .Company = "Sem Corp."})
                    _Items.Add(New Task() With {.Name = "Melinda Buchanan", .Company = "Mollis Duis Corporation"})
                    _Items.Add(New Task() With {.Name = "Hakeem Jarvis", .Company = "Suspendisse Non Leo LLP"})
                    _Items.Add(New Task() With {.Name = "Martha Hartman", .Company = "Ipsum Dolor LLP"})
                    _Items.Add(New Task() With {.Name = "Jamal Cameron", .Company = "Nulla In Corporation"})
                    _Items.Add(New Task() With {.Name = "Eric Burgess", .Company = "Non Industries"})
                    _Items.Add(New Task() With {.Name = "Sloane Spears", .Company = "Rutrum Urna Industries"})
                    _Items.Add(New Task() With {.Name = "Olympia Tyler", .Company = "Mauris Quis Turpis Consulting"})
                    _Items.Add(New Task() With {.Name = "Kim Palmer", .Company = "Sagittis Felis Donec Ltd"})
                    _Items.Add(New Task() With {.Name = "Palmer Hatfield", .Company = "Aenean Egestas Associates"})
                    _Items.Add(New Task() With {.Name = "Gannon Solis", .Company = "Nonummy Ultricies Limited"})
                    _Items.Add(New Task() With {.Name = "Yoshi Salinas", .Company = "At Auctor Company"})
                    _Items.Add(New Task() With {.Name = "Michael Schroeder", .Company = "Nunc Institute"})
                    _Items.Add(New Task() With {.Name = "Conan Perkins", .Company = "Eu Associates"})
                    _Items.Add(New Task() With {.Name = "Brynne Reid", .Company = "Quisque Ornare Tortor Incorporated"})
                    _Items.Add(New Task() With {.Name = "Veronica Rowland", .Company = "A Corporation"})
                    _Items.Add(New Task() With {.Name = "Clinton Horn", .Company = "Ipsum Nunc Corp."})
                    _Items.Add(New Task() With {.Name = "Jaden Petty", .Company = "Enim Condimentum Foundation"})
                    _Items.Add(New Task() With {.Name = "Xander Nicholson", .Company = "Vel PC"})
                    _Items.Add(New Task() With {.Name = "Christian Cantu", .Company = "Ligula Company"})
                    _Items.Add(New Task() With {.Name = "Francesca Garner", .Company = "Ante PC"})
                    _Items.Add(New Task() With {.Name = "Genevieve Walton", .Company = "Eu Ltd"})
                    _Items.Add(New Task() With {.Name = "Iris Dillard", .Company = "Euismod In Associates"})
                    _Items.Add(New Task() With {.Name = "Breanna Martin", .Company = "Elit Dictum Eu LLC"})
                    _Items.Add(New Task() With {.Name = "Dora Vazquez", .Company = "Condimentum Eget Volutpat Corp."})
                    _Items.Add(New Task() With {.Name = "Lenore Browning", .Company = "Odio Consulting"})
                    _Items.Add(New Task() With {.Name = "Nevada Ramsey", .Company = "Malesuada Ltd"})
                    _Items.Add(New Task() With {.Name = "Laith Pena", .Company = "Pede Cras Company"})
                    _Items.Add(New Task() With {.Name = "Clarke Lindsey", .Company = "Risus Donec Associates"})
                    _Items.Add(New Task() With {.Name = "Michelle Norton", .Company = "Mi Inc."})
                    _Items.Add(New Task() With {.Name = "Morgan Rivas", .Company = "Ligula Eu Consulting"})
                    _Items.Add(New Task() With {.Name = "Nissim Young", .Company = "Tristique Inc."})
                    _Items.Add(New Task() With {.Name = "Hedda Gonzalez", .Company = "Eu Company"})
                    _Items.Add(New Task() With {.Name = "Althea Holden", .Company = "Erat Eget Foundation"})
                    _Items.Add(New Task() With {.Name = "Jesse Lee", .Company = "Ipsum Foundation"})
                    _Items.Add(New Task() With {.Name = "Selma Alexander", .Company = "Nulla In Tincidunt PC"})
                    _Items.Add(New Task() With {.Name = "Olga Byers", .Company = "Ullamcorper Inc."})
                    _Items.Add(New Task() With {.Name = "Adena Burgess", .Company = "Donec LLP"})
                    _Items.Add(New Task() With {.Name = "Herrod Lucas", .Company = "Eleifend Nec Malesuada Associates"})
                    _Items.Add(New Task() With {.Name = "Noah Stone", .Company = "Magnis Dis Parturient Ltd"})
                    _Items.Add(New Task() With {.Name = "Jocelyn Cardenas", .Company = "Eros Associates"})
                    _Items.Add(New Task() With {.Name = "Ahmed Lawson", .Company = "Ut Corp."})
                    _Items.Add(New Task() With {.Name = "May Flynn", .Company = "Nisi Inc."})
                    _Items.Add(New Task() With {.Name = "Mariam Hampton", .Company = "Lectus Cum Sociis Incorporated"})
                    _Items.Add(New Task() With {.Name = "Mariko Mcconnell", .Company = "Imperdiet Ullamcorper LLC"})
                    _Items.Add(New Task() With {.Name = "Lucius Caldwell", .Company = "Consectetuer Rhoncus Nullam Foundation"})
                    _Items.Add(New Task() With {.Name = "Iona Nguyen", .Company = "Varius Orci In Ltd"})
                    _Items.Add(New Task() With {.Name = "Leigh Browning", .Company = "Aliquet Odio Etiam Inc."})
                    _Items.Add(New Task() With {.Name = "Quemby Marks", .Company = "At Pretium Aliquet Ltd"})
                    _Items.Add(New Task() With {.Name = "Blaze Wilcox", .Company = "Curabitur Massa Vestibulum Incorporated"})
                    _Items.Add(New Task() With {.Name = "Leila Gill", .Company = "Lacus Aliquam Foundation"})
                    _Items.Add(New Task() With {.Name = "Astra Carr", .Company = "Quam Foundation"})
                    _Items.Add(New Task() With {.Name = "Vielka Atkinson", .Company = "Ante Corp."})
                    _Items.Add(New Task() With {.Name = "Caryn Mason", .Company = "Elit Foundation"})
                    _Items.Add(New Task() With {.Name = "Drake Stephenson", .Company = "Donec Sollicitudin Corporation"})
                    _Items.Add(New Task() With {.Name = "Glenna Harrison", .Company = "Phasellus At Company"})
                    _Items.Add(New Task() With {.Name = "Morgan Knapp", .Company = "Eget Ipsum Incorporated"})
                    _Items.Add(New Task() With {.Name = "Connor Payne", .Company = "Semper Nam Tempor LLP"})
                    _Items.Add(New Task() With {.Name = "Richard Baker", .Company = "Phasellus LLP"})
                    _Items.Add(New Task() With {.Name = "Mia Fulton", .Company = "Vitae Consulting"})
                    _Items.Add(New Task() With {.Name = "Melyssa Robertson", .Company = "Malesuada Fames Company"})
                    _Items.Add(New Task() With {.Name = "Ahmed Humphrey", .Company = "Sed Ltd"})
                    _Items.Add(New Task() With {.Name = "Rashad Merrill", .Company = "Laoreet Lectus Company"})
                    _Items.Add(New Task() With {.Name = "Fitzgerald Hayden", .Company = "Egestas Duis Corporation"})
                    _Items.Add(New Task() With {.Name = "Mollie Holt", .Company = "Ipsum Suspendisse Sagittis PC"})
                    _Items.Add(New Task() With {.Name = "Olga Jacobs", .Company = "Morbi Sit Amet Industries"})
                    _Items.Add(New Task() With {.Name = "Ray Foreman", .Company = "Quam Company"})
                    _Items.Add(New Task() With {.Name = "Alexis Gallagher", .Company = "Pellentesque LLP"})
                    _Items.Add(New Task() With {.Name = "Yolanda Duke", .Company = "Scelerisque LLP"})
                    _Items.Add(New Task() With {.Name = "Hilel Barnett", .Company = "Pharetra Felis Inc."})
                    _Items.Add(New Task() With {.Name = "Roth Atkinson", .Company = "Vulputate Velit Foundation"})
                    _Items.Add(New Task() With {.Name = "Shea Stafford", .Company = "Etiam Foundation"})
                    _Items.Add(New Task() With {.Name = "Duncan Booker", .Company = "Non Feugiat Corporation"})
                    _Items.Add(New Task() With {.Name = "Lucy Rodgers", .Company = "Mollis Non Institute"})
                End If

                Return _Items
            End Get
        End Property
#End Region  ' Items
    End Class
End Namespace
