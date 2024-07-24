using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Admin2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Inica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8903),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8713),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7432));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1626),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1428),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(251));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(5042));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6118),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3828),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2471));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3582),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(30));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1064),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(9804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8551),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7372));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8312),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(5085),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3578));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3255));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_name", "update_at", "update_by" },
                values: new object[,]
                {
                    { new Guid("079183f9-f147-402c-9920-55ea344999a5"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2919), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2919), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("53ca4d01-1681-4a4b-b7c1-c64bf19c4bdd"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2917), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2917), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("ea05b30c-7e2d-4431-876b-57dbc3603dd0"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2914), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2915), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("51a0bbef-8460-4df0-bc2f-9bc4eff666e1"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2986), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("ea05b30c-7e2d-4431-876b-57dbc3603dd0"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2986), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("e89d3dde-e05d-4621-8fc2-7cb826b220fe") },
                    { new Guid("57cc47f7-c9c7-4072-b632-0988c04e7087"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2988), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("53ca4d01-1681-4a4b-b7c1-c64bf19c4bdd"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2989), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("ea5127e3-3232-4ffe-b144-d63860bf3412") },
                    { new Guid("8d1aef0f-08c7-4184-9319-132a3e1f496b"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2991), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("079183f9-f147-402c-9920-55ea344999a5"), new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2991), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("37078345-748b-4c2e-af4d-a7cc2a91d8f0") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("37078345-748b-4c2e-af4d-a7cc2a91d8f0"), null, new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2755), new Guid("37078345-748b-4c2e-af4d-a7cc2a91d8f0"), "abc@123456.com", true, "普通用户", "yh0gDTL9PuR/zaKCqOi2cy5BrZaKxXIO5NL5r+ZRasQ=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2755), new Guid("37078345-748b-4c2e-af4d-a7cc2a91d8f0"), "001" },
                    { new Guid("e89d3dde-e05d-4621-8fc2-7cb826b220fe"), null, new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2712), new Guid("e89d3dde-e05d-4621-8fc2-7cb826b220fe"), "abc@123456.com", true, "超级管理员", "cw40lsO17vw4HOIteaQehS5XX3M5DI/ZAgXGMS5azeo=", "aaa", "SHSlU77DFpogGm/bmODwmw==", "12345678910", new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2713), new Guid("e89d3dde-e05d-4621-8fc2-7cb826b220fe"), "admin" },
                    { new Guid("ea5127e3-3232-4ffe-b144-d63860bf3412"), null, new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2736), new Guid("ea5127e3-3232-4ffe-b144-d63860bf3412"), "abc@123456.com", true, "管理员", "LOp6r6lgE8nWINPz8K36J5O+Y/bkMJ1T4PgtKAMXX4g=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(2736), new Guid("ea5127e3-3232-4ffe-b144-d63860bf3412"), "svip" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("079183f9-f147-402c-9920-55ea344999a5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("53ca4d01-1681-4a4b-b7c1-c64bf19c4bdd"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("ea05b30c-7e2d-4431-876b-57dbc3603dd0"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("51a0bbef-8460-4df0-bc2f-9bc4eff666e1"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("57cc47f7-c9c7-4072-b632-0988c04e7087"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("8d1aef0f-08c7-4184-9319-132a3e1f496b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("37078345-748b-4c2e-af4d-a7cc2a91d8f0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("e89d3dde-e05d-4621-8fc2-7cb826b220fe"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("ea5127e3-3232-4ffe-b144-d63860bf3412"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7656),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(7432),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(439),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 325, DateTimeKind.Utc).AddTicks(251),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(5042),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(4815),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2471),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(2256),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 324, DateTimeKind.Utc).AddTicks(30),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(9804),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7372),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(7155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3578),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(5085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 48, 54, 323, DateTimeKind.Utc).AddTicks(3255),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(4863));

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
    }
}
