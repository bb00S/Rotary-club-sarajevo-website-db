using RotaryClub.Models;

namespace RotaryClub.Interfaces
{
    public interface IFacebookService
    {
        Task<IEnumerable<FacebookPost>> GetAllAsync();
        Task<FacebookPost> GetByIdAsync(int id);
        FacebookPost GetById(int id);
    }
}
