using Microsoft.AspNetCore.Mvc;
using topology_api.repositories;
using topology_api.modules;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using System.Dynamic;

namespace topology_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class TopologyController : ControllerBase
    {
        private readonly Imemory repository;

        public TopologyController(Imemory repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async  Task<List<CreateTopologyDto>> Get_Topologies_Async()
        {
            var items = (await repository.Get_Topologies_Async())
                        .Select( item => item).ToArray();
            var itemsDto = new List<CreateTopologyDto>();
            for (int i = 0; i < items.Count(); i++)
            {
                itemsDto.Add(items[i].AsDto());
            }
            return itemsDto;
        }

        [HttpGet("{id}")]
        public async  Task<ActionResult<CreateTopologyDto>> Get_Topology_Async(string id)
        {
            var item = await repository.Get_Topology_Async(id);
            if (item is null)
            {
                return NotFound();
            }
            // string obj = JsonConvert.SerializeObject(item.AsDto());
            // string json_file_path = String.Format(@"Results\\\{0}.json", item.id);
            // System.IO.File.WriteAllText(json_file_path, obj);
            return item.AsDto();
        }

        [HttpGet("{id}/components")]
        public async  Task<ActionResult<List<Dictionary<string, dynamic>>>> Get_Topology_Components_Async(string id)
        {
            var item = await repository.Get_Topology_Async(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.AsDto().components;
        }

        [HttpGet("{id}/components/{netlist_id}")]
        public async  Task<ActionResult<List<Dictionary<string, dynamic>>>> Get_Topology_NetList_Components_Async(string id, string netlist_id)
        {
            var item = await repository.Get_Topology_Async(id);
            if (item is null)
            {
                return NotFound();
            }
            var result = from s in item.AsDto().components where s["netlist"].ContainsValue(netlist_id) select s;
            return result.ToList();
        }

        [HttpDelete("{id}")]
        public async  Task<ActionResult> Delete_Topology_Async(string id)
        {
            var existingTopology = await repository.Get_Topology_Async(id);
            if (existingTopology is null)
            {
                return NotFound();
            }
            await repository.Delete_Topology_Async(id);
            return NoContent();
        }

        [HttpPost]
        public async  Task<ActionResult<Topology>> Create_Topology_Async(string json_file_path)
        {
            string json_text = System.IO.File.ReadAllText(json_file_path);
            CreateTopologyDto obj = JsonConvert.DeserializeObject<CreateTopologyDto>(json_text);
            Topology topology = new Topology();
            topology.id = obj.id;
            topology.components = new List<TopologyComponents>();
            foreach(var component in obj.components)
            {
                TopologyComponents components = new TopologyComponents();
                foreach(var key in component.Keys)
                {
                    switch (key)
                    {
                        case "id":
                            components.id = component[key].ToString();
                            break;
                        case "type":
                            components.type = component[key].ToString();
                            break;

                        case "netlist":
                            components.netlist = component[key].ToObject<Dictionary<string, string>>();
                            break;

                        default:
                            components.value = component[key].ToObject<Values>();
                            components.value_Id = key.ToString();
                            break;
                    }
                }
                topology.components.Add(components);
            }
             
            await repository.Create_Topology_Async(topology);
            return CreatedAtAction(actionName: nameof(Get_Topology_Async), routeValues: new {id = topology.id}, value: topology);
        }
    }
}