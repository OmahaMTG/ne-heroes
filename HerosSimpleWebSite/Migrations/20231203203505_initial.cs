using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heros.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    War = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagReceiveStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagReceivedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlagSponsor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthMonth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfPassing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreeStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreeLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreeLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CauseOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationOfDeath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCounty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginRegionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginRegionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginDevisionCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginDivisionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginStateFipsCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginStateName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountyCodeFips = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
