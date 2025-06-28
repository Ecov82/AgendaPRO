using AgendaPro.Data;
using AgendaPro.Filters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registro do filtro de acesso master para injeção de dependência
builder.Services.AddScoped<MasterOnlyAttribute>();

// Configuração do DbContext com SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Permite acessar a sessão e HttpContext em filtros, serviços e views
builder.Services.AddHttpContextAccessor();

// Configuração de cache e sessão
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Registro do MVC com filtro global de autenticação
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<AuthenticatedAttribute>();
});

var app = builder.Build();

// Aplica migrações e executa o seed (criação inicial de dados, se necessário)
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        db.Database.Migrate(); // Aplica as migrations pendentes
        db.Seed();             // Executa método de seed personalizado
    } catch (Exception ex)
    {
        Console.WriteLine($"Erro ao aplicar migrations ou seed: {ex.Message}");
        throw;
    }
}

// Middlewares padrão para produção
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession(); // Sessão antes dos endpoints

// Configuração das rotas padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
