using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailSystem.Migrations
{
    /// <inheritdoc />
    public partial class EmailDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    To = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cc = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAttachment = table.Column<bool>(type: "bit", nullable: false),
                    SentDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailDetails", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailDetails");
        }
    }
}
