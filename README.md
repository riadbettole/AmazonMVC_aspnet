# AmazonMVC

Small usecase of cart + product in ASP.NET

Make sure to migrate + update the database in NuggetPackager: 
add-migration first
update-database

Uncomment this one time in program.cs to seed the data with Admin + 2 genre & products
using(var scope = app.Services.CreateScope())
{
  await DbSeeder.SeedDefaultData(scope.ServiceProvider);
}

Admin ( No AdminDashboard ) 
Email : admin@gmail.com
Password : Admin@123

You can add Products&Genres in ./Data/DbSeeder.cs

Have fun.
