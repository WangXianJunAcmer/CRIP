using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRIP.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308660dc-ae51-480f-824d-7dca6714c3e2",
                column: "ConcurrencyStamp",
                value: "b180a09a-e301-453f-b240-c72f38528b41");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce82c36a-ca40-8e0a-3b89-53dc06850c3c",
                column: "ConcurrencyStamp",
                value: "af6fb748-9e24-4e84-acfd-0064f10278ba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b91d85d0-66a3-463a-a19c-72ab1b09158e", "AQAAAAEAACcQAAAAEKTYPl48WHXAwyrAvFV02dRwlorWsrZyLm7WVZk6XKCRcz/EDOj0p9/y7G0shoe1Fg==", "4ec20084-9484-4c3a-9c2c-c6f244ea2621" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308660dc-ae51-480f-824d-7dca6714c3e2",
                column: "ConcurrencyStamp",
                value: "c9df4abd-82c2-41b0-9f5f-96da00ee2305");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce82c36a-ca40-8e0a-3b89-53dc06850c3c",
                column: "ConcurrencyStamp",
                value: "f00d4f6d-7f32-4113-ae2a-09f010f73a55");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c931672-fdd8-493b-94ab-ff88e32ff951", "AQAAAAEAACcQAAAAEPvVMX3Ar+gtie77NbzVcf7ELVvYrToWa+ed+q0ns9SMtFA05XTrGr1/4qZgqA6UzQ==", "23498e1c-643f-4236-8679-e6553b48db23" });
        }
    }
}
