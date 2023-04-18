using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services;
using DataLayer;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddDbContext<EShopContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EShopContext")))
                .AddScoped<ICategoryService, CategoryService>()
                .AddScoped<IManufacturerService, ManufacturerService>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(30))
                .AddMemoryCache()
                .Configure<CookiePolicyOptions>(options =>
                {
                    options.Secure = CookieSecurePolicy.Always;
                    options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                })
                .AddRazorPages();

builder.Services.AddMvc();

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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
