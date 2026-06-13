using miniapiaspnetcore.Application.DTOs;
using miniapiaspnetcore.Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace miniapiaspnetcore.Api.Endpoints
{
    public static class ClientesEndpoints
    {
        public static void MapClientesEndpoints(this WebApplication app)
        {
            app.MapGet("/clientes", async (IClienteService svc) =>
                Results.Ok(await svc.GetAllAsync()));

            app.MapGet("/clientes/{rfc}", async (string rfc, IClienteService svc) =>
            {
                var found = await svc.GetByRfcAsync(rfc);
                return found is null ? Results.NotFound() : Results.Ok(found);
            });

            app.MapGet("/clientes/estatus/{estatus}", async (string estatus, IClienteService svc) =>
                Results.Ok(await svc.GetByEstatusAsync(estatus)));

            app.MapPost("/clientes", async (ClienteCreateDto dto, IClienteService svc) =>
            {
                var created = await svc.CreateAsync(dto);
                return Results.Created($"/clientes/{created.Id}", created);
            });

            app.MapPut("/clientes/{id}/estatus", async (Guid id, EstatusUpdateDto dto, IClienteService svc) =>
            {
                var updated = await svc.ChangeEstatusAsync(id, dto.Estatus);
                return updated is null ? Results.NotFound() : Results.Ok(updated);
            });
        }
    }
}