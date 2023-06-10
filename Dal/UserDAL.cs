using System.Collections.Generic;
using System.Linq;
using back_side_DataAccess.Data;
using back_side_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserRepository(ApplicationDbContext dbContext, IPasswordHasher<User> passwordHasher)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
    }

    public User GetUserByEmail(string email)
    {
        return _dbContext.Set<User>().FirstOrDefault(u => u.e_mail == email);
    }

    public void CreateUser(User user)
    {
        // Hash the password before saving
        user.Password = HashPassword(user,user.Password);

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

    public bool VerifyPassword(User user,string passwordRequest, string passwordUser)
    {
        // Verify the password hash
        var result = _passwordHasher.VerifyHashedPassword(user, passwordUser, passwordRequest);
        return result == PasswordVerificationResult.Success;
    }

    private string HashPassword(User user,string password)
    {
        // Hash the password
        var hashedPassword = _passwordHasher.HashPassword(user, password);
        return hashedPassword;
    }
}
