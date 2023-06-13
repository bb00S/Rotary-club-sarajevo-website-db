using RotaryClub.Data;

namespace RotaryClub.Interfaces
{
    public interface IPhotoService
    {
        Task<string> Create(IFormFile file);
        Task<string> Update(IFormFile file);
        Status Delete(string path);
    }
}
