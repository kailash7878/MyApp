using MyApp.Infrastructure.ServicesExtension;
using MyApp.Serviecs.Middleare;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config")]

var builder = WebApplication.CreateBuilder(args);

//configure Database
//builder.Services.ConfigureAppCDBContex();

// Add services to the container.
builder.Services.RegisteredServices();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();


//app
//    .UseAuthentication()
//    .UseAuthorization()
//    .UseMiddleware<JwtMiddleare>()
//    .UseRouting()
//    .UseEndpoints(opt =>
//    {
//        opt.MapDefaultControllerRoute(
//            name: "default",
//            pattern: "api/{controller}/{action}/{id?}");
//    });



app.MapControllers();

app.Run();





