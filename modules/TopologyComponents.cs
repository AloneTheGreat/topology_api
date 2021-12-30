using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Json.Net;

namespace topology_api.modules
{
    public class TopologyComponents
    {
    //     public object this[string propertyName]
    // {
    //     get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
    //     set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
    // }
        [Required]
        public string type { get; set; }

        [Required]
        public string id { get; set; }

        [Required]
        public string value_Id {get; set; }

        [Required]
        public Values value {get; set; }
        
        [Required]
        public Dictionary<string, string> netlist { get; set; }
    }
}