Public Class Alumno
    Private id As Integer
    Private nie As Integer
    Private nombre As String

    Public Sub New()
    End Sub

    Public Sub New (nie As Integer, nombre As String)
        Me.nie = nie
        Me.nombre = nombre
    End Sub

    Public Sub New (id As Integer, nie As Integer, nombre As String)
        Me.id = id
        Me.nie = nie
        Me.nombre = nombre
    End Sub

    Public Sub setId(id As Integer)
        Me.id = id
    End Sub

    Public Sub setNie(nie As Integer)
        Me.nie = nie
    End Sub

    Public Sub setNombre(nombre As String)
        Me.nombre = nombre
    End Sub

    Public Function getId()
        return Id
    End Function

    Public Function getNie()
        return Nie
    End Function

    Public Function getNombre()
        return nombre
    End Function
    
End Class