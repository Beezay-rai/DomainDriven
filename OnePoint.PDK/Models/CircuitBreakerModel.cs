using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.Models
{
    public class CircuitBreakerModel
    {
        public bool CircuitBreak { get; set; }
        public int StatusCode { get; set; }
        public object ResponseBody { get; set; }
        public Dictionary<string,string> ResponseHeaders { get; set; }
    }
}
