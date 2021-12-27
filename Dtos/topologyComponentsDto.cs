using System.ComponentModel.DataAnnotations;
using topology_api.modules;

namespace topology_api.Dtos
{
public class TopologyComponentsDto
    {
        [Required]
        public string type { get; set; }
        [Required]
        public string id { get; set; }
        [Required]
        public ValuesDto value {get; set; }
        [Required]
        public Dictionary<string, string> netlist { get; set; }
    }
}