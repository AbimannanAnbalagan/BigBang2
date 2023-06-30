using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Healthcare.Repository.UserRepo
{
  public class UserService :IUserService
  {
    private readonly HealthCareContext _context;

    public UserService(HealthCareContext context)
    {
      _context = context;
    }

    public async Task<List<User>> GetUser()
    {
      var result = await _context.Users.ToListAsync();
      if (result == null)
      {
        throw new Exception("NO users");
      }
      return result;
    }

    public async Task<List<User>> PostUser(User users)
    {
      await _context.AddAsync(users);
      await _context.SaveChangesAsync();
      return await _context.Users.Where(x => x.UserId == users.UserId).ToListAsync();
    }

  }
}
