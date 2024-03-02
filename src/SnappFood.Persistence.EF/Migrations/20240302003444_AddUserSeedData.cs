using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnappFood.Persistence.EF.Migrations
{
    public partial class AddUserSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("74102bf9-83a3-453e-b3a4-391e759021bc"), "Sajjad" },
                    { new Guid("969f8d50-fa64-4bce-84f9-9a86193b99f8"), "Tooraj" },
                    { new Guid("a996d0da-0c5e-4d3b-bcc1-3aa468f61c04"), "Behnam" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("74102bf9-83a3-453e-b3a4-391e759021bc"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("969f8d50-fa64-4bce-84f9-9a86193b99f8"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("a996d0da-0c5e-4d3b-bcc1-3aa468f61c04"));
        }
    }
}
