using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi.Models;
namespace ProjetoApi;

public static class AnunciosEndpoints
{
    public static void MapAnuncioEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Anuncio", async (ProjetoApiContext db) =>
        {
            return await db.Anuncio.ToListAsync();
        })
        .WithName("GetAllAnuncios");

        routes.MapGet("/api/Anuncio/{id}", async (int Id, ProjetoApiContext db) =>
        {
            return await db.Anuncio.FindAsync(Id)
                is Anuncio model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetAnuncioById");

        routes.MapPut("/api/Anuncio/{id}", async (int Id, Anuncio anuncio, ProjetoApiContext db) =>
        {
            var foundModel = await db.Anuncio.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateAnuncio");

        routes.MapPost("/api/Anuncio/", async (Anuncio anuncio, ProjetoApiContext db) =>
        {
            db.Anuncio.Add(anuncio);
            await db.SaveChangesAsync();
            return Results.Created($"/Anuncios/{anuncio.Id}", anuncio);
        })
        .WithName("CreateAnuncio");

        routes.MapDelete("/api/Anuncio/{id}", async (int Id, ProjetoApiContext db) =>
        {
            if (await db.Anuncio.FindAsync(Id) is Anuncio anuncio)
            {
                db.Anuncio.Remove(anuncio);
                await db.SaveChangesAsync();
                return Results.Ok(anuncio);
            }

            return Results.NotFound();
        })
        .WithName("DeleteAnuncio");
    }
}
