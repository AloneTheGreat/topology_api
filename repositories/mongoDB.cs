using MongoDB.Bson;
using MongoDB.Driver;
using topology_api.modules;

namespace topology_api.repositories
{
    public class MongoDb : Imemory
    {
        private const string DatabaseName = "Topology_Api";
        public const string CollectionName = "topologies";
        private readonly IMongoCollection<Topology> topologiesCollection;
        private readonly FilterDefinitionBuilder<Topology> filterBuilder = Builders<Topology>.Filter;
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
            var filter = filterBuilder.Eq(topology => topology.id, id);
            topologiesCollection.DeleteOne(filter);
        }

        public IEnumerable<Topology> Get_Topologies()
        {
            return topologiesCollection.Find(new BsonDocument()).ToList();
        }

        public Topology Get_Topology(string id)
        {
            var filter = filterBuilder.Eq(topology => topology.id, id);
            return topologiesCollection.Find(filter).SingleOrDefault();
        }
    }
}