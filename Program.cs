using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using miniapiaspnetcore.Api.Endpoints;
using miniapiaspnetcore.Api.Middleware;
using miniapiaspnetcore.Application.Interfaces;
using miniapiaspnetcore.Application.Services;
using miniapiaspnetcore.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IClienteRepository, InMemoryClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapClientesEndpoints();

app.Run();