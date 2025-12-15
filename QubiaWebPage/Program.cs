using Microsoft.EntityFrameworkCore;
using QubiaWebPage.Models; // Ajusta el namespace según donde se generó tu DbContext

var builder = WebApplication.CreateBuilder(args);

// Agregar soporte para controladores y vistas
builder.Services.AddControllersWithViews();

// Registrar el DbContext con la cadena de conexión
builder.Services.AddDbContext<QubiaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

