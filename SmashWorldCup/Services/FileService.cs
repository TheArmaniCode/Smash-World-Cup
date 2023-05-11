using SmashWorldCup.Interfaces;

namespace SmashWorldCup.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async void AddLogo(IFormFile inLogo)
        {
            string folderName = "img\\Logos";
            string webRootPath = _webHostEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            using (Stream fileStream = new FileStream(newPath, FileMode.Create))
            {
                await inLogo.CopyToAsync(fileStream);
            }
        }
    }
}
