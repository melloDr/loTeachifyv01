using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teachify.Models
{
    public class RegisterModel
    {
        public string email {get; set;}
        public string password {get; set;}
        public string confirmPassword {get; set;}
    }
}