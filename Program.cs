using Services;
using Umbraco.Cms.Core.Notifications;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Register your custom services
builder.Services.AddScoped<IBlazorPublishEventService, BlazorPublishEventService>();

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .AddNotificationHandler<ContentPublishedNotification, OnContentPublishNotification>()
    .Build();

builder.Services.AddRazorComponents()
.AddInteractiveServerComponents();

builder.Services.AddControllersWithViews();

// You should change the URI based on your project's needs.
// It's best to get the URI from appsettings.json.
builder.Services.AddHttpClient("LocalApi", client => client.BaseAddress = new Uri("https://localhost:44362/"));

WebApplication app = builder.Build();



await app.BootUmbracoAsync();


app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseInstallerEndpoints();
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

    app.UseEndpoints(endpoints =>
{
    // This is the line you need to add
    endpoints.MapControllers();

});

app.MapRazorComponents<WebApplication>()
    .AddInteractiveServerRenderMode();

await app.RunAsync();
