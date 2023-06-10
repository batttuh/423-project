using back_side_DataAccess.Data;
using back_side_Model.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_side_DataAccess.Repositories
{
    public class UserTypeRepository : IUserTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserTypeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserType>> GetAllUserTypes()
        {
            return await _dbContext.UserTypes.ToListAsync();
        }

        public async Task<UserType> GetUserTypeById(int userTypeId)
        {
            return await _dbContext.UserTypes.FindAsync(userTypeId);
        }

        public async Task CreateUserType(UserType userType)
        {
            _dbContext.UserTypes.Add(userType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUserType(UserType userType)
        {
            _dbContext.Entry(userType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserType(int userTypeId)
        {
            var userType = await _dbContext.UserTypes.FindAsync(userTypeId);
            if (userType != null)
            {
                _dbContext.UserTypes.Remove(userType);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
