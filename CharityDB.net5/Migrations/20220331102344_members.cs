using Microsoft.EntityFrameworkCore.Migrations;

namespace CharityDB.net5.Migrations
{
    public partial class members : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    membersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    membersName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    donationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    donationPrice = table.Column<int>(type: "int", nullable: false),
                    donationDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionID = table.Column<int>(type: "int", nullable: false),
                    TransactionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Banktype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    membersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_donations", x => x.donationsID);
                    table.ForeignKey(
                        name: "FK_donations_members_membersId",
                        column: x => x.membersId,
                        principalTable: "members",
                        principalColumn: "membersId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "members");
        }
    }
}
