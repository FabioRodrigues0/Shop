global using Shop.Shared;
global using System.Net.Http.Json;
global using Microsoft.AspNetCore.Components.Authorization;
global using Shop.Client.Services.ProductService;
global using Shop.Client.Services.CategoryService;
global using Shop.Client.Services.BrandService;
global using Shop.Client.Services.TaxService;
global using Shop.Client.Services.AuthService;
global using BlazorStrap;
global using Blazored.LocalStorage;
using BlazorEcommerce.Client;
using Shop.Client;
using Microsoft.AspNetCore.Components.Web; 
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<ITaxService, TaxService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();


builder.Services.AddBlazorStrap();
await builder.Build().RunAsync();
