using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Data
{
    public class Leave
    {
        //public Leave(int LeaveRequestId, Status Status)
        //{
        //    this.LeaveRequestId = LeaveRequestId;
        //    this.Status = Status;
        //}

        [Key]
        public int Id { get; private set; }
        public int LeaveRequestId { get; private set; }
        public Status Status { get;private set; }
    }


    public enum Status
    {
        None,
        Accepted,
        Declined
    }
}
