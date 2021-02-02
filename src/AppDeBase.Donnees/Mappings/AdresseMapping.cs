using AppDeBase.Affaires.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppDeBase.Donnees.Mappings
{
    public class AdresseMapping : IEntityTypeConfiguration<Adresse>
    {
        public void Configure(EntityTypeBuilder<Adresse> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Rue)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(a => a.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.CodePostal)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(a => a.Complement)
                .HasColumnType("varchar(250)");

            builder.Property(a => a.Ville)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.Province)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Adresses");
        }
    }
}