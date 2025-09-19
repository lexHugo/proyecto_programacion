using Microsoft.EntityFrameworkCore;
using proyecto_programacion.Data;

var builder = WebApplication.CreateBuilder(args);

// --- INICIO: CONFIGURACIÓN DE LA BASE DE DATOS ---

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
    
// --- FIN: CONFIGURACIÓN DE LA BASE DE DATOS ---


builder.Services.AddControllersWithViews();

var app = builder.Build();

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