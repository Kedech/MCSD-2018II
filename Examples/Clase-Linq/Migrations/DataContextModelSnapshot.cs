﻿// <auto-generated />
using System;
using Clase_Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clase_Linq.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Clase_Linq.Models.Lista", b =>
                {
                    b.Property<Guid>("ListaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre");

                    b.HasKey("ListaId");

                    b.ToTable("Listas");
                });

            modelBuilder.Entity("Clase_Linq.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<Guid>("ListaId");

                    b.HasKey("TareaId");

                    b.HasIndex("ListaId");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("Clase_Linq.Models.Tarea", b =>
                {
                    b.HasOne("Clase_Linq.Models.Lista", "ListaPadre")
                        .WithMany("Tareas")
                        .HasForeignKey("ListaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
