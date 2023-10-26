using fanduel_net.Interfaces;
using fanduel_net.Repository;
using fanduel_net.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Register the services with their implementations
builder.Services.AddScoped<ISportsService, SportsService>();
builder.Services.AddScoped<ITeamsService, TeamsService>();
builder.Services.AddScoped<IPlayersService, PlayersService>();
builder.Services.AddScoped<ITeamDepthService, TeamDepthService>();

// Register the repository with its implementation
builder.Services.AddScoped<ISportsRepository, SportsRepository>();
builder.Services.AddScoped<ITeamsRepository, TeamsRepository>();
builder.Services.AddScoped<IPlayersRepository, PlayersRepository>();
builder.Services.AddScoped<ITeamDepthRepository, TeamDepthRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

