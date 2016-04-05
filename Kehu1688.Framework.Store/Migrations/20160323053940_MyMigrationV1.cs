using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace Kehu1688.Framework.Store.Migrations
{
    public partial class MyMigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ActivityCode = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity_Id", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Column",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Authorize = table.Column<bool>(nullable: false),
                    FLName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Column", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ColumnPermission",
                columns: table => new
                {
                    ColumnId = table.Column<string>(nullable: false),
                    RelationId = table.Column<string>(nullable: false),
                    RelationType = table.Column<int>(nullable: false),
                    Properties = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColumnPermission_ColumnId_RelationId_RelationType", x => new { x.ColumnId, x.RelationId, x.RelationType });
                });
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DepartmentType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Id", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "DepartmentPermission",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(nullable: false),
                    RelationId = table.Column<string>(nullable: false),
                    RelationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentPermission_DepartmentId_RelationId_RelationType", x => new { x.DepartmentId, x.RelationId, x.RelationType });
                });
            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Id", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "MenuPermission",
                columns: table => new
                {
                    MenuId = table.Column<string>(nullable: false),
                    RelationId = table.Column<string>(nullable: false),
                    RelationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermission_MenuId_RelationId_RelationType", x => new { x.MenuId, x.RelationId, x.RelationType });
                });
            migrationBuilder.CreateTable(
                name: "TableView",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Authorize = table.Column<bool>(nullable: false),
                    FLName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableView", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    MenuId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ResourceCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource_Id", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ResourcePermission",
                columns: table => new
                {
                    ResourceId = table.Column<string>(nullable: false),
                    RelationId = table.Column<string>(nullable: false),
                    RelationType = table.Column<int>(nullable: false),
                    Properties = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourcePermission_ResourceId_RelationId_RelationType", x => new { x.ResourceId, x.RelationId, x.RelationType });
                });
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Id", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role_Id", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "ActivityResource",
                columns: table => new
                {
                    ActivityId = table.Column<string>(nullable: false),
                    ResourceId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityResource_ActivityId_ResourceId", x => new { x.ActivityId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ActivityResource_Activity_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityResource_Resource_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resource",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IdCard = table.Column<string>(nullable: true),
                    IsDimission = table.Column<bool>(nullable: false),
                    JoinDate = table.Column<DateTime>(nullable: true),
                    LeaveDate = table.Column<DateTime>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    OfficePhone = table.Column<string>(nullable: true),
                    OtherLink = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    PinYin = table.Column<string>(nullable: true),
                    PositionId = table.Column<string>(nullable: false),
                    QQ = table.Column<string>(nullable: true),
                    SysUser = table.Column<bool>(nullable: false),
                    TeamId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Weixin = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Pk_Employee_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin_UserId", x => x.UserId);
                    table.UniqueConstraint("AK_IdentityUserLogin<string>_LoginProvider_ProviderKey", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole_RoleId_UserId", x => new { x.RoleId, x.UserId });
                    table.UniqueConstraint("AK_IdentityUserRole<string>_UserId_RoleId", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName");
            migrationBuilder.CreateIndex(
                name: "Idx_User_UserName",
                table: "User",
                column: "UserName");
            migrationBuilder.CreateIndex(
                name: "Idx_Role_Name",
                table: "Role",
                column: "Name");
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Role",
                column: "NormalizedName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("ActivityResource");
            migrationBuilder.DropTable("Column");
            migrationBuilder.DropTable("ColumnPermission");
            migrationBuilder.DropTable("DepartmentPermission");
            migrationBuilder.DropTable("Employee");
            migrationBuilder.DropTable("Menu");
            migrationBuilder.DropTable("MenuPermission");
            migrationBuilder.DropTable("TableView");
            migrationBuilder.DropTable("ResourcePermission");
            migrationBuilder.DropTable("RoleClaim");
            migrationBuilder.DropTable("UserClaim");
            migrationBuilder.DropTable("UserLogin");
            migrationBuilder.DropTable("UserRole");
            migrationBuilder.DropTable("Activity");
            migrationBuilder.DropTable("Resource");
            migrationBuilder.DropTable("Department");
            migrationBuilder.DropTable("Position");
            migrationBuilder.DropTable("Role");
            migrationBuilder.DropTable("User");
        }
    }
}
