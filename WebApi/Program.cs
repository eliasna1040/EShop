using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ServiceLayer.Services;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddScoped<IProductService, ProductService>()
    .AddScoped<ICategoryService, CategoryService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<ICustomerService, CustomerService>()
    .AddScoped<IManufacturerService, ManufacturerService>()
    .AddDbContext<EShopContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("EShopContext"))).AddSwaggerGen().AddEndpointsApiExplorer()
    .AddControllers().AddNewtonsoftJson()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"); options.RoutePrefix = string.Empty; });
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseBlazorFrameworkFiles();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
