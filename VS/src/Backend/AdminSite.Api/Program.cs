using HashidsNet;
using AdminSite.Api.Filtros;
using AdminSite.Api.Filtros.Swagger;
using AdminSite.Api.Filtros.UsuarioLogado;
using AdminSite.Api.Middleware;
using AdminSite.Api.WebSockets;
using AdminSite.Application;
using AdminSite.Application.Servicos.Automapper;
using AdminSite.Domain.Extension;
using AdminSite.Infrastructure;
using AdminSite.Infrastructure.AcessoRepositorio;
using AdminSite.Infrastructure.Migrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddRouting(option => option.LowercaseUrls = true);

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.OperationFilter<HashidsOperationFilter>();
    option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Meu Livro de Receitas API", Version = "1.0"});
    option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header utilizando o Bearer scheme. Example: \"Authorization: Bearer {token}\""
    });
    option.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            System.Array.Empty<string>()
        }
    });
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);

builder.Services.AddMvc(options => options.Filters.Add(typeof(FiltroDasExceptions)));

builder.Services.AddScoped(provider => new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfiguracao(provider.GetService<IHashids>()));
}).CreateMapper());


builder.Services.AddScoped<IAuthorizationHandler, UsuarioLogadoHandler>();
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("UsuarioLogado", policy => policy.Requirements.Add(new UsuarioLogadoRequirement()));
});
builder.Services.AddScoped<UsuarioAutenticadoAttribute>();

builder.Services.AddHealthChecks().AddDbContextCheck<AdminSiteContext>();

builder.Services.AddSignalR();

var app = builder.Build();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    AllowCachingResponses = false,
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
    }
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseMiddleware<CultureMiddleware>();

app.MapHub<AdicionarConexao>("/addConexao");

app.Run();

#pragma warning disable CA1050, S3903, S1118
public partial class Program { }
#pragma warning restore CA1050, S3903, S1118