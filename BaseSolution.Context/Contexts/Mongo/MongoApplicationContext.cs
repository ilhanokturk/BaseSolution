using BaseSolution.Abstraction.Context.MongoContext;
using BaseSolution.Utilities.Application;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace BaseSolution.Context.Contexts.Mongo
{
    public class MongoApplicationContext:IMongoContext
    {
        private IMongoDatabase MongoDatabase { get; set; }
        public MongoClient MongoClient { get; set; }
        public IClientSessionHandle SessionHandle { get; set; }

        public MongoApplicationContext(IOptions<MongoOptions> options)
        {
            MongoClient = new MongoClient(options.Value.MongoConnection);
            MongoDatabase = MongoClient.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name) => MongoDatabase.GetCollection<T>(name);

        public void Dispose()
        {
            GC.SuppressFinalize(MongoDatabase);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
