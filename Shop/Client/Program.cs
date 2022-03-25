global using Shop.Shared;
global using System.Net.Http.Json;
global using Shop.Client.Services.ProductService;
global using Shop.Client.Services.CategoryService;
global using Shop.Client.Services.BrandService;
global using Shop.Client.Services.TaxService;
using Shop.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorStrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ITaxService, TaxService>();

builder.Services.AddBlazorStrap();
await builder.Build().RunAsync();
