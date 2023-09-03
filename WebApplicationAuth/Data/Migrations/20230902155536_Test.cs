using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationAuth.Data.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    CODE_CATEGORIE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LIBELLE_CATEGORIE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_SAISIE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.CODE_CATEGORIE);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    CODE_PRODUIT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LIBELLE_PRODUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DESCRIPTION_PRODUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IMAGE_PRODUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL_IMAGE_PRODUIT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DATE_SAISIE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategorieCODE_CATEGORIE = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.CODE_PRODUIT);
                    table.ForeignKey(
                        name: "FK_Produit_Categorie_CategorieCODE_CATEGORIE",
                        column: x => x.CategorieCODE_CATEGORIE,
                        principalTable: "Categorie",
                        principalColumn: "CODE_CATEGORIE",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produit_CategorieCODE_CATEGORIE",
                table: "Produit",
                column: "CategorieCODE_CATEGORIE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Categorie");
        }
    }
}
