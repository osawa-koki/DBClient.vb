Imports System
Imports DBMod

Module Program
  Sub Main(args As String())
    DBClient.Init("Persist Security Info=False;User ID=sa;Password=P@ssw0rd;Initial Catalog=master;Server=127.0.0.1;Encrypt=False;")
  End Sub
End Module
