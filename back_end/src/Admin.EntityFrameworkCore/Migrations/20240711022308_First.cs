using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Admin.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app_operation",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主键"),
                    base_code = table.Column<string>(type: "text", nullable: true, comment: "编号，可空"),
                    operation_name = table.Column<string>(type: "text", nullable: false, comment: "操作名称"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "描述，可空"),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "是否启用，默认是"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否删除，默认否"),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "创建时间，默认服务器当前时间"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新时间，默认和创建时间相同"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "创建人Id，可空"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "最后更新人Id，可空"),
                    display_order = table.Column<int>(type: "integer", nullable: false, comment: "展示的顺序，顺序大的排前面 默认为0"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_operation", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主键"),
                    base_code = table.Column<string>(type: "text", nullable: true, comment: "编号，可空"),
                    app_resource_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "资源Id"),
                    app_operation_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "操作Id"),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "是否启用，默认是"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否删除，默认否"),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "创建时间，默认服务器当前时间"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新时间，默认和创建时间相同"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "创建人Id，可空"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "最后更新人Id，可空"),
                    display_order = table.Column<int>(type: "integer", nullable: false, comment: "展示的顺序，顺序大的排前面 默认为0"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_resource",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主键"),
                    base_code = table.Column<string>(type: "text", nullable: true, comment: "编号，可空"),
                    resource_name = table.Column<string>(type: "text", nullable: false, comment: "资源名称"),
                    url = table.Column<string>(type: "text", nullable: false, comment: "访问地址"),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "是否启用，默认是"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否删除，默认否"),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "创建时间，默认服务器当前时间"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新时间，默认和创建时间相同"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "创建人Id，可空"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "最后更新人Id，可空"),
                    display_order = table.Column<int>(type: "integer", nullable: false, comment: "展示的顺序，顺序大的排前面 默认为0"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_resource", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主键"),
                    base_code = table.Column<string>(type: "text", nullable: true, comment: "编号，可空"),
                    role_name = table.Column<string>(type: "text", nullable: false, comment: "角色名称"),
                    description = table.Column<string>(type: "text", nullable: true, comment: "描述，可空"),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "是否启用，默认是"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否删除，默认否"),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "创建时间，默认服务器当前时间"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新时间，默认和创建时间相同"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "创建人Id，可空"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "最后更新人Id，可空"),
                    display_order = table.Column<int>(type: "integer", nullable: false, comment: "展示的顺序，顺序大的排前面 默认为0"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_role", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_role_permission",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主键"),
                    base_code = table.Column<string>(type: "text", nullable: true, comment: "编号，可空"),
                    app_role_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "角色Id"),
                    app_permission_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "权限Id"),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "是否启用，默认是"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否删除，默认否"),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "创建时间，默认服务器当前时间"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新时间，默认和创建时间相同"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "创建人Id，可空"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "最后更新人Id，可空"),
                    display_order = table.Column<int>(type: "integer", nullable: false, comment: "展示的顺序，顺序大的排前面 默认为0"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_role_permission", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主键"),
                    base_code = table.Column<string>(type: "text", nullable: true, comment: "编号，可空"),
                    username = table.Column<string>(type: "text", nullable: false, comment: "用户名"),
                    password = table.Column<string>(type: "text", nullable: false, comment: "密码"),
                    salt = table.Column<string>(type: "text", nullable: false, comment: "密码"),
                    nickname = table.Column<string>(type: "text", nullable: true, comment: "昵称"),
                    avatar = table.Column<string>(type: "text", nullable: true, comment: "头像"),
                    telephone = table.Column<string>(type: "text", nullable: true, comment: "手机号"),
                    weixin = table.Column<string>(type: "text", nullable: true, comment: "微信"),
                    qq = table.Column<string>(type: "text", nullable: true, comment: "QQ"),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "是否启用，默认是"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否删除，默认否"),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "创建时间，默认服务器当前时间"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新时间，默认和创建时间相同"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "创建人Id，可空"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "最后更新人Id，可空"),
                    display_order = table.Column<int>(type: "integer", nullable: false, comment: "展示的顺序，顺序大的排前面 默认为0"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "app_user_role",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "主键"),
                    base_code = table.Column<string>(type: "text", nullable: true, comment: "编号，可空"),
                    app_user_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "用户Id"),
                    app_role_id = table.Column<Guid>(type: "uuid", nullable: false, comment: "角色Id"),
                    is_actived = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true, comment: "是否启用，默认是"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "是否删除，默认否"),
                    create_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "创建时间，默认服务器当前时间"),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()", comment: "更新时间，默认和创建时间相同"),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "创建人Id，可空"),
                    updated_by = table.Column<Guid>(type: "uuid", nullable: false, comment: "最后更新人Id，可空"),
                    display_order = table.Column<int>(type: "integer", nullable: false, comment: "展示的顺序，顺序大的排前面 默认为0"),
                    remarks = table.Column<string>(type: "text", nullable: true, comment: "备注")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_user_role", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app_operation");

            migrationBuilder.DropTable(
                name: "app_permission");

            migrationBuilder.DropTable(
                name: "app_resource");

            migrationBuilder.DropTable(
                name: "app_role");

            migrationBuilder.DropTable(
                name: "app_role_permission");

            migrationBuilder.DropTable(
                name: "app_user");

            migrationBuilder.DropTable(
                name: "app_user_role");
        }
    }
}
