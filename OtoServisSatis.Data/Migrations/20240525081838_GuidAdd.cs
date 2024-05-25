using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtoServisSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class GuidAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserGuid",
                table: "Kullanicilar",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EklenmeTarihi", "UserGuid" },
                values: new object[] { new DateTime(2024, 5, 25, 11, 18, 38, 783, DateTimeKind.Local).AddTicks(6679), new Guid("ba0826ef-247b-4081-ae5f-9bcbc0d05321") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserGuid",
                table: "Kullanicilar");

            migrationBuilder.UpdateData(
                table: "Kullanicilar",
                keyColumn: "Id",
                keyValue: 1,
                column: "EklenmeTarihi",
                value: new DateTime(2024, 5, 23, 23, 15, 23, 575, DateTimeKind.Local).AddTicks(8755));
        }
    }
}
