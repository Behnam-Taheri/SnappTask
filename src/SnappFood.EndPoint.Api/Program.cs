using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Caching.Memory;
using SnappFood.Application.Contract.IServices;
using SnappFood.Application.Services;
using SnappFood.Domain.Orders.Contracts;
using SnappFood.Domain.Products.Contracts;
using SnappFood.DomainServices.Products;
using SnappFood.Framework.Core.Abstractions;
using SnappFood.Persistence.EF;
using SnappFood.Persistence.EF.Orders;
using SnappFood.Persistence.EF.Products;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache(x => new MemoryCacheEntryOptions()
        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
        .SetPriority(CacheItemPriority.Normal));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTitleDuplicateChecker, ProductTitleDuplicateChecker>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



AddContext(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();



static void AddContext(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<SnappContext>(options =>
    {

        options.UseNpgsql(builder.Configuration.GetConnectionString("SnappTaskDB"), sqlOptions =>
        {
            sqlOptions.MigrationsAssembly(typeof(SnappContext).Assembly.FullName);
        });


        if (builder.Environment.IsProduction()) return;

        options.EnableDetailedErrors();
        options.EnableSensitiveDataLogging();
        options.ConfigureWarnings(warningLog =>
        {
            warningLog.Log(CoreEventId.FirstWithoutOrderByAndFilterWarning,
                CoreEventId.RowLimitingOperationWithoutOrderByWarning);
        });
    });
}