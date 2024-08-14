using Artysan_DAL.Contexts;
using Artysan_Service.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews(); 

builder.Services.AddDbContext<ArtysanDbContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr"))
    );
builder.Services.AddExtensions();
var app = builder.Build();

//#region AutoMigration
//using (var scope = app.Services.CreateScope())
//{
//   using (var appContext = scope.ServiceProvider.GetRequiredService<ArtysanDbContext>())
//  {
//       try
//      {
//            appContext.Database.Migrate();
//        }
//       catch (Exception ex)
//      {
//          // Log errors or do anything you think it's needed
//           throw;
//       }
//    }
//}
//#endregion

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
