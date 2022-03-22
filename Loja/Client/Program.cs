global using Loja.Shared;
global using System.Net.Http.Json;
global using Loja.Client.Services.ProductService;
global using Loja.Client.Services.CategoryService;
global using Loja.Client.Services.BrandService;
global using Loja.Client.Services.TaxService;
using Loja.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ITaxService, TaxService>();

await builder.Build().RunAsync();
