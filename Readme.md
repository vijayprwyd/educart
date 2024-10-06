```c#
dotnet new web -n Demo
```

## Creating MIgrations

```c#
dotnet ef migrations add <migration-name>
dotnet ef database update
```

## Applying MIgrations

```c#
dotnet restore
dotnet ef database update
```