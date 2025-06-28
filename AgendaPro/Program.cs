using AgendaPro.Data;
using AgendaPro.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registro do filtro de acesso master para inje��o de depend�ncia
builder.Services.AddScoped<MasterOnlyAttribute>();

// Configura��o do DbContext com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Permite acessar a sess�o e HttpContext em filtros, servi�os e views
builder.Services.AddHttpContextAccessor();

// Configura��o de cache e sess�o
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Registro do MVC com filtro global de autentica��o
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AuthenticatedAttribute>();
});

var app = builder.Build();

// Aplica migra��es e executa o seed (cria��o inicial de dados, se necess�rio)
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate(); // Aplica as migrations pendentes
        db.Seed();             // Executa m�todo de seed personalizado
    } catch (Exception ex)
    {
        Console.WriteLine($"Erro ao aplicar migrations ou seed: {ex.Message}");
        throw;
    }
}

// Middlewares padr�o para produ��o
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); // Sess�o antes dos endpoints

// Configura��o das rotas padr�o
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
