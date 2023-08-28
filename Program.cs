
using DapperCurd.Reositories;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Get the configuration from the app settings.
var configuration = builder.Configuration;

// Register the IDbConnection using SqlConnection with Dapper
builder.Services.AddTransient<IDbConnection>(db => new SqlConnection(configuration.GetConnectionString("DefaultConnection")));

// Register the EmployeeRepository
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

// Register MVC services
builder.Services.AddControllersWithViews();

// Register Authorization services if you're using them
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();