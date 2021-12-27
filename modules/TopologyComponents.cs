using System.Collections.Generic;

namespace topology_api.modules
{
    public class TopologyComponents
    {
        public string type { get; set; }
        public string id { get; set; }
        public Values value {get; set; }
        public Dictionary<string, string> netlist { get; set; }
    }
}