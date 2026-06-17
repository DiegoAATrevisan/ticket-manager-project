using DotNetEnv;
using TicketManagerWeb.Components;

var builder = WebApplication.CreateBuilder(args);

// Carrega o .env do projeto ticket-manager
var envPath = Path.GetFullPath(Path.Combine(builder.Environment.ContentRootPath, "..", "ticket-manager", ".env"));

if (!File.Exists(envPath))
{
    throw new FileNotFoundException($"Arquivo .env não encontrado em: {envPath}");
}

Env.Load(envPath);

// Adiciona serviços para o conteiner.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<ServicoFuncionario>();
builder.Services.AddScoped<ServicoTicket>();
builder.Services.AddScoped<ServicoRelatorio>();

var app = builder.Build();

// Configura o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
