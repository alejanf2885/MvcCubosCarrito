using Microsoft.EntityFrameworkCore;
using MvcCubosCarrito.Data;
using MvcCubosCarrito.Repositories.CubosRepo;
using MvcCubosCarrito.Services.CarritoServ;
using MvcCubosCarrito.Services.CuboServ;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();


//Repositories

builder.Services.AddTransient<ICuboRepository, CuboRepository>();

// Services
builder.Services.AddTransient<ICarritoService, CarritoService>();
builder.Services.AddTransient<ICuboService, CuboService>();


// Conexion BBDD 
string connectionString =
    builder.Configuration.GetConnectionString("SqlCubos");
builder.Services.AddDbContext<CuboContext>
    (options => options.UseMySQL(connectionString));



builder.Services.AddHttpContextAccessor();



//CREAMOS UN SERVICIO DE SESSION
builder.Services.AddSession(options =>
{

    options.IdleTimeout = TimeSpan.FromHours(1);

});



var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.UseSession();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
