using RotaryClub.Data;
using RotaryClub.Interfaces;

namespace RotaryClub.Services
{
    public class PhotoService : IPhotoService
    {
        public async Task<string> Create(IFormFile file, string path)
        {
            var extension = Path.GetExtension(file.FileName);
            var fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-FFFFFF") +extension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images\"+path, fileName);

            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileSteam);
            }
            return @"/images/" + path + "/" + fileName;
        }
        public Status Delete(string path)
        {
            try
            {
                path = path.Replace('/', '\\');
                path = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\" + path);
                File.Delete(path);
            }
            catch(Exception e)
            {
                return new Status(e.Message);
            }
            return new Status();
        }

    }
}
