using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrincessChoice.Migrations
{
    /// <inheritdoc />
    public partial class CreateAttempts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrinceAttempt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AttemptName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrinceAttempt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    SequenceNumber = table.Column<int>(type: "integer", nullable: false),
                    AttemptEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contender", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contender_PrinceAttempt_AttemptEntityId",
                        column: x => x.AttemptEntityId,
                        principalTable: "PrinceAttempt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contender_AttemptEntityId",
                table: "Contender",
                column: "AttemptEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contender");

            migrationBuilder.DropTable(
                name: "PrinceAttempt");
        }
    }
}
