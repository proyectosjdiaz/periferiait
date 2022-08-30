using Microsoft.EntityFrameworkCore;
using Periferia.Web.App.Data;
using Periferia.Web.App.Service;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<PeriferiaWebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PeriferiaWebAppContext") ?? throw new InvalidOperationException("Connection string 'PeriferiaWebAppContext' not found.")));

builder.Services.AddHttpClient("GatewayWebApp", config =>
{
    config.BaseAddress = new Uri(builder.Configuration["Gateway:URL"]);
    config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
