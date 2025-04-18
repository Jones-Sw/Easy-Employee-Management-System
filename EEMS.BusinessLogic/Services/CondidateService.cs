using EEMS.BusinessLogic.Interfaces;
using EEMS.DataAccess;
using EEMS.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace EEMS.BusinessLogic.Services
{
    public class CondidateService : ICondidatesService
    {
        private readonly EEMSDbContext _context;

        public CondidateService(EEMSDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Condidate>> GetAsync()
        {
            return await _context.condidates.ToListAsync();
        }

        public async Task<Condidate> GetAsync(int id)
        {
            return await _context.condidates.FindAsync(id);
        }

        public async Task<int> AddAsync(Condidate condidate)
        {
            var added = _context.condidates.Add(condidate);
            await _context.SaveChangesAsync();

            return added.Entity.Id;
        }

        public async Task UpdateAsync(Condidate condidate)
        {
            _context.condidates.Update(condidate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var emp = await GetAsync(id);
            if (emp != null)
            {
                _context.condidates.Remove(emp);
                await _context.SaveChangesAsync();
            }
        }

    }
}
