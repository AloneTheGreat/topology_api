using System.Collections.Generic;

namespace topology_api.modules
{
    public class Topology
    {
        public string id { get; set; }
        public List<TopologyComponents> components { get; set; }
    }
}