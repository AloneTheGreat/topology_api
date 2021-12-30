using System.Dynamic;
using System.Reflection;
using topology_api.modules;

namespace topology_api
{
    public static class Extensions
    {
        public static CreateTopologyDto AsDto (this Topology topology){
            CreateTopologyDto topologyDto = new CreateTopologyDto();
            topologyDto.components = new List<Dictionary<string, dynamic>>();
            topologyDto.id = topology.id;
            foreach(var component in topology.components)
            {
                Dictionary<string, dynamic> components = new Dictionary<string, dynamic>(){
                    ["id"] = component.id.ToString(),
                    ["type"] = component.type.ToString(),
                    [component.value_Id] = component.value,
                    ["netlist"] = component.netlist
                };
                topologyDto.components.Add(components);
            }
            return topologyDto;
        }
    }
}