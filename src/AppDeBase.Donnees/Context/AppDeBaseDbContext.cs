using AppDeBase.Affaires.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppDeBase.Donnees.Context
{
    public class AppDeBaseDbContext : DbContext
    {
        public AppDeBaseDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Adresse> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            {
                property.Relational().ColumnType = "varchar(100)";
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDeBaseDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}