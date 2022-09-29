using Napa.Models;
using Napa.ViewModels;

namespace Napa.Services
{
    public interface IUserService
    {
        Task<(bool IsSuccess, Exception exception)> InsertUserAsync(User user);
    }
}
