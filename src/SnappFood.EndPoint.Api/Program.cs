using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SnappFood.Application.Contract.IServices;
using SnappFood.Application.Services;
using SnappFood.Domain.Products.Contracts;
using SnappFood.DomainServices.Products;
using SnappFood.Persistence.EF;
using SnappFood.Persistence.EF.Products;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTitleDuplicateChecker, ProductTitleDuplicateChecker>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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