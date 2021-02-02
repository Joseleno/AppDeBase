﻿// <auto-generated />
using System;
using AppDeBase.Donnees.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppDeBase.Donnees.Migrations
{
    [DbContext(typeof(AppDeBaseDbContext))]
    partial class AppDeBaseDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AppDeBase.Affaires.Models.Adresse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CodePostal")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(250)");

                    b.Property<Guid>("FournisseurId");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasConversion(new ValueConverter<string, string>(v => default(string), v => default(string), new ConverterMappingHints(size: 64)))
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Rue")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Ville")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("FournisseurId")
                        .IsUnique();

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("AppDeBase.Affaires.Models.Fournisseur", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Acitve");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TypeFournisseur");

                    b.HasKey("Id");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("AppDeBase.Affaires.Models.Produit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<DateTime>("DateInscription");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<Guid>("FournisseurId");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("Valeur");

                    b.HasKey("Id");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Produits");
                });

            modelBuilder.Entity("AppDeBase.Affaires.Models.Adresse", b =>
                {
                    b.HasOne("AppDeBase.Affaires.Models.Fournisseur", "Fournisseur")
                        .WithOne("Adresse")
                        .HasForeignKey("AppDeBase.Affaires.Models.Adresse", "FournisseurId");
                });

            modelBuilder.Entity("AppDeBase.Affaires.Models.Produit", b =>
                {
                    b.HasOne("AppDeBase.Affaires.Models.Fournisseur", "Fournisseur")
                        .WithMany("Produits")
                        .HasForeignKey("FournisseurId");
                });
#pragma warning restore 612, 618
        }
    }
}