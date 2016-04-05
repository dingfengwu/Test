/*----------------------------------------------------------------
// Copyright (C) 2016 Kehu1688
// 版权所有。
//
// 文件名：PermissionDataService.cs
// 文件功能描述：
// 对数据库的一些操作
//
// 创建人  ：WDF
// 创建日期：2016-03-09
//----------------------------------------------------------------*/


using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kehu1688.Framework.Permission
{
    public static class PermissionDataService
    {
        public static void RegisterPermissionModel(this ModelBuilder builder)
        {
            //用户
            builder.Entity<User>(e =>
            {
                e.ToTable("User")
                .HasKey(p => p.Id)
                .HasName("PK_User_Id");

                e.HasIndex(p => p.UserName)
                .HasName("Idx_User_UserName");
            });

            //角色
            builder.Entity<Role>(e =>
            {
                e.ToTable("Role")
                .HasIndex(p => p.Name)
                .HasName("Idx_Role_Name");
            });

            //用户申明
            builder.Entity<IdentityUserClaim<string>>(e =>
            {
                e.ToTable("UserClaim")
                .HasKey(p => p.Id)
                .HasName("PK_UserClaim_Id");
            });
            //角色申明
            builder.Entity<IdentityRoleClaim<string>>(e =>
            {
                e.ToTable("RoleClaim")
                .HasKey(p => p.Id)
                .HasName("PK_RoleClaim_Id");
            });

            //用户角色
            builder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("UserRole")
                .HasKey(p => new { p.RoleId,p.UserId})
                .HasName("PK_UserRole_RoleId_UserId");
            });

            //用户登陆
            builder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("UserLogin")
                .HasKey(p => new { p.UserId })
                .HasName("PK_UserLogin_UserId");
            });

            //员工
            builder.Entity<Employee>(e =>
            {
                e.ToTable("Employee")
                .HasKey(p => p.Id)
                .HasName("Pk_Employee_Id");
            });

            //部门
            builder.Entity<Department>(e =>
            {
                e.ToTable("Department")
                .HasKey(p => p.Id)
                .HasName("PK_Department_Id");
            });

            //操作
            builder.Entity<Activity>(e =>
            {
                e.ToTable("Activity")
                .HasKey(p => p.Id)
                .HasName("PK_Activity_Id");

                e.HasMany(f => f.Resources).WithOne().HasForeignKey(f => f.ActivityId).IsRequired();
            });

            //资源
            builder.Entity<Resource>(e =>
            {
                e.ToTable("Resource")
                .HasKey(p => p.Id)
                .HasName("PK_Resource_Id");

                e.HasMany(f => f.Activities).WithOne().HasForeignKey(f=>f.ResourceId).IsRequired();
            });

            //操作资源
            builder.Entity<ActivityResource>(e =>
            {
                e.ToTable("ActivityResource")
                .HasKey(p => new { p.ActivityId, p.ResourceId })
                .HasName("PK_ActivityResource_ActivityId_ResourceId");

                e.HasKey(f => new { f.ActivityId, f.ResourceId });
            });

            //菜单
            builder.Entity<Menu>(e =>
            {
                e.ToTable("Menu")
                .HasKey(p => p.Id)
                .HasName("PK_Menu_Id");
            });

            //列
            builder.Entity<Column>(e =>
            {
                e.ToTable("Column")
                .HasKey(p => p.Id)
                .HasName("PK_Column_Id");
            });

            //

            //列权限
            builder.Entity<ColumnPermission>(e =>
            {
                e.ToTable("ColumnPermission")
                .HasKey(f => new { f.ColumnId, f.RelationId, f.RelationType })
                .HasName("PK_ColumnPermission_ColumnId_RelationId_RelationType");
            });

            //部门权限
            builder.Entity<DepartmentPermission>(e =>
            {
                e.ToTable("DepartmentPermission")
                .HasKey(f => new { f.DepartmentId, f.RelationId, f.RelationType })
                .HasName("PK_DepartmentPermission_DepartmentId_RelationId_RelationType");
            });

            //菜单权限
            builder.Entity<MenuPermission>(e =>
            {
                e.ToTable("MenuPermission")
                .HasKey(f => new { f.MenuId, f.RelationId, f.RelationType })
                .HasName("PK_MenuPermission_MenuId_RelationId_RelationType");
            });

            //资源权限
            builder.Entity<ResourcePermission>(e =>
            {
                e.ToTable("ResourcePermission")
                .HasKey(f => new { f.ResourceId, f.RelationId, f.RelationType })
                .HasName("PK_ResourcePermission_ResourceId_RelationId_RelationType");
            });
        }
    }
}
