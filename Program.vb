Imports mysql.data.mysqlclient

Module Program

    Private connection

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
            Console.Write("Seleccione: ")

            op = Console.ReadLine()
            Console.Clear()
            Select Case op
                Case 1
                    Console.WriteLine("-- MOSTRAR --")
                    Show()
                Case 2
                    Console.WriteLine("-- INSERTAR --")

                    Dim a = New Alumno()

                    Console.Write("NIE: ")
                    a.setNie(Console.ReadLine())

                    Console.Write("Nombre: ")
                    a.setNombre(Console.ReadLine())

                    Console.WriteLine(Insert(a))
                Case 3
                Case 4
                Case 5
                    Console.WriteLine("Hasta pronto")
                Case Else
                    Console.WriteLine("Opción no encontrada")
            End Select

            Console.ReadKey()
            
        Loop While op <> 5
        
    End Sub

    Private Sub Connect()
        Try
            connection = new MySqlConnection(
                "server=localhost;user=root;password=;database=db_escuela"
            )
            connection.Open()
        Catch ex As Exception
            Console.WriteLine("No connection :(")
        End Try
    End Sub

    Private Function GetAlumnos() As ArrayList
        Connect()
        Dim sql As String = "SELECT * FROM alumno"
        Dim cmd = New MySqlCommand(sql, connection)
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        Dim alumnos As ArrayList = New ArrayList()

        While reader.Read()
            Dim alumno = New Alumno(
                reader("id_alumno"),
                reader("nie_alumno"),
                reader("nom_alumno")
            )
            alumnos.Add(alumno)
        End While

        connection.Close()

        return alumnos
    End Function

    Private Sub Show()
        Dim alumnos As ArrayList = GetAlumnos()

        For Each a in alumnos
            Console.WriteLine("{0} - {1} {2}", a.getId(), a.getNie(), a.getNombre())
        Next a
    End Sub

    Private Function Insert(a As Alumno) As String
        Connect()
        Dim sql As String = "INSERT INTO alumno (nie_alumno, nom_alumno) VALUES (@nie, @nombre)"
        Dim cmd = New MySqlCommand(sql, connection)
        cmd.Parameters.AddWithValue("@nie", a.getNie)
        cmd.Parameters.AddWithValue("@nombre", a.getNombre)
        cmd.ExecuteNonQuery()
        connection.Close()
        return "Alumno registrado"
    End Function
End Module
