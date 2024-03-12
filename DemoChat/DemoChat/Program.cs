using DemoChat.Authentication;
using DemoChat.ChatHubFold;
using DemoChat.Client.ChatServices;
using DemoChat.Client.Pages;
using DemoChat.Components;
using DemoChat.Data;
using DemoChat.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
builder.Services.AddScoped<ChatRepository>();
builder.Services.AddSignalR();
builder.Services.AddScoped<ChatService>();


builder.Services.AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = IdentityConstants.ApplicationScheme;
    x.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    
}).AddIdentityCookies();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(DemoChat.Client._Imports).Assembly);
app.MapControllers();
app.MapHub<ChatHub>("/chathub");
app.Run();
