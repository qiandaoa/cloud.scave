using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Admin2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class two : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(8052),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8903));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(7853),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(778),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1428));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5582),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5388),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6118));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2965),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2770),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(487),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(286),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1064));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7814),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8551));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8312));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4603),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(5085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4361),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(4863));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_name", "update_at", "update_by" },
                values: new object[,]
                {
                    { new Guid("02169564-b34a-4fde-b8ae-99cde634ab40"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2065), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2066), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("7e86d114-8477-4801-a249-f784e52ec638"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2068), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2068), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("8b72d1b4-7df6-4704-b379-38fa3db6dc25"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2070), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2070), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("3d85295d-c749-41a5-9e1b-1aa8a3c5f8fb"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2113), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("8b72d1b4-7df6-4704-b379-38fa3db6dc25"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2113), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("beb055a1-8248-44f0-a44e-af28c351adc8") },
                    { new Guid("8e5ee9c8-e3d5-495b-bbff-e917b6b90a6b"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2108), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("02169564-b34a-4fde-b8ae-99cde634ab40"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2109), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("8306ee09-e4b5-4c61-ab4a-5a9837484eaa") },
                    { new Guid("f29a50ca-cd2f-4e9f-8cd0-7194157428bd"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2111), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("7e86d114-8477-4801-a249-f784e52ec638"), new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(2111), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("a8481068-69fa-4f60-b327-998528cfa485") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("8306ee09-e4b5-4c61-ab4a-5a9837484eaa"), null, new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(1867), new Guid("8306ee09-e4b5-4c61-ab4a-5a9837484eaa"), "abc@123456.com", true, "超级管理员", "PtD0caF2bvnLv85kkYrMmF4Z1y+AdDi+8M8oMacFGHE=", "aaa", "DniOf1oPOHGlBfs3RBWjIA==", "12345678910", new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(1867), new Guid("8306ee09-e4b5-4c61-ab4a-5a9837484eaa"), "admin" },
                    { new Guid("a8481068-69fa-4f60-b327-998528cfa485"), null, new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(1891), new Guid("a8481068-69fa-4f60-b327-998528cfa485"), "abc@123456.com", true, "管理员", "rmOYmmEmQ6l4bAkufKuGy/RAZMgm1SxYrw92bL7zntA=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(1891), new Guid("a8481068-69fa-4f60-b327-998528cfa485"), "svip" },
                    { new Guid("beb055a1-8248-44f0-a44e-af28c351adc8"), null, new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(1907), new Guid("beb055a1-8248-44f0-a44e-af28c351adc8"), "abc@123456.com", true, "普通用户", "OivdjmMhRK5rPpH5pcWqeoIs5FA4V8Ar7g90LMPigFk=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(1908), new Guid("beb055a1-8248-44f0-a44e-af28c351adc8"), "001" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("02169564-b34a-4fde-b8ae-99cde634ab40"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("7e86d114-8477-4801-a249-f784e52ec638"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("8b72d1b4-7df6-4704-b379-38fa3db6dc25"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("3d85295d-c749-41a5-9e1b-1aa8a3c5f8fb"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("8e5ee9c8-e3d5-495b-bbff-e917b6b90a6b"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("f29a50ca-cd2f-4e9f-8cd0-7194157428bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("8306ee09-e4b5-4c61-ab4a-5a9837484eaa"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("a8481068-69fa-4f60-b327-998528cfa485"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("beb055a1-8248-44f0-a44e-af28c351adc8"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8903),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(8052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(8713),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(7853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1626),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 547, DateTimeKind.Utc).AddTicks(1428),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6313),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(6118),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3828),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(3582),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1290),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 546, DateTimeKind.Utc).AddTicks(1064),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8551),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(8312),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(5085),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 51, 10, 545, DateTimeKind.Utc).AddTicks(4863),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4361));

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
    }
}
