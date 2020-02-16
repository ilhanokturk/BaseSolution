using MongoDB.Driver;
using System;

namespace BaseSolution.Abstraction.Context.MongoContext
{
    public interface IMongoContext:IDisposable
    {
        MongoClient MongoClient { get; set; }
        IClientSessionHandle SessionHandle { get; set; }

        //Adding Mongocollection with Entity
        IMongoCollection<Entity> GetCollection<Entity>(string name);
    }
}
