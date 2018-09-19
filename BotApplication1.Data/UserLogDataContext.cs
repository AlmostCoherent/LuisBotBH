using BotApplication1.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotApplication1.Data
{
    public class UserLogDataContext : DbContext
    {
        public UserLogDataContext() : base("BotDbEntities")
        {

        }

        public DbSet<UserLog> UserLogs { get; set; }
    }
}
