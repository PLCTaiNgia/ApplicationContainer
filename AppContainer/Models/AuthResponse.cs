using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppContainer.Models
{
    public class AuthResponse
    {
        public User User { get; set; }
        public Token Token { get; set; }
    }
}
