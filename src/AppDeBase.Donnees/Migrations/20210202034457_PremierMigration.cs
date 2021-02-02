using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDeBase.Donnees.Migrations
{
    public partial class PremierMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(type: "varchar(200)", nullable: false),
                    Document = table.Column<string>(type: "varchar(15)", nullable: false),
                    TypeFournisseur = table.Column<int>(nullable: false),
                    Acitve = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FournisseurId = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Rue = table.Column<string>(type: "varchar(200)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(250)", nullable: true),
                    CodePostal = table.Column<string>(type: "varchar(8)", nullable: false),
                    Ville = table.Column<string>(type: "varchar(100)", nullable: false),
                    Province = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FournisseurId = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(type: "varchar(200)", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: false),
                    Valeur = table.Column<decimal>(nullable: false),
                    DateInscription = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produits_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_FournisseurId",
                table: "Adresses",
                column: "FournisseurId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produits_FournisseurId",
                table: "Produits",
                column: "FournisseurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Fournisseurs");
        }
    }
}
