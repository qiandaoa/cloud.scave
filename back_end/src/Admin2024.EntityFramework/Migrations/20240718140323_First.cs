<<<<<<<< HEAD:back_end/src/Admin2024.EntityFramework/Migrations/20240718140323_First.cs
﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 575, DateTimeKind.Utc).AddTicks(9164)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 575, DateTimeKind.Utc).AddTicks(9407)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 576, DateTimeKind.Utc).AddTicks(6065)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 576, DateTimeKind.Utc).AddTicks(6271)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.id);
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(1625)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(1831)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(7319)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(7599)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(4422)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(4631)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    role_name = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 576, DateTimeKind.Utc).AddTicks(8925)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 576, DateTimeKind.Utc).AddTicks(9161)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.id);
                    table.ForeignKey(
                        name: "FK_Role_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "id");
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 576, DateTimeKind.Utc).AddTicks(2691)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 14, 3, 22, 576, DateTimeKind.Utc).AddTicks(3033)),
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
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[] { new Guid("d6565d53-7f83-4b23-a00e-dec22478aa57"), null, new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(8190), new Guid("d6565d53-7f83-4b23-a00e-dec22478aa57"), "abc@123456.com", true, null, "abc123456", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 18, 14, 3, 22, 577, DateTimeKind.Utc).AddTicks(8191), new Guid("d6565d53-7f83-4b23-a00e-dec22478aa57"), "Boss" });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                table: "Role",
                column: "UserId");
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
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
========
﻿using System;
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 558, DateTimeKind.Utc).AddTicks(227)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 558, DateTimeKind.Utc).AddTicks(477)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 558, DateTimeKind.Utc).AddTicks(8191)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 558, DateTimeKind.Utc).AddTicks(8420)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 559, DateTimeKind.Utc).AddTicks(1950)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 559, DateTimeKind.Utc).AddTicks(2172)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 559, DateTimeKind.Utc).AddTicks(6073)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 559, DateTimeKind.Utc).AddTicks(6424)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(5902)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(6380)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(526)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(1110)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 558, DateTimeKind.Utc).AddTicks(4984)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 18, 16, 40, 46, 558, DateTimeKind.Utc).AddTicks(5236)),
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
                    { new Guid("0ac61574-a1f0-456a-998a-58cba20cdd29"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9148), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9149), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("1468a032-9e02-40c2-89f6-e7712119d6c1"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9154), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9155), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c64dfe3d-fa13-43bd-88b4-38f6265472e7"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9151), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9152), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("5ec412d1-df0f-4097-8dbf-d7a5a21d94ae"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9219), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("1468a032-9e02-40c2-89f6-e7712119d6c1"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9220), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("77cb7fa5-2c8b-4ae6-a5e5-c30416522bd6") },
                    { new Guid("9fc6d354-5451-4733-90a0-9fce288c823d"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9215), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("c64dfe3d-fa13-43bd-88b4-38f6265472e7"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9216), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("30983749-9c77-4e3a-921a-7371a06a0a8e") },
                    { new Guid("eef4f5b4-f130-4b08-a92b-d72e6ed72427"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9211), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("0ac61574-a1f0-456a-998a-58cba20cdd29"), new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(9212), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("20d649e7-8a24-471b-945e-b85c3bdae742") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("20d649e7-8a24-471b-945e-b85c3bdae742"), null, new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(8868), new Guid("20d649e7-8a24-471b-945e-b85c3bdae742"), "abc@123456.com", true, "超级管理员", "cJUbU/fQ2joYMFq2hGnAAgh2I+cjUFPNZsrwK0rHk5g=", "aaa", "WY+nRi8fUXldxVQ3nVqlqw==", "12345678910", new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(8870), new Guid("20d649e7-8a24-471b-945e-b85c3bdae742"), "admin" },
                    { new Guid("30983749-9c77-4e3a-921a-7371a06a0a8e"), null, new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(8876), new Guid("30983749-9c77-4e3a-921a-7371a06a0a8e"), "abc@123456.com", true, "管理员", "abc123456", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(8876), new Guid("30983749-9c77-4e3a-921a-7371a06a0a8e"), "svip001" },
                    { new Guid("77cb7fa5-2c8b-4ae6-a5e5-c30416522bd6"), null, new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(8879), new Guid("77cb7fa5-2c8b-4ae6-a5e5-c30416522bd6"), "abc@123456.com", true, "普通用户", "abc123456", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 18, 16, 40, 46, 560, DateTimeKind.Utc).AddTicks(8880), new Guid("77cb7fa5-2c8b-4ae6-a5e5-c30416522bd6"), "svip001" }
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
>>>>>>>> cd2dff46a4fc0a3f99d221fe23302866333e5894:back_end/src/Admin2024.EntityFramework/Migrations/20240718164047_Init_Rbac.cs
