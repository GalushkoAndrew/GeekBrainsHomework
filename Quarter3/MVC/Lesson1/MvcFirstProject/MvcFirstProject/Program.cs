using Microsoft.AspNetCore.HttpLogging;
using MvcFirstProject.DomainEvents.EventConsumers;
using MvcFirstProject.Models;
using MvcFirstProject.Models.Mail;
using MvcFirstProject.Services;
using Serilog;

Log.Logger = new LoggerConfiguration()
   .WriteTo.Console()
   .WriteTo.File("log_.txt", rollingInterval: RollingInterval.Day)
   .CreateBootstrapLogger(); //означает, что глобальный логер будет заменен на вариант из Host.UseSerilog
Log.Information("Starting up");

try {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Services.AddSingleton<ICatalog, Catalog>();
    builder.Services.AddScoped<ISendMailService, MailKitSendMailService>();
    builder.Services.AddScoped<ICatalogManager, CatalogManager>();
    builder.Services.AddHostedService<ServerWorkValidateService>();
    builder.Services.AddHostedService<SkuAddedEmailSender>();

    builder.Services.Configure<MailOptions>(builder.Configuration.GetSection("MailOptions"));
    builder.Host.UseSerilog((_, conf) => {
        conf.WriteTo.Console()
        .WriteTo.File("log_.txt", rollingInterval: RollingInterval.Day);
    });
    builder.Services.AddHttpLogging(options => //настройка
    {
        options.LoggingFields = HttpLoggingFields.RequestHeaders
                                | HttpLoggingFields.ResponseHeaders
                                | HttpLoggingFields.RequestBody
                                | HttpLoggingFields.ResponseBody;
    });


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment()) {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseHttpsRedirection();
    app.UseHttpLogging();
    app.Use(async (context, next) => {
        var userAgent = context.Request.Headers.UserAgent.ToString();
        if (!userAgent.ToLower().Contains("edg")) {
            context.Response.ContentType = "text/plain; charset=UTF-8";
            await context.Response.WriteAsync("¬аш браузер не поддерживаетс€. ѕоддерживаетс€ только браузер Edge");
            return;
        }
        await next();
    });

    app.UseStaticFiles();
    app.UseSerilogRequestLogging();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Catalog}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex) {
    Log.Fatal(ex, "Server down");
}
finally {
    Log.Information("Shut down complete");
    Log.CloseAndFlush(); //перед выходом дожидаемс€ пока все логи будут записаны
}

