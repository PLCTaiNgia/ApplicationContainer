using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.Controls.Internals.Profile;

namespace AppContainer.Models
{
    public class SizeRespone
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<SizeContainer> Data { get; set; }
    }
}
