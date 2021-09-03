using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserActivityLog.Models;

namespace UserActivityLog.Data
{
    public class UserActivityLogContext : DbContext
    {
        public UserActivityLogContext (DbContextOptions<UserActivityLogContext> options)
            : base(options)
        {
        }

        public DbSet<UserActivityLog.Models.UserLog> UserLog { get; set; }
    }
}
