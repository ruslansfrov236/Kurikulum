
namespace kurikulum.Helper
{
    public class VideoFileService : IVideoFileService
    {
        public void Delete(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }

        public bool IsVideo(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {


                return false;

            }


            if (!file.ContentType.StartsWith("video/"))
            {

                return false;
            }


            var allowedExtensions = new[] { "mp4", ".mkv", ".mpg", ".webm", ".wmv" };
            var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(fileExtension))
            {

                return false;
            }

            return true;
        }

        public async Task<string> UploadVideoAsync(IFormFile file)
        {
            var filename = $"{Guid.NewGuid()}_{file.FileName}";

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ui/assets/video/", filename);

            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
    }
}
