using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Recruitment_Drive_Portal1.UI;
using MudBlazor.Services;
using Recruitment_Drive_Portal1.UI.Interfaces;
using Recruitment_Drive_Portal1.UI.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.Services.AddMudServices();
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IRegisterPanel, RegisterPanelService>();
builder.Services.AddScoped(sp =>
    new HttpClient
    {
        BaseAddress = new Uri("https://localhost:7212/")
    });



builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
