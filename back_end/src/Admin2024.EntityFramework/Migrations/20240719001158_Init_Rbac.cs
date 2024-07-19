using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Admin2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Init_Rbac : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    operation_id = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9201)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9451)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    resource_id = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5173)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5366)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_name = table.Column<string>(type: "text", nullable: false),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7632)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7825)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(9991)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(238)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5144)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5320)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    NickName = table.Column<string>(type: "text", nullable: true),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    salt = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    telephone = table.Column<string>(type: "text", nullable: true),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2467)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2689)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    permission_name = table.Column<string>(type: "text", nullable: false),
                    resource_id = table.Column<Guid>(type: "uuid", nullable: false),
                    operation_id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: true),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2457)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2700)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_Permission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_name", "update_at", "update_by" },
                values: new object[,]
                {
                    { new Guid("0692d3a1-fde7-47de-9fb2-5e536c79d723"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7447), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7447), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("15db577a-8812-40f9-aad9-6eed34005e28"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7450), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7450), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4ea7b1a8-946e-4d41-bed2-2278729a0e4c"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7452), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7452), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("30de7cba-e85a-4da8-b074-36f4a3754d81"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7484), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("0692d3a1-fde7-47de-9fb2-5e536c79d723"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7485), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("380c3392-c8d6-4002-aa20-6daf9103074c") },
                    { new Guid("92b02cca-4d06-47c7-8d0c-2b0b5dd974bf"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7487), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("15db577a-8812-40f9-aad9-6eed34005e28"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7487), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("dfebd047-d931-4b85-929f-55835c3e36b9") },
                    { new Guid("c280c2af-fd98-4b4e-9b4d-4fbc2234f3e9"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7489), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("4ea7b1a8-946e-4d41-bed2-2278729a0e4c"), new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7490), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("380c3392-c8d6-4002-aa20-6daf9103074c"), null, new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7245), new Guid("380c3392-c8d6-4002-aa20-6daf9103074c"), "abc@123456.com", true, "超级管理员", "crGs4ESr1NUd31yUPadkXguTAgHsnSlT2OSc15BrB3s=", "aaa", "Y8o9LzwTFGwVlwMjSPx81A==", "12345678910", new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7247), new Guid("380c3392-c8d6-4002-aa20-6daf9103074c"), "admin" },
                    { new Guid("dfebd047-d931-4b85-929f-55835c3e36b9"), null, new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7251), new Guid("dfebd047-d931-4b85-929f-55835c3e36b9"), "abc@123456.com", true, "管理员", "abc123456", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7251), new Guid("dfebd047-d931-4b85-929f-55835c3e36b9"), "svip001" },
                    { new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7"), null, new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7254), new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7"), "abc@123456.com", true, "普通用户", "abc123456", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7254), new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7"), "svip001" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
