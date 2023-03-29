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
            migrationBuilder.DropColumn(
                name: "TransactionMetadata",
                table: "Orders");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionMetadata",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308660dc-ae51-480f-824d-7dca6714c3e2",
                column: "ConcurrencyStamp",
                value: "51bd7448-725c-4303-a02a-eb6dddf9478b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce82c36a-ca40-8e0a-3b89-53dc06850c3c",
                column: "ConcurrencyStamp",
                value: "014a7622-231b-4339-94b1-075e918bd7f1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90184155-dee0-40c9-bb1e-b5ed07afc04e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ebba6ea1-28b6-4d5a-b696-021c57b9d63a", "AQAAAAEAACcQAAAAEKWbLxvWteZUQ+W3Gmeuh5kzV069y2qlDxjRHZkA8Z1+5hHsrTUb3MfYlR/yE52GeA==", "e44b0fee-1fd7-45eb-81a5-5e2c082e2f2a" });
        }
    }
}
