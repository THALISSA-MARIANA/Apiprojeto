﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoApi.Data;

#nullable disable

namespace ProjetoApi.Migrations
{
    [DbContext(typeof(ProjetoApiContext))]
    partial class ProjetoApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjetoApi.Models.Anuncio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnuncianteId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnuncianteId");

                    b.ToTable("Anuncio");
                });

            modelBuilder.Entity("ProjetoApi.Models.Cadastro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("CNH")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("CorenEnfermagem")
                        .HasColumnType("int");

                    b.Property<bool>("CursoCuidador")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<bool>("Fumante")
                        .HasColumnType("bit");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<string>("OrgaoExpedidor")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("UF")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cadastro");
                });

            modelBuilder.Entity("ProjetoApi.Models.Candidatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AnuncioId")
                        .HasColumnType("int");

                    b.Property<int>("CandidatoId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnuncioId");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Candidatura");
                });

            modelBuilder.Entity("ProjetoApi.Models.HistoricoCandidatura", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CandidaturaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDoStatus")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidaturaId");

                    b.ToTable("CandidaturaHistorico");
                });

            modelBuilder.Entity("ProjetoApi.Models.Anuncio", b =>
                {
                    b.HasOne("ProjetoApi.Models.Cadastro", "Anunciante")
                        .WithMany("Anuncios")
                        .HasForeignKey("AnuncianteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Anunciante");
                });

            modelBuilder.Entity("ProjetoApi.Models.Candidatura", b =>
                {
                    b.HasOne("ProjetoApi.Models.Anuncio", "Anuncio")
                        .WithMany("Candidaturas")
                        .HasForeignKey("AnuncioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjetoApi.Models.Cadastro", "Candidato")
                        .WithMany("Candidaturas")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Anuncio");

                    b.Navigation("Candidato");
                });

            modelBuilder.Entity("ProjetoApi.Models.HistoricoCandidatura", b =>
                {
                    b.HasOne("ProjetoApi.Models.Candidatura", "Candidatura")
                        .WithMany("Historico")
                        .HasForeignKey("CandidaturaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Candidatura");
                });

            modelBuilder.Entity("ProjetoApi.Models.Anuncio", b =>
                {
                    b.Navigation("Candidaturas");
                });

            modelBuilder.Entity("ProjetoApi.Models.Cadastro", b =>
                {
                    b.Navigation("Anuncios");

                    b.Navigation("Candidaturas");
                });

            modelBuilder.Entity("ProjetoApi.Models.Candidatura", b =>
                {
                    b.Navigation("Historico");
                });
#pragma warning restore 612, 618
        }
    }
}
