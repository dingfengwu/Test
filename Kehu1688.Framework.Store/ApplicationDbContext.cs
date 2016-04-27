using System;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Kehu1688.Framework.Base;
using Kehu1688.Framework.Permission;
using Kehu1688.Framework.Permission.Model;
using Microsoft.Data.Entity.Metadata;
using System.Linq;
using Microsoft.Data.Entity.Metadata.Conventions;
using Microsoft.Data.Entity.Infrastructure;

namespace Kehu1688.Framework.Store
{
    public class ApplicationDbContext : IdentityDbContext<User,Role,string>
    {
        public ApplicationDbContext() : base()
        {
            
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        
        /// <summary>
        /// 操作
        /// </summary>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// 列
        /// </summary>
        public DbSet<Column> Columns { get; set; }

        /// <summary>
        /// 列权限
        /// </summary>
        public DbSet<ColumnPermission> ColumnPermissions { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public DbSet<Department> Departments { get; set; }

        /// <summary>
        /// 部门范围权限
        /// </summary>
        public DbSet<DepartmentPermission> DepartmentPermissions { get; set; }

        /// <summary>
        /// 员工
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<Menu> Menus { get; set; }
                
        /// <summary>
        /// 菜单权限
        /// </summary>
        public DbSet<MenuPermission> MenuPermissions { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        public DbSet<Position> Positions { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public DbSet<Kehu1688.Framework.Permission.Resource> Resources { get; set; }

        /// <summary>
        /// 资源
        /// </summary>
        public DbSet<ResourcePermission> ResourcePermissions { get; set; }

        /// <summary>
        /// 用户操作日志
        /// </summary>
        public DbSet<UserLog> UserLogs { get; set; }
         
        /// <summary>
        /// 用户操作日志恢复策略
        /// </summary>
        public DbSet<LogRecoveryStrategy> LogRecoveryStrategys { get; set; }

        /// <summary>
        /// 审核流
        /// </summary>
        public DbSet<AuditFlow> AuditFlows { get; set; }

        /// <summary>
        /// 审核流策略
        /// </summary>
        public DbSet<AuditStrategy> AuditStrategys { get; set; }


        /// <summary>
        /// 表与视图
        /// </summary>
        public DbSet<TableView> TableViews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //调用父类方法
            base.OnModelCreating(builder);

            //注册权限模块部分的模型
            builder.RegisterPermissionModel();
        }

        
    }
}
