using Microsoft.EntityFrameworkCore.Migrations;

namespace Morar_Antoniu_Lab8.Migrations
{
    public partial class BookCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Joc",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JocCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JocID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JocCategory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JocCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JocCategory_Joc_JocID",
                        column: x => x.JocID,
                        principalTable: "Joc",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Joc_PublisherID",
                table: "Joc",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_JocCategory_CategoryID",
                table: "JocCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_JocCategory_JocID",
                table: "JocCategory",
                column: "JocID");

            migrationBuilder.AddForeignKey(
                name: "FK_Joc_Publisher_PublisherID",
                table: "Joc",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Joc_Publisher_PublisherID",
                table: "Joc");

            migrationBuilder.DropTable(
                name: "JocCategory");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Joc_PublisherID",
                table: "Joc");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Joc");
        }
    }
}
