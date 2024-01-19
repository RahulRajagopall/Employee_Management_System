using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ems.Migrations
{
    /// <inheritdoc />
    public partial class TaskBaseCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskBase",
                columns: table => new
                {
                    Task = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeadLine = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBase", x => x.Task);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskBase");
        }
    }
}
