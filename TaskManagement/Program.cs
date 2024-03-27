using Microsoft.EntityFrameworkCore;
using TaskManagement.Db;
using TaskManagement.File;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("MySqlConnection");
ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
builder.Services.AddDbContext<TaskDbContext>(options => options.UseMySql(connectionString, serverVersion));
builder.Services.AddScoped<IssueRepository>();
builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<ProjectRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();