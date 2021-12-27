using MongoDB.Driver;
using topology_api.modules;

namespace topology_api.repositories
{
    public class MongoDb : Imemory
    {
        private const string DatabaseName = "Topology_Api";
        public const string CollectionName = "topologies";
        private readonly IMongoCollection<Topology> topologiesCollection;
        public MongoDb(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DatabaseName);
            topologiesCollection = database.GetCollection<Topology>(CollectionName);
        }
        public void Create_Topology(Topology topology)
        {
            topologiesCollection.InsertOne(topology);
        }

        public void Delete_Topology(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topology> Get_Topologies()
        {
            throw new NotImplementedException();
        }

        public Topology Get_Topology(string id)
        {
            throw new NotImplementedException();
        }
    }
}