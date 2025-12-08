using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LibrarySystem.UI;
using LibrarySystem.UI.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7130/") });
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<ReaderService>();
builder.Services.AddScoped<LoanService>();


await builder.Build().RunAsync();