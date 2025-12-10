using Microsoft.EntityFrameworkCore;
using projetodotnnett.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuração do banco SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// MVC
builder.Services.AddControllersWithViews();

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
    pattern: "{controller=Conta}/{action=Login}/{id?}"
).WithStaticAssets();

app.Run();
