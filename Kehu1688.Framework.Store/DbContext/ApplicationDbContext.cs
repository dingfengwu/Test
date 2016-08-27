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
    public partial class ApplicationDbContext : IdentityDbContext<User,Role,string>
    {
        public ApplicationDbContext() : base()
        {
            this.ChangeTracker.AutoDetectChangesEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //调用父类方法
            base.OnModelCreating(builder);

        }
        
        
    }
}
