# VB.NETデータベースクライアント

簡単なデータベースクライアントプログラム。

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
```

## 自分用メモ

```bash
dotnet new console -lang VB -o <プロジェクト名>
```
