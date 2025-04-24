using Business.AutoMapper;
using Business.Services;
using Data.Interfaces;
using Data.Repository;
using Data.Services;
using Entity.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
    {
        politica.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});

// Configurar Controladores y JSON
builder.Services.AddControllers();

// Configurar Swagger con soporte para JWT
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mi API", Version = "v1" });

    // JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresa tu token JWT como: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

// Configurar AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

// Servicios de negocio
builder.Services.AddScoped<RolFormPermissionService>();
builder.Services.AddScoped<RolService>();
builder.Services.AddScoped<FormService>();
builder.Services.AddScoped<PermissionService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ModuleService>();
builder.Services.AddScoped<RolUserService>();
builder.Services.AddScoped<FormModuleService>();
builder.Services.AddScoped<AuthService>(); // ?? Registro faltante

// Servicios de datos
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

// Configuración de JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtSettings = builder.Configuration.GetSection("JwtSettings");
        Console.WriteLine("JWT SecretKey configurada: " + (string.IsNullOrEmpty(jwtSettings["SecretKey"]) ? "NO DISPONIBLE" : "DISPONIBLE"));

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSettings["SecretKey"] ?? throw new InvalidOperationException("La clave secreta JWT no está configurada"))
            )
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication(); // ¡IMPORTANTE! Debe ir antes de UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
