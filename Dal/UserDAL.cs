using System.Collections.Generic;
using System.Linq;
using back_side_DataAccess.Data;
using back_side_Model.Models;
using Microsoft.EntityFrameworkCore; // Make sure to add the Entity Framework NuGet package



public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Set<User>().FirstOrDefault(u => u.e_mail == email);
    }

    public void CreateUser(User user)
    {
            Console.WriteLine("Registering user");
        _dbContext.Set<User>().Add(user);
        _dbContext.SaveChanges();
    }

    public void UpdateUser(User user)
    {
        _dbContext.Set<User>().Update(user);
        _dbContext.SaveChanges();
    }

    public void DeleteUser(int userId)
    {
        var user = _dbContext.Set<User>().Find(userId);
        if (user != null)
        {
            _dbContext.Set<User>().Remove(user);
            _dbContext.SaveChanges();
        }
    }

    public List<User> GetAllUsers()
    {
        return _dbContext.Set<User>().ToList();
    }
    public Boolean VerifyPassword(string passwordRequest, string passwordUser){
        //TODO implement this method
        return false;
    }
  
}
