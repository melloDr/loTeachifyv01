using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teachify.Models
{
    public class RegisterModel
    {
        public string Email {get; set;}
        public string Password {get; set;}
        public string ConfirmPassword {get; set;}
    }
}