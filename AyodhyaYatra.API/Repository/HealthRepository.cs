using AyodhyaYatra.API.Data;
using AyodhyaYatra.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalehGarib.API.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly AyodhyaYatraContext _context;
        public HealthRepository(AyodhyaYatraContext context)
        {
            _context = context;
        }
        public string GetDatabaseName()
        {
            return _context.Database.GetDbConnection().Database;
        }
    }
}
