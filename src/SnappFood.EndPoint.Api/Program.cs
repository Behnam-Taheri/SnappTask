using SnappFood.Application.Contract.IServices;
using SnappFood.Application.Services;
using SnappFood.Domain.Products.Contracts;
using SnappFood.DomainServices.Products;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductTitleDuplicateChecker, ProductTitleDuplicateChecker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
