using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.Controls.Internals.Profile;

namespace AppContainer.Models
{
    public class OprIdRespone
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Oprld> Data { get; set; }

    }
}
