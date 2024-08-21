using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Admin2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("0bac5c6f-81de-41bd-aef1-980dad927ae0"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("94f9530c-3642-4f29-9eb6-6a3ca272ea10"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("cdcd4afd-8f8f-49eb-a3b9-abfc274eb6f7"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("3c22a41f-ec3d-4a2e-a135-2b0e4dbc2e94"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("5c724065-d33e-45de-9b71-e469da4f6743"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("b72d64b1-4b98-4f5a-8cac-4a397d87829e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("033cc1b3-fa98-4489-86b8-750b6b0c5add"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("16e90b12-e462-4d6e-8c51-d6cbec71464b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("3ccc1a99-a152-461e-89ab-b254966dd032"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(3404),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 115, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(3210),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 115, DateTimeKind.Utc).AddTicks(7742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(6238),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(6683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(5987),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(6253));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(876),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(9997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(680),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(9608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(8351),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(8148),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(5753),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 113, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(5547),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 113, DateTimeKind.Utc).AddTicks(1969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(3019),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 112, DateTimeKind.Utc).AddTicks(2585));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(2705),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 112, DateTimeKind.Utc).AddTicks(1951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 916, DateTimeKind.Utc).AddTicks(9832),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 111, DateTimeKind.Utc).AddTicks(3532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 916, DateTimeKind.Utc).AddTicks(9609),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 111, DateTimeKind.Utc).AddTicks(3172));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_name", "update_at", "update_by" },
                values: new object[,]
                {
                    { new Guid("2c2e6eaa-3332-4545-89d3-ffc81286b694"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7580), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7580), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("4883c0f1-7e3c-419c-b7dc-329f4121639d"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7582), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7583), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("701c96ea-b0ce-476d-af3d-c7855cf4f3ba"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7585), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7585), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("034d16e8-754f-4eb3-8168-097aa7f12022"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7638), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("701c96ea-b0ce-476d-af3d-c7855cf4f3ba"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7639), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217") },
                    { new Guid("2b89bdf8-77bc-4a47-9a09-622e06e504d7"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7636), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("4883c0f1-7e3c-419c-b7dc-329f4121639d"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7637), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("def82a39-060f-46b0-ae90-e000978e5d0e") },
                    { new Guid("58bb32e9-1187-4c46-9b3e-fb0c1461e70c"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7633), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("2c2e6eaa-3332-4545-89d3-ffc81286b694"), new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7633), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217"), null, new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7398), new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217"), "abc@123456.com", true, "普通用户", "OxH5joD9aFGTDI2YyAtcw59VvpZDhg7C8rI2bibwGK0=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7398), new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217"), "001" },
                    { new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef"), null, new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7348), new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef"), "abc@123456.com", true, "超级管理员", "iXcw6KSBSPwy6frdyJ1XOaHpmct2bhPcJ+EKa9U8MCA=", "aaa", "zC3h6mcRRs8ULBLRs7U6Yg==", "12345678910", new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7350), new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef"), "admin" },
                    { new Guid("def82a39-060f-46b0-ae90-e000978e5d0e"), null, new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7379), new Guid("def82a39-060f-46b0-ae90-e000978e5d0e"), "abc@123456.com", true, "管理员", "j+/NPreE1pY0f5xmZaAy0Gq0F2g6TpU0iXK+RKJDD3M=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7379), new Guid("def82a39-060f-46b0-ae90-e000978e5d0e"), "svip" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("2c2e6eaa-3332-4545-89d3-ffc81286b694"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("4883c0f1-7e3c-419c-b7dc-329f4121639d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("701c96ea-b0ce-476d-af3d-c7855cf4f3ba"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("034d16e8-754f-4eb3-8168-097aa7f12022"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("2b89bdf8-77bc-4a47-9a09-622e06e504d7"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("58bb32e9-1187-4c46-9b3e-fb0c1461e70c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("def82a39-060f-46b0-ae90-e000978e5d0e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 115, DateTimeKind.Utc).AddTicks(8112),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(3404));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 115, DateTimeKind.Utc).AddTicks(7742),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(3210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(6683),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 116, DateTimeKind.Utc).AddTicks(6253),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(5987));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(9997),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(9608),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(2010),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(8351));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 114, DateTimeKind.Utc).AddTicks(1680),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 113, DateTimeKind.Utc).AddTicks(2314),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(5753));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 113, DateTimeKind.Utc).AddTicks(1969),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(5547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 112, DateTimeKind.Utc).AddTicks(2585),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(3019));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 112, DateTimeKind.Utc).AddTicks(1951),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(2705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 111, DateTimeKind.Utc).AddTicks(3532),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 916, DateTimeKind.Utc).AddTicks(9832));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 7, 37, 0, 111, DateTimeKind.Utc).AddTicks(3172),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 31, 3, 13, 27, 916, DateTimeKind.Utc).AddTicks(9609));

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
        }
    }
}
