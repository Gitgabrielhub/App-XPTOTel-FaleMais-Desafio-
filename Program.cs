using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using XPTOTel.Application.Services;
using XPTOTel.Domain.Interfaces;
using XPTOTel.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();

// Add repositories
builder.Services.AddSingleton<IUserRepository, InMemoryUser Repository>();
builder.Services.AddSingleton<IPlanoFaleMaisRepository, InMemoryPlanoFaleMaisRepository>();
builder.Services.AddSingleton<ITarifaRepository, InMemoryTarifaRepository>();

// Add application services
builder.Services.AddScoped<CalculadoraTarifaService>();

// JWT Authentication
var key = Encoding.ASCII.GetBytes("SuaChaveSecretaSuperSecreta123!"); // Trocar para config segura
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ClientOnly", policy => policy.RequireRole("Client"));
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

