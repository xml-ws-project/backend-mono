﻿using MongoDB.Driver;
using MonoLibrary.Core.DbSettings;
using MonoLibrary.Core.Model;
using MonoLibrary.Core.Repository.Core;
using MonoLibrary.Core.Service.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoLibrary.Core.Service
{
    public class FlightService : BaseService<Flight>, IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IUnitOfWork _unitOfWork;
        public FlightService(IUnitOfWork unitOfWork, IFlightRepository flightRepository) : base(unitOfWork, flightRepository)
        {
            _unitOfWork = unitOfWork;
            _flightRepository = flightRepository;
        }
    }
}
