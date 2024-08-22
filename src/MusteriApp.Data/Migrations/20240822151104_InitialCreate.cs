using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusteriApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "musteri_tanim_table",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UNVAN = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteri_tanim_table", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "musteri_fatura_table",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MUSTERI_ID = table.Column<int>(type: "int", nullable: false),
                    FATURA_TARIHI = table.Column<DateTime>(type: "date", nullable: false),
                    FATURA_TUTARI = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ODEME_TARIHI = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_musteri_fatura_table", x => x.ID);
                    table.ForeignKey(
                        name: "FK_musteri_fatura_table_musteri_tanim_table_MUSTERI_ID",
                        column: x => x.MUSTERI_ID,
                        principalTable: "musteri_tanim_table",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_musteri_fatura_table_MUSTERI_ID",
                table: "musteri_fatura_table",
                column: "MUSTERI_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "musteri_fatura_table");

            migrationBuilder.DropTable(
                name: "musteri_tanim_table");
        }
    }
}
