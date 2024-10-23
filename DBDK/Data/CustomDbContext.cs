using DBDK.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDK.Data
{
    public abstract class CustomDbContext : DbContext
    {
        private CustomDbHelper dbHelper;

        protected CustomDbContext(CustomDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(dbHelper.GetConnectionString());
        }
    }
}
