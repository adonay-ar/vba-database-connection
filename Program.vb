Imports System
Imports mysql.data.mysqlclient

Module Program

    Dim conn As MySqlConnection

    Sub Main(args As String())
        Dim op As Integer
                
        Do
            Console.Clear()
            Console.WriteLine("-- MENU --")
            Console.WriteLine("1. Mostrar")
            Console.WriteLine("2. Insertar")
            Console.WriteLine("3. Actualizar")
            Console.WriteLine("4. Eliminar")
            Console.WriteLine("5. Salir")

            Console.Write("Opcion: ")
            op = Console.ReadLine()

            Select Case op
                Case 1
                    Console.Clear()
                    Console.WriteLine("-- MOSTRAR --")
                    Console.Write(Mostrar())
                Case 2
                    Console.Clear()
                    Console.WriteLine("-- INSERTAR --")
                    Console.Write("NIE: ")
                    Dim nie As String = Console.ReadLine()
                    Console.Write("Nombre: ")
                    Dim nom As String = Console.ReadLine()
                    Console.WriteLine(Insertar(nie, nom))
                Case 3
                    Console.WriteLine("Actualizar")
                Case 4
                    Console.WriteLine("Eliminar")
                Case 5
                    Console.WriteLine("Hasta pronto")
                Case Else
                    Console.WriteLine("Opcion no valida")
            End Select
            
            Console.ReadKey()

        Loop While op <> 5

    End Sub

    Function Mostrar() As String
        Connect()
        Dim sql As String = "SELECT * FROM alumno"
        Dim cmd As MySqlCommand = new MySqlCommand(sql, conn)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        Dim result As String = ""

        While reader.Read()
            result &= reader("id_alumno") & " - " 
            result &= reader("nie_alumno") & " - " 
            result &= reader("nom_alumno") & vbCrLf
        End While

        reader.Close()

        return result
    End Function

    Function Insertar(nie, nom) As String
        Connect()
        Dim sql As String = "INSERT INTO alumno(nie_alumno, nom_alumno) VALUES(@nie, @nom)"
        Dim cmd As MySqlCommand = new MySqlCommand(sql, conn)
        cmd.Parameters.AddWithValue("@nie", nie)
        cmd.Parameters.AddWithValue("@nom", nom)
        cmd.ExecuteNonQuery()

        return "Registro insertado"
    End Function

    Function Connect() As String
        Try
            conn = new MySqlConnection(
                "server=localhost;user=root;password=;database=db_escuela"
            )

            conn.Open()
            return "Conexion exitosa"
        Catch ex As Exception
            return ex.Message
        End Try

    End Function

End Module

