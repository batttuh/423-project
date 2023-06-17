using back_side_Model.Models;

public interface IUserRepository
{
    Task<User> GetUserByEmail(string username);
    void CreateUser(User user);
    void UpdateUser(User user);
    void DeleteUser(int userId);
    List<User> GetAllUsers();
    Boolean VerifyPassword(User user,string passwordRequest, string passwordUser);
}