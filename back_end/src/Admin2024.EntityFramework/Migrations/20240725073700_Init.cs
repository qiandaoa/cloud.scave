using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Admin2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    operation_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 111, DateTimeKind.Utc).AddTicks(3172)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 111, DateTimeKind.Utc).AddTicks(3532)),
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
                    resource_name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 113, DateTimeKind.Utc).AddTicks(1969)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 113, DateTimeKind.Utc).AddTicks(2314)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(1680)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(2010)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(9608)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(9997)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(6253)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(6683)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 115, DateTimeKind.Utc).AddTicks(7742)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 115, DateTimeKind.Utc).AddTicks(8112)),
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
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 112, DateTimeKind.Utc).AddTicks(1951)),
                    update_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 112, DateTimeKind.Utc).AddTicks(2585)),
                    create_by = table.Column<Guid>(type: "uuid", nullable: false),
                    update_by = table.Column<Guid>(type: "uuid", nullable: false),
                    remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.id);
                    table.ForeignKey(
                        name: "FK_Permission_Operation_operation_id",
                        column: x => x.operation_id,
                        principalTable: "Operation",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permission_Resource_resource_id",
                        column: x => x.resource_id,
                        principalTable: "Resource",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("0bac5c6f-81de-41bd-aef1-980dad927ae0"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9322), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9322), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("94f9530c-3642-4f29-9eb6-6a3ca272ea10"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9324), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9325), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("cdcd4afd-8f8f-49eb-a3b9-abfc274eb6f7"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9319), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9320), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("3c22a41f-ec3d-4a2e-a135-2b0e4dbc2e94"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9373), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("0bac5c6f-81de-41bd-aef1-980dad927ae0"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9374), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("3ccc1a99-a152-461e-89ab-b254966dd032") },
                    { new Guid("5c724065-d33e-45de-9b71-e469da4f6743"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9377), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("94f9530c-3642-4f29-9eb6-6a3ca272ea10"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9377), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("033cc1b3-fa98-4489-86b8-750b6b0c5add") },
                    { new Guid("b72d64b1-4b98-4f5a-8cac-4a397d87829e"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9370), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("cdcd4afd-8f8f-49eb-a3b9-abfc274eb6f7"), new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(9371), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("16e90b12-e462-4d6e-8c51-d6cbec71464b") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("033cc1b3-fa98-4489-86b8-750b6b0c5add"), null, new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(8740), new Guid("033cc1b3-fa98-4489-86b8-750b6b0c5add"), "abc@123456.com", true, "普通用户", "Qlw1vEnYctu4FyMtIx//ZDppBb62qqcGS6lbao0UKdk=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(8741), new Guid("033cc1b3-fa98-4489-86b8-750b6b0c5add"), "001" },
                    { new Guid("16e90b12-e462-4d6e-8c51-d6cbec71464b"), null, new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(8675), new Guid("16e90b12-e462-4d6e-8c51-d6cbec71464b"), "abc@123456.com", true, "超级管理员", "PVAdBenJnfhBrJJVBLmjlFFkgkYnK+dr576yOiD+MUI=", "aaa", "MbfLyStDRYHOtYs9pBGXwg==", "12345678910", new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(8676), new Guid("16e90b12-e462-4d6e-8c51-d6cbec71464b"), "admin" },
                    { new Guid("3ccc1a99-a152-461e-89ab-b254966dd032"), null, new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(8711), new Guid("3ccc1a99-a152-461e-89ab-b254966dd032"), "abc@123456.com", true, "管理员", "Gg96s2pxiM+axf2eCTeyv8yIp56Lp/g8JHCXKzI6B1U=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(8712), new Guid("3ccc1a99-a152-461e-89ab-b254966dd032"), "svip" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_RoleId",
                table: "Permission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_operation_id",
                table: "Permission",
                column: "operation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_resource_id",
                table: "Permission",
                column: "resource_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
