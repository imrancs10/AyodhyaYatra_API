using KaashiYatra.API.Repository.IRepository;
using KaashiYatra.API.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KaashiYatra.API.Services
{
    public class HealthService : IHealthService
    {
        private readonly IHealthRepository _healthRepository;
        public HealthService(IHealthRepository healthRepository)
        {
            _healthRepository = healthRepository;
        }
        public string GetDatabaseName()
        {
            return _healthRepository.GetDatabaseName();
        }
    }
}
