using MongoDB.Driver;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient Client { get; set; }

        private readonly List<Func<Task>> _commands;
        private readonly IDbSettings _configuration;

        public MongoDbContext(IDbSettings configuration)
        {
            _configuration = configuration;
            _commands = new List<Func<Task>>();     
        }

        public async Task<int> SaveChanges() 
        {
            ConfigureMongo();

            using (Session = await Client.StartSessionAsync()) 
            {
                Session.StartTransaction();
                var commandTasks = _commands.Select(c => c());
                await Task.WhenAll(commandTasks);
                await Session.CommitTransactionAsync();
            }
            
            return _commands.Count;
        }

        private void ConfigureMongo() 
        {
            if (Client != null) 
            {
                return;
            }

            Client = new MongoClient(_configuration.ConnectionString);
            Database = Client.GetDatabase(_configuration.DatabaseName);
        }
        public IMongoCollection<TEntity> GetCollection<TEntity>(string name) where TEntity : class
        {
            ConfigureMongo();
            return Database.GetCollection<TEntity>(name);
        }
        public void AddCommand(Func<Task> func) 
        {
            _commands.Add(func);
        }
        public void Dispose()
        {
            Session?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
