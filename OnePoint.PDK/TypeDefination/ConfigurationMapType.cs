using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.TypeDefination
{
    public enum ConfigurationMapType
    {
        Consumer_Route_Cluster = 12,
        ConsumerGroup_Route_Cluster = 11,
        Consumer_Route = 10,
        Consumer_Cluster = 9,
        ConsumerGroup_Route = 8,
        ConsumerGroup_Cluster = 7,
        Route_Cluster = 6,
        Consumer = 5,
        ConsumerGroup = 4,
        Route = 3,
        Cluster = 2,
        Global = 1
    }
}
