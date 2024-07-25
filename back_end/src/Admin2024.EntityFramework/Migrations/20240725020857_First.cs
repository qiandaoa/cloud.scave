using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Admin2024.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(5422),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(8052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(5241),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(7853));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(7982),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(7768),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(3023),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(2837),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(707),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(526),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(8318),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(8137),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(286));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(5698),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7814));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(5427),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7547));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(2821),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4603));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(2612),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4361));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_name", "update_at", "update_by" },
                values: new object[,]
                {
                    { new Guid("6c6fce3e-1da1-4c38-a6c9-d6095394b285"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9233), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "普通用户", new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9233), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("6d9ecdce-8b10-4374-be64-68e2dd4fc245"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "超级管理员", new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9230), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("f4619e34-c84a-41c8-b45c-199f06befde6"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9231), new Guid("00000000-0000-0000-0000-000000000000"), true, "", "管理员", new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9232), new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "id", "create_at", "create_by", "is_actived", "remarks", "role_id", "update_at", "update_by", "user_id" },
                values: new object[,]
                {
                    { new Guid("2eaea8db-cd7a-4b35-9070-71e338e273c3"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9274), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("f4619e34-c84a-41c8-b45c-199f06befde6"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9274), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("ea9b886b-0e01-412d-84d8-3491c9d77f9f") },
                    { new Guid("37a67e03-c609-41ef-98fa-4ec9beb3dcd4"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9276), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("6c6fce3e-1da1-4c38-a6c9-d6095394b285"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9276), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("4ddaae68-1d74-42fd-a8cd-31aaa73ef97c") },
                    { new Guid("72ea31a0-4f9f-47e9-aa9d-e50e0c819a07"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9271), new Guid("00000000-0000-0000-0000-000000000000"), true, "", new Guid("6d9ecdce-8b10-4374-be64-68e2dd4fc245"), new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9272), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("3da479db-e3a6-4bda-bb3f-d03961f8e429") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "Avatar", "create_at", "create_by", "email", "is_actived", "NickName", "password", "remarks", "salt", "telephone", "update_at", "update_by", "username" },
                values: new object[,]
                {
                    { new Guid("3da479db-e3a6-4bda-bb3f-d03961f8e429"), null, new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9064), new Guid("3da479db-e3a6-4bda-bb3f-d03961f8e429"), "abc@123456.com", true, "超级管理员", "9Wa5rfKrSMK4b8F/uyzWUzPkxHVdw5aRLfL05hfypE4=", "aaa", "PlKCZW1wIpPKVzKq0FSp2g==", "12345678910", new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9065), new Guid("3da479db-e3a6-4bda-bb3f-d03961f8e429"), "admin" },
                    { new Guid("4ddaae68-1d74-42fd-a8cd-31aaa73ef97c"), null, new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9105), new Guid("4ddaae68-1d74-42fd-a8cd-31aaa73ef97c"), "abc@123456.com", true, "普通用户", "bg74gXituGvGGMo/GxZOavxZYfi1MCYSoSFf+GircZs=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9106), new Guid("4ddaae68-1d74-42fd-a8cd-31aaa73ef97c"), "001" },
                    { new Guid("ea9b886b-0e01-412d-84d8-3491c9d77f9f"), null, new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9086), new Guid("ea9b886b-0e01-412d-84d8-3491c9d77f9f"), "abc@123456.com", true, "管理员", "6TvSD9jwhlrHwh1NeSEHLBpk6v0Qb1nDQ+JnoTmijAQ=", "aaa", "aaaasssddd", "12345678910", new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(9086), new Guid("ea9b886b-0e01-412d-84d8-3491c9d77f9f"), "svip" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_operation_id",
                table: "Permission",
                column: "operation_id");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_resource_id",
                table: "Permission",
                column: "resource_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Operation_operation_id",
                table: "Permission",
                column: "operation_id",
                principalTable: "Operation",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_Resource_resource_id",
                table: "Permission",
                column: "resource_id",
                principalTable: "Resource",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Operation_operation_id",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_Resource_resource_id",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_operation_id",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_resource_id",
                table: "Permission");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("6c6fce3e-1da1-4c38-a6c9-d6095394b285"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("6d9ecdce-8b10-4374-be64-68e2dd4fc245"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "id",
                keyValue: new Guid("f4619e34-c84a-41c8-b45c-199f06befde6"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("2eaea8db-cd7a-4b35-9070-71e338e273c3"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("37a67e03-c609-41ef-98fa-4ec9beb3dcd4"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "id",
                keyValue: new Guid("72ea31a0-4f9f-47e9-aa9d-e50e0c819a07"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("3da479db-e3a6-4bda-bb3f-d03961f8e429"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("4ddaae68-1d74-42fd-a8cd-31aaa73ef97c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: new Guid("ea9b886b-0e01-412d-84d8-3491c9d77f9f"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(8052),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(7853),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(5241));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(778),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(7982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "UserRoles",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 105, DateTimeKind.Utc).AddTicks(563),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(7768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5582),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "RolePermissions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(5388),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(2837));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2965),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Role",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(2770),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 562, DateTimeKind.Utc).AddTicks(526));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(487),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(8318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Resource",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 104, DateTimeKind.Utc).AddTicks(286),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(8137));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7814),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(5698));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Permission",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(7547),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(5427));

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4603),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(2821));

            migrationBuilder.AlterColumn<DateTime>(
                name: "create_at",
                table: "Operation",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(2024, 7, 19, 1, 52, 37, 103, DateTimeKind.Utc).AddTicks(4361),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTime(2024, 7, 25, 2, 8, 56, 561, DateTimeKind.Utc).AddTicks(2612));

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
    }
}
