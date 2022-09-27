using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi.Models;
namespace ProjetoApi;

public static class CandidaturasEndpoints
{
    public static void MapCandidaturaEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Candidatura", async (ProjetoApiContext db) =>
        {
            return await db.Candidatura.ToListAsync();
        })
        .WithName("GetAllCandidaturas");

        routes.MapGet("/api/Candidatura/{id}", async (int Id, ProjetoApiContext db) =>
        {
            return await db.Candidatura.FindAsync(Id)
                is Candidatura model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCandidaturaById");

        routes.MapPut("/api/Candidatura/{id}", async (int Id, Candidatura candidatura, ProjetoApiContext db) =>
        {
            var foundModel = await db.Candidatura.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCandidatura");

        routes.MapPost("/api/Candidatura/", async (Candidatura candidatura, ProjetoApiContext db) =>
        {
            db.Candidatura.Add(candidatura);
            await db.SaveChangesAsync();
            return Results.Created($"/Candidaturas/{candidatura.Id}", candidatura);
        })
        .WithName("CreateCandidatura");

        routes.MapDelete("/api/Candidatura/{id}", async (int Id, ProjetoApiContext db) =>
        {
            if (await db.Candidatura.FindAsync(Id) is Candidatura candidatura)
            {
                db.Candidatura.Remove(candidatura);
                await db.SaveChangesAsync();
                return Results.Ok(candidatura);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCandidatura");
    }
}
