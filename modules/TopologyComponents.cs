using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace topology_api.modules
{
    public class TopologyComponents
    {
        [Required]
        public string type { get; set; }

        [Required]
        public string id { get; set; }

        [Required]
        public Values value {get; set; }
        
        [Required]
        public Dictionary<string, string> netlist { get; set; }
    }
}