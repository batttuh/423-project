using System.Collections.Generic;
using System.Threading.Tasks;
using back_side_Model.Models;

namespace back_side_DataAccess.Repositories
{
    public interface IAdvertisementRepository
    {
        Task<List<Advertisement>> GetAllAdvertisements();
        Task<Advertisement> GetAdvertisementById(int advertisementId);
        Task CreateAdvertisement(Advertisement advertisement);
        Task UpdateAdvertisement(Advertisement advertisement);
        Task DeleteAdvertisement(int advertisementId);
    }
}
