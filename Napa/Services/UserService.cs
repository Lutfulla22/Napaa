using Microsoft.EntityFrameworkCore;
using Napa.Data;
using Napa.Models;

namespace Napa.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(bool IsSuccess, Exception exception)> InsertUserAsync(User login)
        {
            try
            {
                await _context.Users.AddAsync(login);
                await _context.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception e)
            {
                return (false, e);
            }
        }
    }
}
