namespace kurikulum.Helper
{
    public interface IVideoFileService
    {
        Task<string> UploadVideoAsync(IFormFile file);
        bool IsVideo(IFormFile file);
        
        void Delete(string path);
    }
}
