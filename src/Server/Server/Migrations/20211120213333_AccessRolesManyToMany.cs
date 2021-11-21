using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Server.Migrations
{
    public partial class AccessRolesManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_privileges_access_roles_access_role_id",
                table: "privileges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DropIndex(
                name: "ix_privileges_access_role_id",
                table: "privileges");

            migrationBuilder.DropColumn(
                name: "access_role_id",
                table: "privileges");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "id");

            migrationBuilder.CreateTable(
                name: "access_role_privilege",
                columns: table => new
                {
                    access_roles_id = table.Column<Guid>(type: "RAW(16)", nullable: false),
                    privileges_id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_access_role_privilege", x => new { x.access_roles_id, x.privileges_id });
                    table.ForeignKey(
                        name: "fk_access_role_privilege_access_roles_access_roles_id",
                        column: x => x.access_roles_id,
                        principalTable: "access_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_access_role_privilege_privileges_privileges_id",
                        column: x => x.privileges_id,
                        principalTable: "privileges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_access_role_privilege_privileges_id",
                table: "access_role_privilege",
                column: "privileges_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "access_role_privilege");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.AddColumn<Guid>(
                name: "access_role_id",
                table: "privileges",
                type: "RAW(16)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                columns: new[] { "id", "name" });

            migrationBuilder.CreateIndex(
                name: "ix_privileges_access_role_id",
                table: "privileges",
                column: "access_role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_privileges_access_roles_access_role_id",
                table: "privileges",
                column: "access_role_id",
                principalTable: "access_roles",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
