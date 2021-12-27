using topology_api.Dtos;
using topology_api.modules;

namespace topology_api
{
    public static class Extensions
    {
        public static TopologyDto AsDto (this Topology topology)
        {
            return new TopologyDto{
                id = topology.id,
                components = (List<TopologyComponentsDto>)new List<TopologyComponentsDto>().Select( component => new TopologyComponentsDto(){
                    type = component.type,
                    id = component.id,
                    value = new ValuesDto(){
                        @default = component.value.@default,
                        min = component.value.min,
                        max = component.value.max,
                    },
                    netlist = component.netlist,
                })
            };
            // return new TopologyDto{
            //     id = topology.id,
            //     components = (List<TopologyComponentsDto>)topology.components.Select(component => new TopologyComponentsDto{
            //         type = component.type,
            //         id = component.id,
            //         value = new ValuesDto{
            //             @default = component.value.@default,
            //             min = component.value.min,
            //             max = component.value.max,
            //         },
            //         netlist = component.netlist,
            //     })
            // };
        }

    }
}