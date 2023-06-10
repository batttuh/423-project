using System.Collections.Generic;
using System.Threading.Tasks;
using back_side_DataAccess.Data;
using back_side_Model.Models;
using Microsoft.EntityFrameworkCore;

namespace back_side_DataAccess.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly ApplicationDbContext _context;

        public AdvertisementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Advertisement>> GetAllAdvertisements()
        {
            return await _context.Advertisements.ToListAsync();
        }

        public async Task<Advertisement> GetAdvertisementById(int advertisementId)
        {
            return await _context.Advertisements.FindAsync(advertisementId);
        }

        public async Task CreateAdvertisement(Advertisement advertisement)
        {
            _context.Advertisements.Add(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdvertisement(Advertisement advertisement)
        {
            _context.Entry(advertisement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdvertisement(int advertisementId)
        {
            var advertisement = await _context.Advertisements.FindAsync(advertisementId);
            if (advertisement != null)
            {
                _context.Advertisements.Remove(advertisement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
