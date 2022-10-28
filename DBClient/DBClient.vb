Imports System
Imports System.Data.SqlClient

Class DBClient
  ' 接続文字列
  Private Shared connection_string As String
  ' SQL文
  Private _sql As String = String.Empty
  ' SQLパラメタ
  Private _sqlParams As List(Of (arg As String, dbtype As SqlDbType, value As Object)) = New List(Of (arg As String, dbtype As SqlDbType, value As Object))

  ' プログラムで一度だけ実行(初期化)
  Sub Init(connection_string As String)
    Me.connection_string = connection_string
  End Sub

  ' SQL文の追加
  Sub Add(sql As String)
    Me._sql = " {sql} "
  End Sub

  ' SQLパラメタの追加
  Sub AddParam(arg As String, dbtype As SqlDbType, value As Object)
    _sqlParams.Add(arg, dbtype, value)
  End Sub

  Sub Main(args As String())
    ' 関数内でのみ有効な変数を宣言
    Dim myConn As SqlConnection
    Dim myCmd As SqlCommand
    Dim myReader As SqlDataReader

    ' 接続文字列の設定がされていなかったら処理を終了
    If Me.connection_string Is Nothing
      Console.WriteLine("接続文字列が指定されていません。")
      Return
    End If

    ' 接続文字列からDBコネクションオブジェクトを生成
    myConn = New SqlConnection(Me.connection_string)

    ' コネクションからSQLコマンドオブジェクトを作成
    myCmd = myConn.CreateCommand

    ' SQLコマンド文に登録された文字列を指定
    myCmd.CommandText = Me._sql

    For Each item As (arg As String, dbtype As SqlDbType, value As Object) In Me._sqlParams
      Dim key As String = item.arg
      Dim dbtype As SqlDbType = item.dbtype
      Dim value As Object = item.value
      myCmd.Parameters.Add(key, dbtype).Value = value
    Next

    ' コネクションをオープン
    myConn.Open()

    ' カーソルを取得
    myReader = myCmd.ExecuteReader()

    Do While myReader.Read()
      results = results & myReader.GetString(0) & vbTab & myReader.GetString(1) & vbLf
    Loop

    Console.WriteLine(results)
    myReader.Close()
    myConn.Close()
  End Sub
End Class
