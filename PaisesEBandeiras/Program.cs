using PaisesEBandeiras.Controllers;
using PaisesEBandeiras.Services.MoedasServices;
using PaisesEBandeiras.Services.PaisesServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPaisesService, PaisesService>();
builder.Services.AddScoped<IMoedasService, MoedasService>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Paises}/{action=Index}/{id?}");


app.Run();
