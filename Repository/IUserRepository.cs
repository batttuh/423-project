using back_side_Model.Models;
using System.Collections.Generic;


namespace back_side_DataAccess.Repositories
{
    public interface IUserRepository
    {
        User GetUserByEmail(string username);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        List<User> GetAllUsers();
        Boolean VerifyPassword(User user, string passwordRequest, string passwordUser);
        List<Post> GetPostsByUserId(int userId);
    }
}