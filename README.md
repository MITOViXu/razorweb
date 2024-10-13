# Entity Framework establish relationship 1 - many 🎄🎋🎆🧨🎉🎃

## Install EF packages

```bash
dotnet add package System.Data.SqlClient
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Logging
dotnet add package Microsoft.Extensions.Logging.Console
dotnet add package Microsoft.EntityFrameworkCore.Tools.DotNet

```

## Install Proxy

```bash
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```

## .NET 3.0 trở đi cài lệnh dotnet ef bằng

```bash
dotnet tool install --global dotnet-ef
```

## Create migration

```bash
dotnet ef migrations add MigrationName
```

ex

```bash
dotnet ef migrations add V0
```

## To check if any migrations are exist

```bash
dotnet ef migrations list
```

## Delete the last migraion

```bash
dotnet ef migrations remove
```

## Push to database

```bash
dotnet ef database update
```

## Delete database

```bash
dotnet ef database drop -f
```

## Return specific migration version

```bash
dotnet ef database update [NameMigation]
```

ex

```bash
dotnet ef database update V0
```

## Show all query from V0 to latest V version

```bash
dotnet ef migrations script
```
