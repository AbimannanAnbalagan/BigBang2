using Healthcare.Models;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.Repository.UserRepo
{
  public interface IUserService 
  {
    Task<List<User>> GetUser();

    Task<List<User>> PostUser(User users);
  }
}

