using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Project.Migrations
{
    /// <inheritdoc />
    public partial class Add_Nurse_to_User_hierarchy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nurse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Certificates = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nurse_MedicalWorker_Id",
                        column: x => x.Id,
                        principalTable: "MedicalWorker",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nurse");
        }
    }
}
