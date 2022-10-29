using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var host = new WebHostBuilder()
    .UseKestrel()
    .UseContentRoot(Directory.GetCurrentDirectory())
    .ConfigureAppConfiguration((hostingContext, config) =>
    {
        config
            .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
            .AddJsonFile("ocelot.json")
            .AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json")
            .AddEnvironmentVariables();
    })
    .ConfigureServices(s => {
        s.AddOcelot()
            .AddCacheManager(settings => settings.WithDictionaryHandle());
    })
    .ConfigureLogging((hostingContext, logging) =>
    {
        //add your logging
    })
    .UseIISIntegration()
    .Configure(app =>
    {
        app.UseOcelot().Wait();
    });



var builder = host.Build();
builder.Run();




//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddOcelot();


//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();    
//}
////app.MapGet("/", () => "Hello World!");

//app.UseRouting();

//await app.UseOcelot();

//app.Run();
