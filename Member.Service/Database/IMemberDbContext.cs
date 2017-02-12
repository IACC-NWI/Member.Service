using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Member.Service.Database.Model;

namespace Member.Service.Database
{
    public interface IMemberDbContext
    {
        DbSet<MemberDbModel> Members { get; set; }
        Task<int> SaveChangesAsync();
    }
}
