﻿using System;
using IoTomatoes.Domain.Interfaces;
using IoTomatoes.Domain.Models;
using IoTomatoes.Persistence.Commons;

namespace IoTomatoes.Persistence.Repositories
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(IoTomatoesContext context) : base(context) {}
    }
}
