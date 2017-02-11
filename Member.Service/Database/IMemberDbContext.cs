using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Service.Database
{
    public interface IMemberDbContext
    {
        Task<int> SaveChangesAsync();
    }
}
