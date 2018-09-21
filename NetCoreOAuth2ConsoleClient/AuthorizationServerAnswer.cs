using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreOAuth2ConsoleClient
{
    /// <summary>
    /// Objeto que tiene la informacion del Token
    /// </summary>
    public class AuthorizationServerAnswer
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
    }
}
