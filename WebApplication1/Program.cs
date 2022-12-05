using Aplication.Interfaces;
using Aplication.Interfaces.ICarrito;
using Aplication.Interfaces.ICarritoProducto;
using Aplication.Interfaces.IClient;
using Aplication.Interfaces.IOrden;
using Aplication.Interfaces.IProduct;
using Aplication.UseCase;
using Infrastructure.Command;
using Infrastructure.Persistence;
using Infrastructure.Querys;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//custom
var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICarritoService, CarritoService>();
builder.Services.AddScoped<IOrdenService, OrdenService>();

builder.Services.AddScoped<IClientQuery, ClientQuery>();
builder.Services.AddScoped<IProductQuery, ProductQuery>();
builder.Services.AddScoped<ICarritoQuery, CarritoQuery>();
builder.Services.AddScoped<IOrdenQuery, OrdenQuery>();
builder.Services.AddScoped<ICarritoProductoQuery, CarritoProductoQuery>();

builder.Services.AddScoped<IClientCommand, ClientCommand>();
builder.Services.AddScoped<ICarritoCommand, CarritoCommand>();
builder.Services.AddScoped<IOrdenCommand, OrdenCommand>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
