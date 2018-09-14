using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArchitectureAspNetCoreEFMySQL.Core.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carros",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Marca = table.Column<string>(maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(maxLength: 50, nullable: false),
                    Cor = table.Column<string>(maxLength: 50, nullable: false),
                    AnoModelo = table.Column<string>(maxLength: 4, nullable: false),
                    AnoFabricacao = table.Column<string>(maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carros", x => x.Id);
                });

            migrationBuilder.Sql("INSERT INTO carros (Marca, Modelo, Cor, AnoModelo, AnoFabricacao) VALUES ('BMW', '118i', 'Cinza', '2012', '2012')");
            migrationBuilder.Sql("INSERT INTO carros (Marca, Modelo, Cor, AnoModelo, AnoFabricacao) VALUES ('Mercedes-Benz', 'A200', 'Cinza', '2015', '2015')");
            migrationBuilder.Sql("INSERT INTO carros (Marca, Modelo, Cor, AnoModelo, AnoFabricacao) VALUES ('GM', 'Onix', 'Prata', '2013', '2014')");
            migrationBuilder.Sql("INSERT INTO carros (Marca, Modelo, Cor, AnoModelo, AnoFabricacao) VALUES ('GM', 'Cruze', 'Cinza', '2014', '2014')");
            migrationBuilder.Sql("INSERT INTO carros (Marca, Modelo, Cor, AnoModelo, AnoFabricacao) VALUES ('GM', 'Tracker', 'Vinho', '2013', '2013')");
            migrationBuilder.Sql("INSERT INTO carros (Marca, Modelo, Cor, AnoModelo, AnoFabricacao) VALUES ('VW', 'Polo', 'Prata', '2018', '2018')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carros");
        }
    }
}
