using Microsoft.EntityFrameworkCore;
using Mulungu.Loja.Domain.Contracts;
using Mulungu.Loja.Infra.Repositories.Impl.Context;
using Mulungu.Loja.Infra.Repositories.Impl.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextPool<StoreDbContext>(e =>
{
    //e.UseMySql(builder.Configuration.GetConnectionString("StoreConnection"));
    //options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    var connectionString = "Server=127.0.0.1; Database=dbtest; Uid=root; Pwd=root;";
    e.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
}); 

// Change the registration of StoreDbContext to singleton
builder.Services.AddSingleton<StoreDbContext>();

// Register IProductRepository with the desired lifetime (e.g., scoped)
builder.Services.AddScoped<IProductRepository, ProductRepository>(); 

// !! builder.Services.AddSingleton<IProductRepository, ProductRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.BuildServiceProvider().CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>().Database.Migrate();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();