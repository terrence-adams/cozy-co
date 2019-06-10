using Microsoft.EntityFrameworkCore.Migrations;

namespace CozyCo.Data.Migrations
{
    public partial class IdentityRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dd6d069-f907-40e3-812a-a3b63aee0f66");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "153644fb-5250-426f-8d60-fb21d629d2fa");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a72a7970-f4e2-4b85-88b4-0aff1cb87cc1", "17827f27-529c-49fc-bd72-39354a843f5a", "Tenant", "Tenant" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "30014e5d-e388-4a61-8b6a-d7afe3ff24f3", "b6c3adcf-dd1c-4ff5-a79f-83b80152b1e4", "Landlord", "LANDLORD" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30014e5d-e388-4a61-8b6a-d7afe3ff24f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a72a7970-f4e2-4b85-88b4-0aff1cb87cc1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "153644fb-5250-426f-8d60-fb21d629d2fa", "dc9a7f2e-9f4f-4e97-87cc-4791a11a736c", "Tenant", "Tenant" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0dd6d069-f907-40e3-812a-a3b63aee0f66", "01833efd-be21-43aa-ac4f-2b31b38f96c5", "Landlord", "LANDLORD" });
        }
    }
}
