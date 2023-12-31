using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NAFSupport.Client;
using NAFSupport.Client.Api;
using BlazorBootstrap;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorBootstrap();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7017/") });
builder.Services.AddScoped<IApi, Api>();

await builder.Build().RunAsync();


    // Add your services and other configurations here.
