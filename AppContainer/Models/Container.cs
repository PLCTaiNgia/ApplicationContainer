using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppContainer.Models
{
    public class Container
    {
        public string CntrNo { get; set; }
        public string CntrSize { get; set; }
        public string OprId { get; set; }
        public string Status { get; set; }
        public string CMStatus { get; set; }
        public List<string> Thumbnail { get; set; }
    }

}
