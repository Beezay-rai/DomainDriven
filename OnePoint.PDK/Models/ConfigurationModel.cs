using OnePoint.PDK.TypeDefination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.Models
{
    public class ConfigurationModel
    {
        public ConfigurationMapType Precedence { get; set; }
        public string PluginId { get; set; }
        public string ClusterId { get; set; }
        public string RouteId { get; set; }
        public string ConsumerId { get; set; }
        public string ConsumerGroupId { get; set; }
    }
}
