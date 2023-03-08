using MongoDB.Driver;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service
{
    public class FlightService : BaseService<Flight>, IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMongoCollection<Flight> _flights;
        private readonly ProjectConfiguration _configuration;
        public FlightService(ProjectConfiguration configuration, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;

            var mongoClient = new MongoClient(_configuration.DBConfig.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(_configuration.DBConfig.DataBaseName);
            _flights = mongoDatabase.GetCollection<Flight>(_configuration.DBConfig.CollectionName);
        }
        public Flight Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
