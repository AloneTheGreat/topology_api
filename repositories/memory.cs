using System.Collections.Generic;
using System;
using topology_api.modules;

namespace topology_api.repositories
{
    
    public class memory : Imemory
    {
        private readonly List<Topology> topologies = new()
        {
            new Topology { id = "top1", components = { new TopologyComponents() { type = "resistor", id = "res1", value = new Values() { @default = 100, min = 10, max = 1000 }, netlist = new Dictionary<string, string>() { { "t1", "vdd" }, { "t2", "n1" } } }, new TopologyComponents() { type = "nmos", id = "m1", value = new Values() { @default = 1.5, min = 1, max = 2 }, netlist = new Dictionary<string, string>() { { "drain", "n1" }, { "gate", "vin" }, { "source", "vss" } } } } },
            new Topology { id = "top2", components = { new TopologyComponents() { type = "resistor", id = "res1", value = new Values() { @default = 100, min = 10, max = 1000 }, netlist = new Dictionary<string, string>() { { "t1", "vdd" }, { "t2", "n1" } } }, new TopologyComponents() { type = "nmos", id = "m1", value = new Values() { @default = 1.5, min = 1, max = 2 }, netlist = new Dictionary<string, string>() { { "drain", "n1" }, { "gate", "vin" }, { "source", "vss" } } } } },
            new Topology { id = "top3", components = { new TopologyComponents() { type = "resistor", id = "res1", value = new Values() { @default = 100, min = 10, max = 1000 }, netlist = new Dictionary<string, string>() { { "t1", "vdd" }, { "t2", "n1" } } }, new TopologyComponents() { type = "nmos", id = "m1", value = new Values() { @default = 1.5, min = 1, max = 2 }, netlist = new Dictionary<string, string>() { { "drain", "n1" }, { "gate", "vin" }, { "source", "vss" } } } } }
        };

        public void Create_Topology(Topology topology)
        {
            topologies.Add(topology);
        }

        public void Delete_Topology(string id)
        {
            var index = topologies.FindIndex(existingTopology => existingTopology.id == id);
            topologies.RemoveAt(index);
        }

        public IEnumerable<Topology> Get_Topologies()
        {
            return topologies;
        }

        public Topology Get_Topology(string id)
        {
            return topologies.Where(Topology => Topology.id == id).SingleOrDefault();
        }
    }
}