using Microsoft.EntityFrameworkCore.Migrations;

namespace CharityDB.net5.Migrations
{
    public partial class intitalcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    itemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clothes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    food = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.itemsId);
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    membersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membersName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.membersId);
                });

            migrationBuilder.CreateTable(
                name: "donations",
                columns: table => new
                {
                    donationsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donationPrice = table.Column<int>(type: "int", nullable: false),
                    donationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionID = table.Column<int>(type: "int", nullable: false),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banktype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    itemsId = table.Column<int>(type: "int", nullable: true),
                    membersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.donationsID);
                    table.ForeignKey(
                        name: "FK_donations_items_itemsId",
                        column: x => x.itemsId,
                        principalTable: "items",
                        principalColumn: "itemsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_donations_members_membersId",
                        column: x => x.membersId,
                        principalTable: "members",
                        principalColumn: "membersId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_donations_itemsId",
                table: "donations",
                column: "itemsId");

            migrationBuilder.CreateIndex(
                name: "IX_donations_membersId",
                table: "donations",
                column: "membersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "donations");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
