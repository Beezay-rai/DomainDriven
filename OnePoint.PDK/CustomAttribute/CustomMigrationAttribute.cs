using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.CustomAttribute
{
    public class CustomMigrationAttribute : FluentMigrator.MigrationAttribute
    {
        public CustomMigrationAttribute(int branchNumber, int year, int month, int day, int hour, int minute, string author)
            : base(CalculateValue(branchNumber, year, month, day, hour, minute))
        {
            Author = author;
        }

        public string Author { get; private set; }
        private static long CalculateValue(int branchNumber, int year, int month, int day, int hour, int minute)
        {
            return branchNumber * 1000000000000L + year * 100000000L + month * 1000000L + day * 10000L + hour * 100L + minute;
        }
    }
}
