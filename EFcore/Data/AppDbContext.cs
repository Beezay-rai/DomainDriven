using DBDK;
using DBDK.Data;
using DBDK.Helper;
using Microsoft.EntityFrameworkCore;

namespace EFcore.Data
{
    public class AppDbContext : CustomDbContext
    {
        
        public AppDbContext(CustomDbHelper dbHelper) : base(dbHelper)
        {

        }
    
        // DbSet properties for the entities
        public CustomDbSet<Leave> Leave { get; set; }
        public CustomDbSet<LeaveRequest> LeaveRequest { get; set; }


    }
}
