Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace DevExpress.Example01
	Public Class Task
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property

		Private privateCompany As String
		Public Property Company() As String
			Get
				Return privateCompany
			End Get
			Set(ByVal value As String)
				privateCompany = value
			End Set
		End Property

		Private privateSartDate As DateTime
		Public Property SartDate() As DateTime
			Get
				Return privateSartDate
			End Get
			Set(ByVal value As DateTime)
				privateSartDate = value
			End Set
		End Property

		Private privateIsCompleted As Boolean
		Public Property IsCompleted() As Boolean
			Get
				Return privateIsCompleted
			End Get
			Set(ByVal value As Boolean)
				privateIsCompleted = value
			End Set
		End Property
	End Class
End Namespace
