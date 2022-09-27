using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi.Models;
namespace ProjetoApi;

public static class HistoricoCandidaturasEndpoints
{
    public static void MapHistoricoCandidaturaEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/HistoricoCandidatura", async (ProjetoApiContext db) =>
        {
            return await db.HistoricoCandidatura.ToListAsync();
        })
        .WithName("GetAllHistoricoCandidaturas");

        routes.MapGet("/api/HistoricoCandidatura/{id}", async (int Id, ProjetoApiContext db) =>
        {
            return await db.HistoricoCandidatura.FindAsync(Id)
                is HistoricoCandidatura model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetHistoricoCandidaturaById");

        routes.MapPut("/api/HistoricoCandidatura/{id}", async (int Id, HistoricoCandidatura historicoCandidatura, ProjetoApiContext db) =>
        {
            var foundModel = await db.HistoricoCandidatura.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateHistoricoCandidatura");

        routes.MapPost("/api/HistoricoCandidatura/", async (HistoricoCandidatura historicoCandidatura, ProjetoApiContext db) =>
        {
            db.HistoricoCandidatura.Add(historicoCandidatura);
            await db.SaveChangesAsync();
            return Results.Created($"/HistoricoCandidaturas/{historicoCandidatura.Id}", historicoCandidatura);
        })
        .WithName("CreateHistoricoCandidatura");

        routes.MapDelete("/api/HistoricoCandidatura/{id}", async (int Id, ProjetoApiContext db) =>
        {
            if (await db.HistoricoCandidatura.FindAsync(Id) is HistoricoCandidatura historicoCandidatura)
            {
                db.HistoricoCandidatura.Remove(historicoCandidatura);
                await db.SaveChangesAsync();
                return Results.Ok(historicoCandidatura);
            }

            return Results.NotFound();
        })
        .WithName("DeleteHistoricoCandidatura");
    }
}
