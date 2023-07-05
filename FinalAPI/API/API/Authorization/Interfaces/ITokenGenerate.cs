using API.Models.DTO;

namespace API.Authorization.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);

    }
}
