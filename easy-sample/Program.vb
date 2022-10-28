Imports System
Imports System.Data.SqlClient

Module Program
  Private myConn As SqlConnection
  Private myCmd As SqlCommand
  Private myReader As SqlDataReader
  Private results As String

  Sub Main(args As String())
    myConn = New SqlConnection("Persist Security Info=False;User ID=sa;Password=P@ssw0rd;Initial Catalog=master;Server=127.0.0.1;Encrypt=False;")
    myCmd = myConn.CreateCommand
    myCmd.CommandText = "SELECT 'Hello', 'World'"
    myConn.Open()
    myReader = myCmd.ExecuteReader()

    Dim results As String = ""
    Do While myReader.Read()
      results = results & myReader.GetString(0) & vbTab & myReader.GetString(1) & vbLf
    Loop

    Console.WriteLine(results)
    myReader.Close()
    myConn.Close()
  End Sub
End Module
