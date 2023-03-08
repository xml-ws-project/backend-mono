using MongoDB.Driver;
using MonoLibrary.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Context
{
    public class XMLContext : IXMLContext
    {
        private IMongoDatabase Database { get; set; }
        public IClientSessionHandle Session { get; set; }
        public MongoClient Client { get; set; }

        private readonly List<Func<Task>> _commands;
        private readonly ProjectConfiguration _configuration;

        public XMLContext(ProjectConfiguration configuration)
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

            Client = new MongoClient(_configuration.DBConfig.ConnectionString);
            Database = Client.GetDatabase(_configuration.DBConfig.DataBaseName);
        }
        public IMongoCollection<T> GetCollection<T>(string name) 
        {
            ConfigureMongo();
            return Database.GetCollection<T>(name);
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
