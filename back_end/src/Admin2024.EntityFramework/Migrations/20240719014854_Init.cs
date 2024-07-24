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
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("0692d3a1-fde7-47de-9fb2-5e536c79d723"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("15db577a-8812-40f9-aad9-6eed34005e28"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("4ea7b1a8-946e-4d41-bed2-2278729a0e4c"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("30de7cba-e85a-4da8-b074-36f4a3754d81"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("92b02cca-4d06-47c7-8d0c-2b0b5dd974bf"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("c280c2af-fd98-4b4e-9b4d-4fbc2234f3e9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("380c3392-c8d6-4002-aa20-6daf9103074c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("dfebd047-d931-4b85-929f-55835c3e36b9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7656),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(439),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5320));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(251),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(5042),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(4815),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2471),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2256),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7632));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(30),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(9804),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7372),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2700));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3578),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3255),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9201));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_name", "update_at", "update_by" },
                values: new object[,]
                {
                    { new Guid("2b7f40f9-bc49-4911-a5b8-b0ba64331b99"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1784), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1785), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("56024aa3-b610-4e23-b688-6ac5b4105599"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1782), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1783), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("c888aa9e-3dab-4adb-a000-87ad0d1f5fe5"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1780), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1780), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("1096d0d7-760b-4bd7-b503-c23f2a4d17b4"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1824), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("56024aa3-b610-4e23-b688-6ac5b4105599"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1824), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("99dfec05-a872-4cab-8aaf-7d86b3b4a5bd") },
                    { new Guid("99cb6883-9eef-4bfa-bb80-087c01574148"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1826), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("2b7f40f9-bc49-4911-a5b8-b0ba64331b99"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1826), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("6aff6c46-8b8c-4ad8-a819-f35b0058547c") },
                    { new Guid("9fffeffc-8aa2-40b3-a03e-3e802c261c0e"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1821), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("c888aa9e-3dab-4adb-a000-87ad0d1f5fe5"), new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1822), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("829a059c-30b8-45b8-86b2-b03a818d5be0") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("6aff6c46-8b8c-4ad8-a819-f35b0058547c"), null, new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1575), new Guid("6aff6c46-8b8c-4ad8-a819-f35b0058547c"), "abc@123456.com", true, "普通用户", "EEaztsfvDUmd0I2BPdLkC/R1vN4s/5s9drc+V5lBUkY=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1576), new Guid("6aff6c46-8b8c-4ad8-a819-f35b0058547c"), "001" },
                    { new Guid("829a059c-30b8-45b8-86b2-b03a818d5be0"), null, new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1533), new Guid("829a059c-30b8-45b8-86b2-b03a818d5be0"), "abc@123456.com", true, "超级管理员", "tU7k6aTunMYVZ1T9TBF804zcxh78D8aE1becPe+fMWU=", "aaa", "wSOw74FVLb56vDnDPFiVkA==", "12345678910", new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1535), new Guid("829a059c-30b8-45b8-86b2-b03a818d5be0"), "admin" },
                    { new Guid("99dfec05-a872-4cab-8aaf-7d86b3b4a5bd"), null, new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1559), new Guid("99dfec05-a872-4cab-8aaf-7d86b3b4a5bd"), "abc@123456.com", true, "管理员", "qx9nPbht8LnkvbakhC8slWxMsi4CLHT6saGOYs647wU=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(1560), new Guid("99dfec05-a872-4cab-8aaf-7d86b3b4a5bd"), "svip" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("2b7f40f9-bc49-4911-a5b8-b0ba64331b99"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("56024aa3-b610-4e23-b688-6ac5b4105599"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("c888aa9e-3dab-4adb-a000-87ad0d1f5fe5"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("1096d0d7-760b-4bd7-b503-c23f2a4d17b4"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("99cb6883-9eef-4bfa-bb80-087c01574148"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("9fffeffc-8aa2-40b3-a03e-3e802c261c0e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("6aff6c46-8b8c-4ad8-a819-f35b0058547c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("829a059c-30b8-45b8-86b2-b03a818d5be0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("99dfec05-a872-4cab-8aaf-7d86b3b4a5bd"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2689),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2467),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5144),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(238),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(5042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(9991),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7825),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7632),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5366),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5173),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2700),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2457),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9451),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9201),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3255));

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
        }
    }
}
