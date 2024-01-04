using Microsoft.EntityFrameworkCore;
using Serilog;
using VipCars.Application.Configuration;
using VipCars.Configuration;
using VipCars.Infrastructure.Configuration;
using VipCars.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();


var configuration = builder.Configuration;

#region Dependency Injection Containers
builder.Services
    .AddPresentation()
    .AddInfrastructure(configuration)
    .AddApplication();
#endregion



var app = builder.Build();
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

#region Database Initialization
var dbContext = services.GetRequiredService<VipDbContext>();
dbContext.Database.Migrate();
#endregion

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
