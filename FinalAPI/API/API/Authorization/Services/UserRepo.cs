using API.Authorization.Interfaces;
using API.Exceptions;
using API.Models.DTO;
using API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API.Authorization.Services
{
    public class UserRepo : IUser
    {
        private readonly BigBang2Context _context;
        public UserRepo(BigBang2Context context)
        {
            _context = context;
        }
        public async Task<User?> Add(User user)
        {
            try
            {
                var users = _context.Users;
                var myUser = await users.SingleOrDefaultAsync(u => u.UserName == user.UserName);
                if (myUser == null)
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public User? Delete(UserDTO userDTO)
        {
            try
            {
                var users = _context.Users;
                var myUser = users.SingleOrDefault(u => u.UserName == userDTO.UserName);
                if (myUser != null)
                {
                    _context.Users.Remove(myUser);
                    _context.SaveChanges();
                    return myUser;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<User?> Get(UserDTO userDTO)
        {
            try
            {
                var users = await GetAll();
                var user = users.FirstOrDefault(u => u.UserName == userDTO.UserName);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<List<User>?> GetAll()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users != null)
                    return users;
                return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }

        public async Task<User> Update(User user)
        {
            try
            {
                var users = await GetAll();
                var Newuser = users.FirstOrDefault(u => u.UserName == user.UserName);
                if (Newuser != null)
                {
                    _context.Users.Update(Newuser);
                    await _context.SaveChangesAsync();
                    return Newuser;
                }
                else
                    return null;
            }
            catch (SqlException se) { throw new InvalidSqlException(se.Message); }
        }
    }

}
