using RotaryClub.Data;
using RotaryClub.Interfaces;

namespace RotaryClub.Services
{
    public class PhotoService : IPhotoService
    {
        public async Task<string> Create(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-FFFFFF") +extension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\members", fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileSteam);
            }
            return filePath;
        }

        public Status Delete(string path)
        {
            throw new NotImplementedException();
        }

        public async Task<string> Update(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
