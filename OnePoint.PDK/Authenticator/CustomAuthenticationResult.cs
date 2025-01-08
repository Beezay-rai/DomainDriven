using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnePoint.PDK.Authenticator
{
    public class CustomAuthenticationResult
    {
        public bool IsAuthenticated { get; set; }
        public bool IsAlreadyAuthenticated { get; set; }
        public string Message { get; set; }
        public string AuthenticationScheme { get; set; }
        public object ResponseObject { get; set; }
        public ClaimsPrincipal Principal { get; set; }
        public Dictionary<string, string> Headers { get; set; }
    }
}
