using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.CustomAttribute
{
    public class CustomModelAttribute : Attribute
    {
        public CustomModelAttribute(string TableName,string CacheKey)
        {
            this.TableName = TableName;
            this.CacheKey = CacheKey;
        }
        public string TableName { get; set; }
        public string CacheKey { get; set; }
    }
}
