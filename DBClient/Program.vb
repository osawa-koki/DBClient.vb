Imports System

Module Program
  Sub Main(args As String())
    DBClient.Init("Persist Security Info=False;User ID=sa;Password=P@ssw0rd;Initial Catalog=pokemon;Server=127.0.0.1;Encrypt=False;")
    Dim client As DBClient = New DBClient()

    client.Add("SELECT number, name")
    client.Add("FROM pokemon")
    Dim result As List (Of Dictionary(Of String, Object)) = client.DBSelectAll()

    Console.WriteLine(result)
  End Sub
End Module

