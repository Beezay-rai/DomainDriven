using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public string Reason { get; set; }  
    }
}
