using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class MorePersonPatientRoomRepository : IMorePersonPatientRoomRepository
    {
        private readonly AppDbContext _context;

        public MorePersonPatientRoomRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddAsync(MorePersonPatientRoom morePersonPatientRoom)
        {
            await _context.MorePersonPatientRooms.AddAsync(morePersonPatientRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var MorePersonPatientRoomInDb = await _context.MorePersonPatientRooms.FindAsync(id) ?? throw new KeyNotFoundException($"MorePersonPatientRoom with id {id} was not found.");
            _context.MorePersonPatientRooms.Remove(MorePersonPatientRoomInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MorePersonPatientRoom>> GetAllAsync()
        {
            return await _context.MorePersonPatientRooms.ToListAsync();
        }

        public async Task<MorePersonPatientRoom?> GetByIdAsync(int id)
        {
            return await _context.MorePersonPatientRooms.FindAsync(id);
        }

        public  async Task UpdateAsync(MorePersonPatientRoom morePersonPatientRoom)
        {
            _context.MorePersonPatientRooms.Update(morePersonPatientRoom);
            await _context.SaveChangesAsync();
        }
    }
}
