﻿// <auto-generated />
using System;
using Admin2024.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Admin2024.EntityFramework.Migrations
{
    [DbContext(typeof(AdminDbContext))]
    partial class AdminDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Admin2024.Domain.System.Operation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9201))
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("create_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_actived");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("OperationName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("operation_id");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 98, DateTimeKind.Utc).AddTicks(9451))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.HasKey("Id");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("Admin2024.Domain.System.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2457))
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("create_by");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_actived");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("OperationId")
                        .HasColumnType("uuid")
                        .HasColumnName("operation_id");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("permission_name");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<Guid>("ResourceId")
                        .HasColumnType("uuid")
                        .HasColumnName("resource_id");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(2700))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Permission");
                });

            modelBuilder.Entity("Admin2024.Domain.System.Resource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5173))
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("create_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_actived");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<string>("ResourceName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("resource_id");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(5366))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.HasKey("Id");

                    b.ToTable("Resource");
                });

            modelBuilder.Entity("Admin2024.Domain.System.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7632))
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("create_by");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_actived");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_name");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(7825))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0692d3a1-fde7-47de-9fb2-5e536c79d723"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7447),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleName = "超级管理员",
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7447),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("15db577a-8812-40f9-aad9-6eed34005e28"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7450),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleName = "管理员",
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7450),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("4ea7b1a8-946e-4d41-bed2-2278729a0e4c"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7452),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleName = "普通用户",
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7452),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("Admin2024.Domain.System.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 99, DateTimeKind.Utc).AddTicks(9991))
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("create_by");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_actived");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uuid")
                        .HasColumnName("permission_id");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(238))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.HasKey("Id");

                    b.ToTable("RolePermissions");
                });

            modelBuilder.Entity("Admin2024.Domain.System.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2467))
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("create_by");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_actived");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("NickName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<string>("Salt")
                        .HasColumnType("text")
                        .HasColumnName("salt");

                    b.Property<string>("Telephone")
                        .HasColumnType("text")
                        .HasColumnName("telephone");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(2689))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("380c3392-c8d6-4002-aa20-6daf9103074c"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7245),
                            CreateBy = new Guid("380c3392-c8d6-4002-aa20-6daf9103074c"),
                            Email = "abc@123456.com",
                            IsActived = true,
                            IsDeleted = false,
                            NickName = "超级管理员",
                            Password = "crGs4ESr1NUd31yUPadkXguTAgHsnSlT2OSc15BrB3s=",
                            Remark = "aaa",
                            Salt = "Y8o9LzwTFGwVlwMjSPx81A==",
                            Telephone = "12345678910",
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7247),
                            UpdateBy = new Guid("380c3392-c8d6-4002-aa20-6daf9103074c"),
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("dfebd047-d931-4b85-929f-55835c3e36b9"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7251),
                            CreateBy = new Guid("dfebd047-d931-4b85-929f-55835c3e36b9"),
                            Email = "abc@123456.com",
                            IsActived = true,
                            IsDeleted = false,
                            NickName = "管理员",
                            Password = "abc123456",
                            Remark = "aaa",
                            Salt = "aaaasssddd",
                            Telephone = "12345678910",
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7251),
                            UpdateBy = new Guid("dfebd047-d931-4b85-929f-55835c3e36b9"),
                            Username = "svip001"
                        },
                        new
                        {
                            Id = new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7254),
                            CreateBy = new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7"),
                            Email = "abc@123456.com",
                            IsActived = true,
                            IsDeleted = false,
                            NickName = "普通用户",
                            Password = "abc123456",
                            Remark = "aaa",
                            Salt = "aaaasssddd",
                            Telephone = "12345678910",
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7254),
                            UpdateBy = new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7"),
                            Username = "svip001"
                        });
                });

            modelBuilder.Entity("Admin2024.Domain.System.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5144))
                        .HasColumnName("create_at");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("create_by");

                    b.Property<bool>("IsActived")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(true)
                        .HasColumnName("is_actived");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(5320))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("30de7cba-e85a-4da8-b074-36f4a3754d81"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7484),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleId = new Guid("0692d3a1-fde7-47de-9fb2-5e536c79d723"),
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7485),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("380c3392-c8d6-4002-aa20-6daf9103074c")
                        },
                        new
                        {
                            Id = new Guid("92b02cca-4d06-47c7-8d0c-2b0b5dd974bf"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7487),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleId = new Guid("15db577a-8812-40f9-aad9-6eed34005e28"),
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7487),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("dfebd047-d931-4b85-929f-55835c3e36b9")
                        },
                        new
                        {
                            Id = new Guid("c280c2af-fd98-4b4e-9b4d-4fbc2234f3e9"),
                            CreateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7489),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleId = new Guid("4ea7b1a8-946e-4d41-bed2-2278729a0e4c"),
                            UpdateAt = new DateTime(2024, 7, 19, 0, 11, 58, 100, DateTimeKind.Utc).AddTicks(7490),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("e03e6b14-1a3d-4039-ab8c-2fa79b7f6ce7")
                        });
                });

            modelBuilder.Entity("Admin2024.Domain.System.Permission", b =>
                {
                    b.HasOne("Admin2024.Domain.System.Role", null)
                        .WithMany("_rolePermission")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Admin2024.Domain.System.Role", b =>
                {
                    b.Navigation("_rolePermission");
                });
#pragma warning restore 612, 618
        }
    }
}
