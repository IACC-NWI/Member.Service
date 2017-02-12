using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Service.Database.Model;

namespace Member.Service.Database
{
    public class MemberDbContext: DbContext, IMemberDbContext
    {
        public MemberDbContext()
            : base("memberDbConnectionString")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(14, 2));
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<MemberDbModel> Members { get; set; }
    }
}
