using Microsoft.EntityFrameworkCore;
using Trinisol.Data;
using Trinisol.Repositories;
using Trinisol.Services;


var builder = WebApplication.CreateBuilder(args);

// 🔹 Conexión MySQL
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// 🔹 Repositorios
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IPresentacionRepository, PresentacionRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// 🔹 Servicios
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IPresentacionService, PresentacionService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

// 🔹 Controladores y vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 Pipeline de la app
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 🔹 Ruta por defecto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
