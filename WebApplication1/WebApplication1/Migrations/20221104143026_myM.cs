using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    public partial class myM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThanhPhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThanhPho = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhPhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuanHuyens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenQuanHuyen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ThanhPhoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanHuyens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuanHuyens_ThanhPhos_ThanhPhoId",
                        column: x => x.ThanhPhoId,
                        principalTable: "ThanhPhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyens_TenQuanHuyen_ThanhPhoId",
                table: "QuanHuyens",
                columns: new[] { "TenQuanHuyen", "ThanhPhoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuanHuyens_ThanhPhoId",
                table: "QuanHuyens",
                column: "ThanhPhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhPhos_TenThanhPho",
                table: "ThanhPhos",
                column: "TenThanhPho",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuanHuyens");

            migrationBuilder.DropTable(
                name: "ThanhPhos");
        }
    }
}
