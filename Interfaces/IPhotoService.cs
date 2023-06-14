using RotaryClub.Data;

namespace RotaryClub.Interfaces
{
    public interface IPhotoService
    {
        Task<string> Create(IFormFile file, string path);
        Status Delete(string path);
    }
}
