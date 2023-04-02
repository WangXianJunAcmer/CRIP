using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRIP.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308660dc-ae51-480f-824d-7dca6714c3e2",
                column: "ConcurrencyStamp",
                value: "22192652-6401-42dd-861d-1a8df47ff451");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce82c36a-ca40-8e0a-3b89-53dc06850c3c",
                column: "ConcurrencyStamp",
                value: "b0e70354-d99c-48da-9bb4-39e9d587d0ad");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "123420dc-ae51-480f-824d-7dca6714c3e2", "9e69ecec-1520-45a1-abc2-bb53d63746fa", "Doctor", "DOCTOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                columns: new[] { "Address", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "科大", "63b8d5df-218b-4f5d-b42a-2777fde9189e", "AQAAAAEAACcQAAAAEHjU5Ertb9l09knRfFFcmjoBIIfAfI+lhZyOU6LsGaHYcgaf75U2JA0gKdB4TFCmGA==", "c842726a-28ae-438e-9ac0-9f57118ebc5e" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "123420dc-ae51-480f-824d-7dca6714c3e2");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

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
    }
}
