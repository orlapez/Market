using CurrieTechnologies.Razor.SweetAlert2;
using Market.WEB;
using Market.WEB.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });



// HttpClient para consumir el API desde la Web

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://marketapi.azurewebsites.net/") });

//Inyectamos el patrón Repository al proyecto WEB
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
