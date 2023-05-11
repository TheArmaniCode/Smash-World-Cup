using SmashWorldCup.Data;
using SmashWorldCup.Services;
using Microsoft.EntityFrameworkCore;
using SmashWorldCup.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SmashConnection");
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<SmashDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddSession();

builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IMatchService, MatchService>();
builder.Services.AddScoped<IStageService, StageService>();
builder.Services.AddScoped<ITournamentService, TournamentService>();
builder.Services.AddScoped<IVenueService, VenueService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
