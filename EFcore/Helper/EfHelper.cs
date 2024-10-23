using DBDK.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFcore.Helper
{
    internal class EfHelper : CustomDbHelper
    {
        public override string GetConnectionString()
        {
            const string conn = "Server=DESKTOP-KH5S7CP;Initial Catalog=LRMS;User=sa;Password=Dotaplayer;TrustServerCertificate=true;";
            return conn;
        }
    }
}
