namespace kurikulum.Helper
{
    public interface IFormFileService
    {

        Task<string> UploadAsync(IFormFile file);


        Task<bool> DeleteFormFile(string path);

        bool IsImage(IFormFile formFile);
    }
}
