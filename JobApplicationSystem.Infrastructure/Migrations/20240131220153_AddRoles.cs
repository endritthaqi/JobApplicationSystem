using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobApplicationSystem.Infrastructure.Migrations
{
    public partial class AddRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "252ef6d1-676f-4eda-950e-02abf3490518", "76db7f46-8eff-473c-b12c-82d3d23d141d", "RegistredUser", "REGISTREDUSER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "67e71ef9-1a30-44c7-8847-2f5b0b334cdb", "2409e958-271b-46bd-9131-ca002a64af3b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ee6e1bb-2782-4458-ba12-5ac5ae760698", "2639a155-7aed-4533-95c4-48d8ccd353f0", "Punedhenesi", "PUNEDHENESI" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "252ef6d1-676f-4eda-950e-02abf3490518");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67e71ef9-1a30-44c7-8847-2f5b0b334cdb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ee6e1bb-2782-4458-ba12-5ac5ae760698");
        }
    }
}
