using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class IntensiveCareRoomRepository : IIntensiveCareRoomRepository
    {
        private readonly AppDbContext _context;

        public IntensiveCareRoomRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(IntensiveCareRoom intensiveCareRoom)
        {
            await _context.IntensiveCareRooms.AddAsync(intensiveCareRoom);
            await _context.SaveChangesAsync();
        }

       
        public async Task DeleteAsync(int id)
        {
            var IntensiveCareRoomInDb = await _context.IntensiveCareRooms.FindAsync(id) ?? throw new KeyNotFoundException($"IntensiveCareRoom with id {id} was not found.");
            _context.IntensiveCareRooms.Remove(IntensiveCareRoomInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<IntensiveCareRoom>> GetAllAsync()
        {
            return await _context.IntensiveCareRooms.ToListAsync();
        }

        public async Task<IntensiveCareRoom?> GetByIdAsync(int id)
        {
            return await _context.IntensiveCareRooms.FindAsync(id);
        }

        public async Task UpdateAsync(IntensiveCareRoom intensiveCareRoom)
        {
            _context.IntensiveCareRooms.Update(intensiveCareRoom);
            await _context.SaveChangesAsync();
        }
   
      
    }
}
