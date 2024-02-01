using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Migrations
{
    /// <inheritdoc />
    public partial class UpdateConfigurationItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationItems_ConfigurationItems_ParentId",
                table: "ConfigurationItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationItems",
                table: "ConfigurationItems");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationItems_ParentId",
                table: "ConfigurationItems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ConfigurationItems");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "ConfigurationItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ConfigurationItems",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ConfigurationItemName",
                table: "ConfigurationItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationItems",
                table: "ConfigurationItems",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationItems_ConfigurationItemName",
                table: "ConfigurationItems",
                column: "ConfigurationItemName");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationItems_ConfigurationItems_ConfigurationItemName",
                table: "ConfigurationItems",
                column: "ConfigurationItemName",
                principalTable: "ConfigurationItems",
                principalColumn: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConfigurationItems_ConfigurationItems_ConfigurationItemName",
                table: "ConfigurationItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConfigurationItems",
                table: "ConfigurationItems");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationItems_ConfigurationItemName",
                table: "ConfigurationItems");

            migrationBuilder.DropColumn(
                name: "ConfigurationItemName",
                table: "ConfigurationItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ConfigurationItems",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ConfigurationItems",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "ConfigurationItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConfigurationItems",
                table: "ConfigurationItems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationItems_ParentId",
                table: "ConfigurationItems",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConfigurationItems_ConfigurationItems_ParentId",
                table: "ConfigurationItems",
                column: "ParentId",
                principalTable: "ConfigurationItems",
                principalColumn: "Id");
        }
    }
}
