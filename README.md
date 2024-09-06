# Command Sheet

## Running App

### Run
```bash
$ dotnet run --lp https
```

### Watch
```bash
$ dotnet watch run --lp https
```

## Database

### Migration - create
```bash
$ dotnet ef migrations add <Migration Name> 
```

### Migration - Remove
```bash
$ dotnet ef migrations remove
```

## Migration - Generate Script
```bash
$ dotnet ef migrations script
```

### Migration - up
```bash
$ dotnet ef database update
```

### Migration - down
```bash
$ dotnet ef database update 0
```

## Controllers

### Install Tools
```bash
$ dotnet tool install -g dotnet-aspnet-codegenerator
$ dotnet tool update -g dotnet-aspnet-codegenerator
```

### Generate
```bash
$ dotnet aspnet-codegenerator controller -name <Filename, ex: TodoItemsController> -async -api -m <Model Name> -dc <Context> -outDir <Path, ex: Controllers>  
```
