using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Personnel;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class NurseRepository : INurseRepository
    {
        private readonly AppDbContext _context;

        public NurseRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(Nurse nurse)
        {
            await _context.Nurses.AddAsync(nurse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var NurseInDb = await _context.Nurses.FindAsync(id) ?? throw new KeyNotFoundException($"Nurse with id {id} was not found.");
            _context.Nurses.Remove(NurseInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nurse>> GetAllAsync()
        {
            return await _context.Nurses.ToListAsync();
        }

        public async Task<Nurse?> GetByIdAsync(int id)
        {
           return await _context.Nurses.FindAsync(id);
        }

        public bool NurseExists(int nurseId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Nurse nurse)
        {
            _context.Nurses.Update(nurse);
            await _context.SaveChangesAsync();
        }
    }
}
