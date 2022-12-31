# VB.NETデータベースクライアント

✗ 簡単なデータベースクライアントプログラム。  

## 使い方

DBClientインスタンスの接続文字列を設定。  

```vb
DBClient.Init("Persist Security Info=False;User ID=sa;Password=P@ssw0rd;Initial Catalog=pokemon;Server=127.0.0.1;Encrypt=False;")
```

接続文字列はSharedメンバであるため、各インスタンス間でその値を共有する。  

---

インスタンスを生成。  

```vb
Dim client As DBClient = New DBClient()
```

---

SQLを追加。  

```vb
client.Add("SELECT number, name")
client.Add("FROM pokemon")
```

---

SQLを実行。  
実行方法は以下の3つ。  

| 実行方法 | 説明 | 戻り値の型 |
| ---- | ---- | ---- |
| DBSelect | 単一のレコードを取得。 | Dictionary(Of String, Object) |
| DBSelectAll | 複数のレコードを取得。 | List (Of Dictionary(Of String, Object)) |
| DBExecute | 戻り値のないSQLの実行。 | void |

---

バインド機構(クエリ化文字列)を使用する場合には`AddParam`メソッドを使用する。  
引数は以下の通り。  

```vb
AddParam(arg As String, dbtype As SqlDbType, value As Object)
AddParam(パラメタ名 As String, データ型 As SqlDbType, 値 As Object)
```

## 実行方法

```vb.net
# easy-sampleディレクトリに移動して、、、
cd easy-sample

# プログラムを実行
dotnet run

# -> Hello  World
```

## DBに関する処理イロイロ

```bash
# DBにアクセス
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'P@ssw0rd'

# データベース作成
CREATE DATABASE pokemon
GO

# データベース変更
USE pokemon
GO

# テーブル作成
CREATE TABLE pokemon(
  number INT PRIMARY KEY,
  name NVARCHAR(10) UNIQUE
);

INSERT INTO pokemon(number, name) VALUES(25, N'ピカチュウ');
GO

INSERT INTO pokemon(number, name) VALUES(152, N'チコリータ');
GO

# DBプロンプトモードから抜ける
exit
```

## 自分用メモ

```bash
dotnet new console -lang VB -o <プロジェクト名>
```
