using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ghinelli.johan._5h.Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class primaversione : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Marca = table.Column<string>(type: "TEXT", nullable: true),
                    Anno = table.Column<string>(type: "TEXT", nullable: true),
                    Cilindrata = table.Column<string>(type: "TEXT", nullable: true),
                    Prezzo = table.Column<string>(type: "TEXT", nullable: true),
                    Chilometraggio = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utenti");
        }
    }
}
