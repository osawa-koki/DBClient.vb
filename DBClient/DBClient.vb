Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Enum DBMethod
  DBSelect
  DBSelectAll
  DBExecute
End Enum

Public Class DBClient
  ' 接続文字列
  Private Shared _connection_string As String
  ' SQL文
  Private _sql As String = ""
  ' SQLパラメタ
  Private _sqlParams As List(Of (arg As String, dbtype As SqlDbType, value As Object)) = New List(Of (arg As String, dbtype As SqlDbType, value As Object))()

  ' プログラムで一度だけ実行(初期化)
  Public Shared Sub Init(connection_string As String)
    _connection_string = connection_string
  End Sub

  ' SQL文の追加
  Public Sub Add(sql As String)
    Me._sql &= $" {sql} "
  End Sub

  ' SQLパラメタの追加
  Public Sub AddParam(arg As String, dbtype As SqlDbType, value As Object)
    _sqlParams.Add((arg, dbtype, value))
  End Sub

  Public Function DBSelect() As Dictionary(Of String, Object)
    ' 関数内でのみ有効な変数を宣言
    Dim myConn As SqlConnection
    Dim myCmd As SqlCommand
    Dim myReader As SqlDataReader

    ' 接続文字列の設定がされていなかったら処理を終了
    If Me._connection_string Is Nothing
      Console.WriteLine("接続文字列が指定されていません。")
      Return Nothing
    End If

    ' 接続文字列からDBコネクションオブジェクトを生成
    myConn = New SqlConnection(Me._connection_string)

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

    ' 結果返却用のデータを作成
    Dim result As Dictionary(Of String, Object) = new Dictionary(Of String, Object)()

    For i = 0 To myReader.FieldCount
      result.Add(myReader.GetName(i), myReader.GetValue(i))
    Next

    myReader.Close()
    myConn.Close()

    Return result
  End Function

  Public Function DBSelectAll() As List (Of Dictionary(Of String, Object))
    ' 関数内でのみ有効な変数を宣言
    Dim myConn As SqlConnection
    Dim myCmd As SqlCommand
    Dim myReader As SqlDataReader

    ' 接続文字列の設定がされていなかったら処理を終了
    If Me._connection_string Is Nothing
      Console.WriteLine("接続文字列が指定されていません。")
      Return Nothing
    End If

    ' 接続文字列からDBコネクションオブジェクトを生成
    myConn = New SqlConnection(Me._connection_string)

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

    ' 結果返却用のデータを作成
    Dim result As List(Of Dictionary(Of String, Object)) = new List (Of Dictionary(Of String, Object))()

    Do While myReader.Read()
      ' 結果返却用の一時的なデータを作成
      Dim temp_result As Dictionary(Of String, Object) = new Dictionary(Of String, Object)()
      For i = 0 To myReader.FieldCount - 1
        temp_result.Add(myReader.GetName(i), myReader.GetValue(i))
      Next
      result.Add(temp_result)
    Loop

    myReader.Close()
    myConn.Close()

    Return result
  End Function

  Public Sub DBExecute()
    ' 関数内でのみ有効な変数を宣言
    Dim myConn As SqlConnection
    Dim myCmd As SqlCommand

    ' 接続文字列の設定がされていなかったら処理を終了
    If Me._connection_string Is Nothing
      Console.WriteLine("接続文字列が指定されていません。")
      Return
    End If

    ' 接続文字列からDBコネクションオブジェクトを生成
    myConn = New SqlConnection(Me._connection_string)

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
    myCmd.ExecuteNonQuery()

    myConn.Close()
  End Sub

End Class
