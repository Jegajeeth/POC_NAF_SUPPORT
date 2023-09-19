using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NAFSupport.Server.Migrations
{
    /// <inheritdoc />
    public partial class migTen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    departmentRefId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.departmentRefId);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    roleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.roleId);
                });

            migrationBuilder.CreateTable(
                name: "userDetails",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    departmentRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userDetails", x => x.id);
                    table.ForeignKey(
                        name: "FK_userDetails_department_departmentRefId",
                        column: x => x.departmentRefId,
                        principalTable: "department",
                        principalColumn: "departmentRefId");
                    table.ForeignKey(
                        name: "FK_userDetails_role_roleId",
                        column: x => x.roleId,
                        principalTable: "role",
                        principalColumn: "roleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_departmentRefId",
                table: "userDetails",
                column: "departmentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_userDetails_roleId",
                table: "userDetails",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "userDetails");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "role");
        }
    }
}
