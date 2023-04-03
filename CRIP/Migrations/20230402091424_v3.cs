using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRIP.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Goods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308660dc-ae51-480f-824d-7dca6714c3e2",
                column: "ConcurrencyStamp",
                value: "ca0d277d-f203-40d8-baee-600b77917e9a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce82c36a-ca40-8e0a-3b89-53dc06850c3c",
                column: "ConcurrencyStamp",
                value: "8e7eab60-2111-452f-a5be-a27375c90314");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48e149ee-a8bc-4bac-9d78-e4bdd2aba716", "AQAAAAEAACcQAAAAEMvVHS94I7FToSQenFoY4iV5Q73LRRrX//l7BzZgi9krin9K2HKtAl/4kV3rVCJDGg==", "75e87653-6a7b-49ee-a321-a5dd41ce2014" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Goods");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308660dc-ae51-480f-824d-7dca6714c3e2",
                column: "ConcurrencyStamp",
                value: "73a93903-19a8-4100-875d-efcca903b2bf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce82c36a-ca40-8e0a-3b89-53dc06850c3c",
                column: "ConcurrencyStamp",
                value: "2facbcbe-123b-4b9c-a3cd-8ad003d6dfb2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fcdbb208-6fc3-49b6-a040-a7f91f5b5bb7", "AQAAAAEAACcQAAAAEG/Z3OcQVneFsvhwyRdExOeSr9L+aiA3iPF4KQ41jtOyl0MgQ9W8YG6RX15KDvNuCw==", "5d5d229b-3893-43a2-ba38-dbdc2ff56d58" });
        }
    }
}
