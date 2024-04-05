using ASP_Demo_Archi.Tools;
using ASP_Demo_Archi_DAL.Repositories;
using ASP_Demo_Archi_DAL.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Ajout des services natifs nécessaires au fonctionnement
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddHttpContextAccessor();

//Enregistrement des services pour l'injection de dépendances
builder.Services.AddScoped<IMovieRepo, MovieService>();
builder.Services.AddScoped<IPersonRepo, PersonService>();
builder.Services.AddScoped<IMovie_PersonRepo, Movie_PersonService>();
builder.Services.AddScoped<IUserRepo, UserService>();

builder.Services.AddScoped<SessionManager>();

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
