﻿// <auto-generated />
using ConsoleEFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ConsoleEFCore.Migrations
{
    [DbContext(typeof(HospitalContext))]
    partial class HospitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ConsoleEFCore.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Diagnostico")
                        .HasColumnType("text");

                    b.Property<int>("PacienteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("Consultas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Diagnostico = "Ficar longe de formiga",
                            PacienteId = 1
                        });
                });

            modelBuilder.Entity("ConsoleEFCore.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Alergias")
                        .HasColumnType("text");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("Sexo")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alergias = "Abelha;Formiga",
                            Idade = 38,
                            Nome = "Carlos Eduardo",
                            Sexo = 0
                        });
                });

            modelBuilder.Entity("ConsoleEFCore.Consulta", b =>
                {
                    b.HasOne("ConsoleEFCore.Paciente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Paciente");
                });
#pragma warning restore 612, 618
        }
    }
}