using BiluthyrningAB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiluthyrningAB.Persistence.Repositories
{
    public class EntityFrameworkRepository : IEntityFrameworkRepository
    {
        private readonly AppDbContext _context;

        public EntityFrameworkRepository(AppDbContext context)
        {
            _context = context;
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
