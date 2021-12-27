using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace topology_api.modules
{
    public class Topology
    {
        [Required]
        public string id { get; set; }
        [Required]
        public List<TopologyComponents> components { get; set; }
    }
}