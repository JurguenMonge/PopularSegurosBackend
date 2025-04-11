using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PolizasService.Data;
using PolizasService.Interfaces;
using PolizasService.Repository;
using PolizasService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Polizas API",
        Version = "v1",
        Description = "API para gestionar pólizas de seguros. Permite realizar operaciones CRUD sobre pólizas.",
        Contact = new OpenApiContact
        {
            Name = "Jurguen Monge",
            Email = "jurguen.monge.rojas@gmail.com",
            Url = new Uri("https://github.com/JurguenMonge")
        }
    });
});

builder.Services.AddCors(options => {
    options.AddPolicy("AllowSpecificOrigins", policy => {
        policy.WithOrigins("http://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});



builder.Services.AddDbContext<PolizaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<ICoverageRepository, CoverageRepository>();
builder.Services.AddScoped<IStatePolicyRepository, StatePolicyRepository>();
builder.Services.AddScoped<ITypePolicyRepository, TypePolicyRepository>();
builder.Services.AddScoped<IPolicyRepository, PolicyRepository>();
builder.Services.AddScoped<IPolicyService, PolicyService>();

builder.Services.AddHttpClient<IClientService, ClientService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7076/api/"); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowSpecificOrigins");

app.MapControllers();

app.Run();
