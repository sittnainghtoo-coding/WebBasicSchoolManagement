markdown


Scaffold-DbContext "Server=.;Database=DotNetTrainingBatch2;User ID=sa;Password=12345678;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir AppDbContextModels

dotnet ef dbcontext scaffold "Server=.;Database=mini_pos_db;User ID=sa;Password=12345678;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f

ASP.net core web api using EFCore + Database first

dotnet ef dbcontext scaffold "Server=.;Database=SchoolManagementSystem_db;User ID=sa;Password=12345678;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o AppDbContextModels -c AppDbContext -f


three type of injections

constructor injection,properties injection,method injection
