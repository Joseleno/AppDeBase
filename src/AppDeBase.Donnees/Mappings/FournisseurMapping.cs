using AppDeBase.Affaires.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDeBase.Donnees.Mappings
{
    public class FournisseurMapping : IEntityTypeConfiguration<Fournisseur>

    {
        public void Configure(EntityTypeBuilder<Fournisseur> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Nom)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(f => f.Document)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.HasOne(f => f.Adresse)
                .WithOne(a => a.Fournisseur);

            builder.HasMany(f => f.Produits)
                .WithOne(p => p.Fournisseur)
                .HasForeignKey(p => p.FournisseurId);

            builder.ToTable("Fournisseurs");
        }
    }
}