﻿// <auto-generated />
using System;
using Admin2024.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Admin2024.EntityFramework.Migrations
{
    [DbContext(typeof(AdminDbContext))]
    [Migration("20240731031328_Init-one")]
    partial class Initone
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 916, DateTimeKind.Utc).AddTicks(9609))
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
                        .HasColumnName("operation_name");

                    b.Property<string>("Remark")
                        .HasColumnType("text")
                        .HasColumnName("remarks");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 916, DateTimeKind.Utc).AddTicks(9832))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(2705))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(3019))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.HasKey("Id");

                    b.HasIndex("OperationId");

                    b.HasIndex("ResourceId");

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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(5547))
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
                        .HasColumnName("resource_name");

                    b.Property<DateTime>("UpdateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(5753))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(8148))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 917, DateTimeKind.Utc).AddTicks(8351))
                        .HasColumnName("update_at");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uuid")
                        .HasColumnName("update_by");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2c2e6eaa-3332-4545-89d3-ffc81286b694"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7580),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleName = "超级管理员",
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7580),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("4883c0f1-7e3c-419c-b7dc-329f4121639d"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7582),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleName = "管理员",
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7583),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("701c96ea-b0ce-476d-af3d-c7855cf4f3ba"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7585),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleName = "普通用户",
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7585),
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(680))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(876))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(3210))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(3404))
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
                            Id = new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7348),
                            CreateBy = new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef"),
                            Email = "abc@123456.com",
                            IsActived = true,
                            IsDeleted = false,
                            NickName = "超级管理员",
                            Password = "iXcw6KSBSPwy6frdyJ1XOaHpmct2bhPcJ+EKa9U8MCA=",
                            Remark = "aaa",
                            Salt = "zC3h6mcRRs8ULBLRs7U6Yg==",
                            Telephone = "12345678910",
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7350),
                            UpdateBy = new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef"),
                            Username = "admin"
                        },
                        new
                        {
                            Id = new Guid("def82a39-060f-46b0-ae90-e000978e5d0e"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7379),
                            CreateBy = new Guid("def82a39-060f-46b0-ae90-e000978e5d0e"),
                            Email = "abc@123456.com",
                            IsActived = true,
                            IsDeleted = false,
                            NickName = "管理员",
                            Password = "j+/NPreE1pY0f5xmZaAy0Gq0F2g6TpU0iXK+RKJDD3M=",
                            Remark = "aaa",
                            Salt = "aaaasssddd",
                            Telephone = "12345678910",
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7379),
                            UpdateBy = new Guid("def82a39-060f-46b0-ae90-e000978e5d0e"),
                            Username = "svip"
                        },
                        new
                        {
                            Id = new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7398),
                            CreateBy = new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217"),
                            Email = "abc@123456.com",
                            IsActived = true,
                            IsDeleted = false,
                            NickName = "普通用户",
                            Password = "OxH5joD9aFGTDI2YyAtcw59VvpZDhg7C8rI2bibwGK0=",
                            Remark = "aaa",
                            Salt = "aaaasssddd",
                            Telephone = "12345678910",
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7398),
                            UpdateBy = new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217"),
                            Username = "001"
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(5987))
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
                        .HasDefaultValue(new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(6238))
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
                            Id = new Guid("58bb32e9-1187-4c46-9b3e-fb0c1461e70c"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7633),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleId = new Guid("2c2e6eaa-3332-4545-89d3-ffc81286b694"),
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7633),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("49bc19b2-df3c-4670-88aa-19ae2289fdef")
                        },
                        new
                        {
                            Id = new Guid("2b89bdf8-77bc-4a47-9a09-622e06e504d7"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7636),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleId = new Guid("4883c0f1-7e3c-419c-b7dc-329f4121639d"),
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7637),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("def82a39-060f-46b0-ae90-e000978e5d0e")
                        },
                        new
                        {
                            Id = new Guid("034d16e8-754f-4eb3-8168-097aa7f12022"),
                            CreateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7638),
                            CreateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsActived = true,
                            IsDeleted = false,
                            Remark = "",
                            RoleId = new Guid("701c96ea-b0ce-476d-af3d-c7855cf4f3ba"),
                            UpdateAt = new DateTime(2024, 7, 31, 3, 13, 27, 918, DateTimeKind.Utc).AddTicks(7639),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("2d6c6676-d577-4d2d-8464-5f7ff487d217")
                        });
                });

            modelBuilder.Entity("Admin2024.Domain.System.Permission", b =>
                {
                    b.HasOne("Admin2024.Domain.System.Operation", "Operation")
                        .WithMany()
                        .HasForeignKey("OperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admin2024.Domain.System.Resource", "Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Admin2024.Domain.System.Role", null)
                        .WithMany("_rolePermission")
                        .HasForeignKey("RoleId");

                    b.Navigation("Operation");

                    b.Navigation("Resource");
                });

            modelBuilder.Entity("Admin2024.Domain.System.Role", b =>
                {
                    b.Navigation("_rolePermission");
                });
#pragma warning restore 612, 618
        }
    }
}
