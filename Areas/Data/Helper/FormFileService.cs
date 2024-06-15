
using kurikulum.Models.Context;

namespace kurikulum.Areas.Data.Helper
{
	public class FormFileService : IFormFileService
	{

		readonly private AppDbContext _context;

		public FormFileService(AppDbContext context)
		{
			_context = context;
		}



		public async Task<string> UploadAsync(IFormFile file)
		{
			var filename = $"{Guid.NewGuid()}_{file.FileName}";

			var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ui/assets/image/", filename);

			using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
			{
				await file.CopyToAsync(fileStream);
			}
			return filename;


		}

		public async  Task<bool> DeleteFormFile(string path)
		{
			if (File.Exists(path))
			{
				File.Delete(path);
			}

			return true;
		}

		
		public bool IsImage(IFormFile file)
		{
			if (file == null || file.Length == 0)
			{


				return false;

			}


			if (!file.ContentType.StartsWith("image/"))
			{

				return false;
			}


			var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
			var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
			if (!allowedExtensions.Contains(fileExtension))
			{

				return false;
			}

			return true;
		}

	}
}
