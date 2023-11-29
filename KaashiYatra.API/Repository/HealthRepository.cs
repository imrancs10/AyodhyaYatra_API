using KaashiYatra.API.Data;
using KaashiYatra.API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalehGarib.API.Repositories
{
    public class HealthRepository : IHealthRepository
    {
        private readonly KaashiYatraContext _context;
        public HealthRepository(KaashiYatraContext context)
        {
            _context = context;
        }
        public string GetDatabaseName()
        {
            return _context.Database.GetDbConnection().Database;
        }
    }
}
