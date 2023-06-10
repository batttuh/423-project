using back_side_Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_side_DataAccess.Repositories
{
    public interface IUserTypeRepository
    {
        Task<List<UserType>> GetAllUserTypes();
        Task<UserType> GetUserTypeById(int userTypeId);
        Task CreateUserType(UserType userType);
        Task UpdateUserType(UserType userType);
        Task DeleteUserType(int userTypeId);
    }
}