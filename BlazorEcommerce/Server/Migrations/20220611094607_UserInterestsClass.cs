using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class UserInterestsClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInterests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Books = table.Column<bool>(type: "bit", nullable: false),
                    Movies = table.Column<bool>(type: "bit", nullable: false),
                    VideoGames = table.Column<bool>(type: "bit", nullable: false),
                    Sports = table.Column<bool>(type: "bit", nullable: false),
                    Clothing = table.Column<bool>(type: "bit", nullable: false),
                    Default = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInterests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInterests_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "The Nike Hypervenom is a football boot manufactured by Nike. This type of boot is said to be for traction, power, and agility, designed for deceptive players. Therefore, it is endorsed/worn by players, notably forwards, such as Robert Lewandowski, Harry Kane, Edinson Cavani, Gonzalo Higuaín, Mauro Icardi and Thiago. In 2017, 18-year-old prodigy Kylian Mbappé was given his own personalised boots, the Nike Hypervenom 3.");

            migrationBuilder.CreateIndex(
                name: "IX_UserInterests_UserId",
                table: "UserInterests",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInterests");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "The Nike Hypervenom is a football boot manufactured by Nike. This type of boot is said to be for traction, power, and agility, designed for deceptive players. Therefore, it is endorsed/worn by players, notably forwards, such as Robert Lewandowski, Harry Kane, Edinson Cavani, Gonzalo Higuaín, Mauro Icardi and Thiago. In 2017, 18-year-old prodigy Kylian Mbappé was given his own personalised boots, Nike Hypervenom 3.");
        }
    }
}
