using Microsoft.EntityFrameworkCore;
using ProjetoApi.Data;
using ProjetoApi.Models;
namespace ProjetoApi;

public static class CadastroEndpoints
{
    public static void MapCadastroEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Cadastro", async (ProjetoApiContext db) =>
        {
            return await db.Cadastro.ToListAsync();
        })
        .WithName("GetAllCadastros");

        routes.MapGet("/api/Cadastro/{id}", async (int Id, ProjetoApiContext db) =>
        {
            return await db.Cadastro.FindAsync(Id)
                is Cadastro model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetCadastroById");

        routes.MapPut("/api/Cadastro/{id}", async (int Id, Cadastro cadastro, ProjetoApiContext db) =>
        {
            var foundModel = await db.Cadastro.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCadastro");

        routes.MapPost("/api/Cadastro/", async (Cadastro cadastro, ProjetoApiContext db) =>
        {
            db.Cadastro.Add(cadastro);
            await db.SaveChangesAsync();
            return Results.Created($"/Cadastros/{cadastro.Id}", cadastro);
        })
        .WithName("CreateCadastro");

        routes.MapDelete("/api/Cadastro/{id}", async (int Id, ProjetoApiContext db) =>
        {
            if (await db.Cadastro.FindAsync(Id) is Cadastro cadastro)
            {
                db.Cadastro.Remove(cadastro);
                await db.SaveChangesAsync();
                return Results.Ok(cadastro);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCadastro");
    }
}
