using Microsoft.EntityFrameworkCore;
using VKmfSoft_EHealth_API.Data;
using VKmfSoft_EHealth_API.Models.Domain.Hospital.Room;
using VKmfSoft_EHealth_API.Repositories.Interfaces;

namespace VKmfSoft_EHealth_API.Repositories.Repos
{
    public class OnePersonPatientRoomRepository : IOnePersonPatientRoomRepository
    {
        private readonly AppDbContext _context;

        public OnePersonPatientRoomRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public async Task AddAsync(OnePersonPatientRoom onePersonPatientRoom)
        {
            await _context.OnePersonPatientRooms.AddAsync(onePersonPatientRoom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var OnePersonPatientRoomInDb = await _context.OnePersonPatientRooms.FindAsync(id) ?? throw new KeyNotFoundException($"OnePersonPatientRoom with id {id} was not found.");
            _context.OnePersonPatientRooms.Remove(OnePersonPatientRoomInDb);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<OnePersonPatientRoom>> GetAllAsync()
        {
            return await _context.OnePersonPatientRooms.ToListAsync();
        }

        public async Task<OnePersonPatientRoom?> GetByIdAsync(int id)
        {
            return await _context.OnePersonPatientRooms.FindAsync(id);
        }

        public async Task UpdateAsync(OnePersonPatientRoom onePersonPatientRoom)
        {
            _context.OnePersonPatientRooms.Update(onePersonPatientRoom);
            await _context.SaveChangesAsync();
        }
    }
}
