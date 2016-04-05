using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Kehu1688.Framework.Store;

namespace Kehu1688.Framework.Store.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kehu1688.Framework.Permission.Activity", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("ActivityCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.Property<int>("Order");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Activity_Id");

                    b.HasAnnotation("Relational:TableName", "Activity");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.ActivityResource", b =>
                {
                    b.Property<string>("ActivityId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("ResourceId")
                        .HasAnnotation("MaxLength", 32);

                    b.HasKey("ActivityId", "ResourceId")
                        .HasAnnotation("Relational:Name", "PK_ActivityResource_ActivityId_ResourceId");

                    b.HasAnnotation("Relational:TableName", "ActivityResource");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Column", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<bool>("Authorize");

                    b.Property<string>("FLName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Column_Id");

                    b.HasAnnotation("Relational:TableName", "Column");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.ColumnPermission", b =>
                {
                    b.Property<string>("ColumnId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("RelationId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("RelationType");

                    b.Property<int>("Properties");

                    b.HasKey("ColumnId", "RelationId", "RelationType")
                        .HasAnnotation("Relational:Name", "PK_ColumnPermission_ColumnId_RelationId_RelationType");

                    b.HasAnnotation("Relational:TableName", "ColumnPermission");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Department", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("DepartmentType");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ParentId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Department_Id");

                    b.HasAnnotation("Relational:TableName", "Department");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.DepartmentPermission", b =>
                {
                    b.Property<string>("DepartmentId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("RelationId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("RelationType")
                        .HasAnnotation("MaxLength", 32);

                    b.HasKey("DepartmentId", "RelationId", "RelationType")
                        .HasAnnotation("Relational:Name", "PK_DepartmentPermission_DepartmentId_RelationId_RelationType");

                    b.HasAnnotation("Relational:TableName", "DepartmentPermission");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Employee", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Address")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<DateTime?>("Birthday");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("CompanyId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("DepartmentId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Gender");

                    b.Property<string>("IdCard")
                        .HasAnnotation("MaxLength", 18);

                    b.Property<bool>("IsDimission");

                    b.Property<DateTime?>("JoinDate");

                    b.Property<DateTime?>("LeaveDate");

                    b.Property<string>("MobilePhone")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("OfficePhone")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("OtherLink")
                        .HasAnnotation("MaxLength", 500);

                    b.Property<string>("Photo")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("PinYin")
                        .HasAnnotation("MaxLength", 10);

                    b.Property<string>("PositionId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("QQ")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<bool>("SysUser");

                    b.Property<string>("TeamId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("UserId");

                    b.Property<string>("Weixin")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "Pk_Employee_Id");

                    b.HasAnnotation("Relational:TableName", "Employee");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Menu", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Menu_Id");

                    b.HasAnnotation("Relational:TableName", "Menu");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.MenuPermission", b =>
                {
                    b.Property<string>("MenuId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("RelationId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("RelationType");

                    b.HasKey("MenuId", "RelationId", "RelationType")
                        .HasAnnotation("Relational:Name", "PK_MenuPermission_MenuId_RelationId_RelationType");

                    b.HasAnnotation("Relational:TableName", "MenuPermission");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Model.TableView", b =>
                {
                    b.Property<string>("Id");

                    b.Property<bool>("Authorize");

                    b.Property<string>("FLName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Position", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 20);

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Resource", b =>
                {
                    b.Property<string>("Id")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<bool>("Enabled");

                    b.Property<string>("MenuId")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("ResourceCode")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_Resource_Id");

                    b.HasAnnotation("Relational:TableName", "Resource");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.ResourcePermission", b =>
                {
                    b.Property<string>("ResourceId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<string>("RelationId")
                        .HasAnnotation("MaxLength", 32);

                    b.Property<int>("RelationType");

                    b.Property<int>("Properties");

                    b.HasKey("ResourceId", "RelationId", "RelationType")
                        .HasAnnotation("Relational:Name", "PK_ResourcePermission_ResourceId_RelationId_RelationType");

                    b.HasAnnotation("Relational:TableName", "ResourcePermission");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Role", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<bool>("Enabled");

                    b.Property<bool>("IsSysRole");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .HasAnnotation("Relational:Name", "Idx_Role_Name");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "Role");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.User", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("UserSecret");

                    b.Property<string>("UserToken");

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_User_Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasIndex("UserName")
                        .HasAnnotation("Relational:Name", "Idx_User_UserName");

                    b.HasAnnotation("Relational:TableName", "User");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_RoleClaim_Id");

                    b.HasAnnotation("Relational:TableName", "RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id")
                        .HasAnnotation("Relational:Name", "PK_UserClaim_Id");

                    b.HasAnnotation("Relational:TableName", "UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("ProviderKey");

                    b.HasKey("UserId")
                        .HasAnnotation("Relational:Name", "PK_UserLogin_UserId");

                    b.HasAlternateKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId");

                    b.Property<string>("UserId");

                    b.HasKey("RoleId", "UserId")
                        .HasAnnotation("Relational:Name", "PK_UserRole_RoleId_UserId");

                    b.HasAlternateKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "UserRole");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.ActivityResource", b =>
                {
                    b.HasOne("Kehu1688.Framework.Permission.Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId");

                    b.HasOne("Kehu1688.Framework.Permission.Resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");
                });

            modelBuilder.Entity("Kehu1688.Framework.Permission.Employee", b =>
                {
                    b.HasOne("Kehu1688.Framework.Permission.Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Kehu1688.Framework.Permission.Position")
                        .WithMany()
                        .HasForeignKey("PositionId");

                    b.HasOne("Kehu1688.Framework.Permission.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Kehu1688.Framework.Permission.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Kehu1688.Framework.Permission.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Kehu1688.Framework.Permission.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Kehu1688.Framework.Permission.Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Kehu1688.Framework.Permission.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
