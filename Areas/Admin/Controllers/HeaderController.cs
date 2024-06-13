using kurikulum.Areas.Admin.ViewModels.Header;
using kurikulum.Areas.Data.Helper;
using kurikulum.Models.Context;
using kurikulum.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace kurikulum.Areas.Admin.Controllers
{
	public class HeaderController : Controller
	{
		readonly private IFormFileService _formFileService;
		readonly private AppDbContext _context;


		public HeaderController(IFormFileService formFileService, AppDbContext context)
		{
			_formFileService = formFileService;
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			List<Header> header = await _context.Headers.ToListAsync();

			if (header.Any())
			{

				return RedirectToAction(nameof(Create), nameof(Header));
			}

			return View(header);
		}

		public async Task<IActionResult> Details(string Id)
		{
			var header = await _context.Headers.FirstOrDefaultAsync(a => a.Id == Guid.Parse(Id));

			if (header != null)
			{
				return NotFound();
			}

			return View(header);
		}

		public async Task<IActionResult> Create()
		{
			var header = await _context.Headers.ToListAsync();

			if (header.Any())
			{
				return RedirectToAction(nameof(Index));
			}
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Create(CreateHeaderVM model)
		{
			if (!ModelState.IsValid) return View(model);
			if (_formFileService.IsImage(model.FormFile) != null)


			{
				ModelState.AddModelError("model.FormFile", "Zehmet olmasa duzgun formatda şəkil elavə edin !");
			}

			var photo = await _formFileService.UploadAsync(model.FormFile);
			Header header = new Header()
			{
				Photo = photo,

			};
			await _context.Headers.AddAsync(header);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(string Id)
		{
			var header = await _context.Headers.FirstOrDefaultAsync(a => a.Id == Guid.Parse(Id));



			if (header == null)
			{
				return NotFound();
			}
			return View(header);
		}
		[HttpPost]
		public async Task<IActionResult> Update(string Id, UpdateHeaderVM model)
		{
			if (!ModelState.IsValid) return View(model);
			if (model.Id == Id)
			{
				if (model.FormFile != null)
				{
					var _header = await _context.Headers.FirstOrDefaultAsync(a => a.Id == Guid.Parse(model.Id));
					if (_formFileService.IsImage(model.FormFile) != null)


					{
						ModelState.AddModelError("model.FormFile", "Zehmet olmasa duzgun formatda şəkil elavə edin !");

					}

					var path = Path.Combine(Directory.GetCurrentDirectory(), "//assets//ui//image", _header.Photo);
					await _formFileService.DeleteFormFile(path);
					var photo = await _formFileService.UploadAsync(model.FormFile);
					Header header = new Header()
					{
						Photo = photo,

					};
				}

			}






			return RedirectToAction(nameof(Index));
		}


		[HttpPost]
		public async Task<IActionResult> Delete (string id)
		{
			var header = await _context.Headers.FindAsync(id);

			var path = Path.Combine(Directory.GetCurrentDirectory(), "//ui//image//", header.Photo);


			return RedirectToAction(nameof(Index));
		}
	}
}