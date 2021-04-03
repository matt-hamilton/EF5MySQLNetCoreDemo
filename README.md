# EF5MySQLNetCoreDemo

Basic .NET Core console app working demo using the Entity Framework Core 5.0 to generate the Model using a Database First Approach

### Requirements 

- Connector/NET 8.0.23        
- MySQL Server 5.7      
- Entity Framework Core 5.0
- Visual Studio 2019

Generate the models using the following scaffold command

Scaffold-DbContext "server=localhost;user id=[user];password=[password];persistsecurityinfo=True;database=cars_demo" MySql.EntityFrameworkCore -Context "ModelContext" -o Models