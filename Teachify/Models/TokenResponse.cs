using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teachify.Models
{
    public class TokenResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string username { get; set; }
        public string issued { get; set; }
        public string expires { get; set; }      
        
    }

    public class resultTokenModel
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public TokenResponse Data { get; set; }
        public object ResponseFailed { get; set; }
        public string Message { get; set; }
    }
}