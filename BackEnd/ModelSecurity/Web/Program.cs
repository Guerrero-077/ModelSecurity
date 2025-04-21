using Business.AutoMapper;
using Business.Services;
using Data.Interfaces;
using Data.Repository;
using Data.Services;
using Entity.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/// <summary>
/// Configuración de CORS
/// </summary>

var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
    {
        politica.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});

/// <summary>
/// Agregar el servicio de AutoMapper
/// </summary>

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

/// <summary>
/// Implementación de los servicios de negocio
/// </summary>
builder.Services.AddScoped<RolFormPermissionService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<FormService>();
builder.Services.AddScoped<PermissionService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ModuleService>();
builder.Services.AddScoped<RolUserService>();
builder.Services.AddScoped<FormModuleService>();


/// <summary>
/// Implementación de los servicios de acceso a datos
/// </summary>

builder.Services.AddScoped(typeof(IData<>), typeof(DataGeneric<>));
builder.Services.AddScoped<IRolFormPermissionRepository, RolFormPermissionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRolUserRepository, RolUserRepository>();
builder.Services.AddScoped<IFormModuleRepository, FormModuleRepository>();



// Configuración de Base de Datos
string databaseProvider = builder.Configuration["DatabaseProvider"];
string connectionString = builder.Configuration.GetConnectionString(databaseProvider);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    switch (databaseProvider)
    {
        case "SqlServer":
            options.UseSqlServer(connectionString);
            break;
        case "PostgreSql":
            options.UseNpgsql(connectionString);
            break;
        case "MySql":
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            break;
        default:
            throw new InvalidOperationException("Proveedor de base de datos no soportado");
    }
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
