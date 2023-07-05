using API.Models.DTO;
using API.Models;

namespace API.Authorization.Interfaces
{
    public interface IUser
    {
        Task<User> Add(User user);
        Task<User> Update(User user);
        User Delete(UserDTO userDTO);
        Task<User> Get(UserDTO userDTO);
        Task<List<User>?> GetAll();
    }
}
