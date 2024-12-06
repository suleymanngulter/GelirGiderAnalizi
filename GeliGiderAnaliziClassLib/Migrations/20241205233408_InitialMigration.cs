using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace GeliGiderAnaliziClassLib.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GiderIslModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    GiderId = table.Column<int>(type: "int", nullable: true),
                    KasaId = table.Column<int>(type: "int", nullable: true),
                    EvrakNo = table.Column<string>(type: "longtext", nullable: true),
                    Aciklama = table.Column<string>(type: "longtext", nullable: true),
                    OdemeDurumu = table.Column<string>(type: "longtext", nullable: true),
                    OdemeSekli = table.Column<string>(type: "longtext", nullable: true),
                    SubeAdi = table.Column<string>(type: "longtext", nullable: true),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Tarih = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Turu = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiderIslModels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GiderModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AboneNo = table.Column<string>(type: "longtext", nullable: true),
                    GiderAciklama = table.Column<string>(type: "longtext", nullable: true),
                    GiderAdi = table.Column<string>(type: "longtext", nullable: true),
                    GiderKategori = table.Column<string>(type: "longtext", nullable: true),
                    GiderKodu = table.Column<string>(type: "longtext", nullable: true),
                    GiderTuru = table.Column<string>(type: "longtext", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "longtext", nullable: true),
                    SubeAdi = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiderModels", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoginModels",
                columns: table => new
                {
                    VergiNumarasi = table.Column<string>(type: "longtext", nullable: true),
                    KullaniciAdi = table.Column<string>(type: "longtext", nullable: true),
                    KullaniciSifre = table.Column<string>(type: "longtext", nullable: true),
                    VeritabaniAd = table.Column<string>(type: "longtext", nullable: true),
                    DonemYil = table.Column<string>(type: "longtext", nullable: true),
                    SubeAd = table.Column<string>(type: "longtext", nullable: true),
                    ApiKullaniciAdi = table.Column<string>(type: "longtext", nullable: true),
                    ApiKullaniciSifre = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiderIslModels");

            migrationBuilder.DropTable(
                name: "GiderModels");

            migrationBuilder.DropTable(
                name: "LoginModels");
        }
    }
}
