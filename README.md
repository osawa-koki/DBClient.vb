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

## DB接続方法

```bash
/opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P 'P@ssw0rd'
```

## 自分用メモ

```bash
dotnet new console -lang VB -o <プロジェクト名>
```
