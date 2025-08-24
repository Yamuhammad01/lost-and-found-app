using LostAndFoundApp.Components;
using LostAndFoundApp.Models;
using LostAndFoundApp.Services;
using Microsoft.EntityFrameworkCore;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient();
builder.Services.AddControllers(); // 

builder.Services.AddDbContext<ItemDbContext>(c =>
    c.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IItemService, ItemService>();

// Configure Supabase client
builder.Services.AddScoped<Supabase.Client>(_ =>
    new Supabase.Client(
        builder.Configuration["Supabase:Url"],
        builder.Configuration["Supabase:ApiKey"]
    ));

var supabaseUrl = builder.Configuration["Supabase:Url"];
var supabaseKey = builder.Configuration["Supabase:ApiKey"];

if (string.IsNullOrEmpty(supabaseUrl) || string.IsNullOrEmpty(supabaseKey))
{
    throw new InvalidOperationException("Supabase configuration is missing in appsettings.json");
}

new SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true,
};

var app = builder.Build();

// Configure the HTTP request pipelinee.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapControllers();

app.Run();