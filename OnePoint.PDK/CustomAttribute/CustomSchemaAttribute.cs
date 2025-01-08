using OnePoint.PDK.TypeDefination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.CustomAttribute
{
    public class CustomSchemaAttribute : Attribute
    {
        public CustomSchemaAttribute(string Name, string Version, int Priority, Consumer Consumer, Protocal Protocal)
        {
            this.Name = Name;
            this.Version = Version;
            this.Priority = Priority;
            this.Protocal = Protocal;
        }

        public string Name { get; set; } = null!;
        public string Version { get; set; } = null!;
        public int Priority { get; set; }
        public Consumer Consumer { get; set; }
        public Protocal Protocal { get; set; }
    }
}
