# coreprac
A .Net Core application
* Tech Stack
  - ASP.NET Core version 7, MS SQL, EntityFramework, Code First Approach, Web API
* Functionalities
  - CRUD operation,
  - Application level for Mockup
  - and than connected with SQL database
  - Swagger for previewing and testing APIs
  - Enabled CORS
  - JWT Authentication using bcrypt
  - Roles based authorization
* Libraries
  - AutoMapper, Swagger, BCrypt, JwtBearer, Swashbuckle.AspNetCore.Filters (for swagger to convert into bearer token else it will give basic auth token)
* Commands used: 
  - dotnet, 
  - dotnet --info,
  - dotnet --version, 
  - dotnet new webapi, 
  - dotnet run watch, 
  - dotnet dev-certs https, 
  - dotnet new gitignore.
* Library commands: 
  - dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection, 
  - dotnet add package Microsoft.EntityFrameworkCore, 
  - dotnet add package Microsoft.EntityFrameworkCore.SQLServer, 
  - dotnet add package Microsoft.EntityFrameworkCore.Design, 
  - dotnet tool install --global dotnet-ef, 
  - dotnet tool uninstall --global dotnet-ef, 
  - dotnet ef database update, 
  - dotnet ef migrations add InitialCreate, 
  - dotnet ef -h
  - dotnet add package BCrypt.Net-Next
  - dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
  - dotnet add package Swashbuckle.AspNetCore.Filters
* Code Editor
  - Visual Studio Code
      - Extensions
          - C# Extensions by JosKreativ
          - .NET Install Tool for Extension Authors
          - C# by Microsoft
          - Prettier - Code formatter
