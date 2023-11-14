using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppContainer.Models
{
    public class ResponeContainer
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<Container> Data { get; set; }



        public List<Container> GetAllContainer() => Data;
        public Container GetContainerById(string Id)
        {
            var ctn = Data.FirstOrDefault(x => x.CntrNo == Id);
            return ctn;
        }
        public static List<Container> GetAllContainerById(string idCon, List<Container> _containers)
        {
            var listC = _containers.Where(x=> x.OprId == idCon)?.ToList();
            return listC;
        }

        public static List<Container> SearchContainer(string filterText, List<Container> _containers)
        {
            var containers = _containers.Where(x => !string.IsNullOrWhiteSpace(x.OprId) && x.OprId.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();

            if (containers == null || containers.Count <= 0)
                containers = _containers.Where(x => !string.IsNullOrWhiteSpace(x.CntrSize) && x.CntrSize.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            if (containers == null || containers.Count <= 0)
                containers = _containers.Where(x => !string.IsNullOrWhiteSpace(x.CntrNo) && x.CntrNo.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            else
                return containers;
            
            return containers;
        }

    }
}
