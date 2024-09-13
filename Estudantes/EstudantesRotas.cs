using ApiCrud.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using System.Net.Security;

namespace ApiCrud.Estudantes
{
    public static class EstudantesRotas
    {
        public static void AddRotasEstudantes(this WebApplication app)
        {
            var rotasEstudantes = app.MapGroup(prefix: "estudantes");

            //para criar o se usa Post
            rotasEstudantes.MapPost("", handler: async (AddEstudanteRequest request, AppDbContext context, CancellationToken ct) =>
            {
                var jaExiste = await context.Estudantes.AnyAsync(estudante => estudante.Nome == request.Nome, ct);

                if (jaExiste)
                    return Results.Conflict("ja existe!");
                var novoEstudante = new Estudante(request.Nome);

                await context.Estudantes.AddAsync(novoEstudante, ct);
                await context.SaveChangesAsync(ct);

                var estudanteRetorno = new EstudanteDto(novoEstudante.Id, novoEstudante.Nome);
                return Results.Ok(novoEstudante);
            });

            //Retornar todos os estudantes cadastrados
            rotasEstudantes.MapGet("", async (AppDbContext context, CancellationToken ct) =>
            {
                var estudantes = await context //AppDbContext
                .Estudantes //DbSet<estudante>
                .Where(estudante => estudante.Ativo)// Iqueryable<Estudante>
                .Select(estudante => new EstudanteDto(estudante.Id, estudante.Nome))
                .ToListAsync(ct);//Task<List<>>

                return estudantes;

            });

            //Atualizar nome estudante
            rotasEstudantes.MapPut("{id:guid}",
                async (Guid id, UpdateEstudanteRequest request, AppDbContext context, CancellationToken ct) =>
                       {
                           var estudante = await context.Estudantes //DbSet<Estudante>
                           .SingleOrDefaultAsync(estudante => estudante.Id == id);//Task<estudante?>

                           if (estudante == null)
                               return Results.NotFound();

                           estudante.AtualizarNome(request.Nome);

                           await context.SaveChangesAsync(ct);
                           return Results.Ok(new EstudanteDto(estudante.Id, estudante.Nome));

                });

            //Deletar
            rotasEstudantes.MapDelete("{id}", async (Guid id, AppDbContext context, CancellationToken ct) =>
            {
                var estudante = await context.Estudantes //DbSet<Estudantes>
                    .SingleOrDefaultAsync(estudante => estudante.Id == id, ct);//task<estudante?>

                if (estudante == null)
                    return Results.NotFound();

                estudante.Desativar();

                await context.SaveChangesAsync(ct);
                return Results.Ok();
            });
            }  

        }

    }

