using MvcFirstProject.Models;
using MvcFirstProject.Models.Mail;
using MvcFirstProject.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ICatalog, Catalog>();
builder.Services.AddScoped<ISendMailService, MailKitSendMailService>();
builder.Services.AddScoped<ICatalogManager, CatalogManager>();

builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("MailOptions"));
builder.Host.UseSerilog((_, conf) => {
    conf.WriteTo.Console()
    .WriteTo.File("log_.txt", rollingInterval: RollingInterval.Day);
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
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Catalog}/{action=Index}/{id?}");

app.Run();
