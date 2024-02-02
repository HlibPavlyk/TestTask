using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableConfigurationItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationItems",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfigurationItemName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationItems", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ConfigurationItems_ConfigurationItems_ConfigurationItemName",
                        column: x => x.ConfigurationItemName,
                        principalTable: "ConfigurationItems",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationItems_ConfigurationItemName",
                table: "ConfigurationItems",
                column: "ConfigurationItemName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationItems");
        }
    }
}
