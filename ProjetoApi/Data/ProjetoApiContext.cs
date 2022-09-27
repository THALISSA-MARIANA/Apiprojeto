using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoApi.Models;

namespace ProjetoApi.Data
{
    public class ProjetoApiContext : DbContext
    {
        public ProjetoApiContext (DbContextOptions<ProjetoApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetoApi.Models.Cadastro> Cadastro { get; set; } = default!;

        public DbSet<ProjetoApi.Models.Anuncio> Anuncio { get; set; }

        public DbSet<ProjetoApi.Models.Candidatura> Candidatura { get; set; }

        public DbSet<ProjetoApi.Models.HistoricoCandidatura> HistoricoCandidatura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Anuncio>()
                .HasOne(e => e.Anunciante)
                .WithMany(e => e.Anuncios)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<Candidatura>()
                .HasOne(e => e.Candidato)
                .WithMany(e => e.Candidaturas)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<HistoricoCandidatura>()
                .HasOne(e => e.Candidatura)
                .WithMany(e => e.Historico)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
