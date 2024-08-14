# ElaboratoDB

## Packages installation with NuGet
[Official guide](https://www.nuget.org/packages/EntityFramework/)
Open your NuGet terminal in Visual Studio by selecting Tools > NuGet Package Manager > Package Manager Console.
Type in the following commands:
```
Install-Package Pomelo.EntityFrameworkCore.MySql
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
```

Pomelo is used to map objects from a MySQL server to C# objects. If you're using a SQL Server application, you can use the builtin command [SQLMetal](https://learn.microsoft.com/it-it/dotnet/framework/tools/sqlmetal-exe-code-generation-tool).

Run this in the package manager to execute the mapping:
```
Scaffold-DbContext "server=localhost;port=3306;database=your_database_name;user=your_user;password=yourpassword" Pomelo.EntityFrameworkCore.MySql -OutputDir your_output_directory -Context YourDatabaseNameContext -ContextDir your_context_directory
```

In my case:
```
Scaffold-DbContext "server=localhost;port=3306;database=clash_of_clans;user=root" Pomelo.EntityFrameworkCore.MySql -OutputDir database -Context ClashOfClansContext -ContextDir context
```
Optionally, you can add a *-Force* flag to the previous command.

## Pipeline for modifying database
- Change DBMain project
- Update the .sql file for database generation in the sql/ folder
- Drop the database on phpMyAdmin through Xampp
- Create new database
- Run population queries
- Repeat the mapping with Scaffold-DbContext by running the appropriate command in the Package Manager console