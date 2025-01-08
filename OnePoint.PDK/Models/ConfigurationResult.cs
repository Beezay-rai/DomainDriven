using OnePoint.PDK.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.Models
{
    public class ConfigurationResult
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public string ClusterId { get; set; }
        public string RouteId { get; set; }
        public string ConsumerId { get; set; }
        public string ConsumerGroupId { get; set; }
        public CustomSchema Config { get; set; }
    }
}
