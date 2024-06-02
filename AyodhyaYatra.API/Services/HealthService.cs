using AyodhyaYatra.API.Repository;
using AyodhyaYatra.API.Services.IServices;

namespace AyodhyaYatra.API.Services
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
