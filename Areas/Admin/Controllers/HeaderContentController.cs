using kurikulum.Areas.Admin.ViewModels.HeaderContent;
using kurikulum.Helper;
using kurikulum.Models.Context;
using kurikulum.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kurikulum.Areas.Admin.Controllers
{
    public class HeaderContentController : Controller
	{
		readonly private AppDbContext _context;
		readonly private IFormFileService _formFileService;
		public HeaderContentController(AppDbContext context, IFormFileService formFileService)
		{
			_context = context;
			_formFileService = formFileService;
		}
		public async Task<IActionResult> Index()
		{
			var headerContent = await _context.HeaderContents.ToListAsync();


			return View(headerContent);
		}

		public async Task<IActionResult> Details(string id)
		{
			var headerContent = await _context.HeaderContents.FindAsync(id);
			if (headerContent == null) return NotFound();

			return View(headerContent);
		}

		public async Task<IActionResult> Create()
		=> View();

		public async Task<IActionResult> Create(CreateHeaderContentVM model)
		{
			if (!ModelState.IsValid) return View(model);

			if (_formFileService.IsImage(model.FormFile) != null)


			{
				ModelState.AddModelError("model.FormFile", "Zehmet olmasa duzgun formatda şəkil elavə edin !");
			}


			var newImage = await _formFileService.UploadAsync(model.FormFile);
			HeaderContent headerContent = new HeaderContent()
			{
				Icon = newImage,
				Title = model.Title,
				Description = model.Description

			};

			await _context.AddAsync(headerContent);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}


		public async Task<IActionResult> Update(string Id)
		{
			var _headerContent = await _context.HeaderContents.FirstOrDefaultAsync(a => a.Id == Guid.Parse(Id));

			if (_headerContent == null) return NotFound();

			HeaderContent headerContent = new HeaderContent()
			{
				Id = _headerContent.Id,
				Icon = _headerContent.Icon,
				Title = _headerContent.Title,
				Description = _headerContent.Description
			};

			return View(headerContent);


		}

		public async Task<IActionResult> Update(string id, UpdateHeaderContentVM model)
		{
			if (!ModelState.IsValid) return View(model);
			if (id != model.Id) return NotFound();
			var _headerContent = await _context.HeaderContents.FirstOrDefaultAsync(a => a.Id == Guid.Parse(model.Id));
			if (model.FormFile != null)
			{

				var path = Path.Combine(Directory.GetCurrentDirectory(), "//ui//image//", _headerContent.Icon);
				var newImage = await _formFileService.UploadAsync(model.FormFile);


				HeaderContent headerContent = new HeaderContent()
				{

					Icon = newImage,
					Title = model.Title,
					Description = model.Description
				};

				

			}
			else
			{
				HeaderContent headerContent = new HeaderContent()
				{

					Icon = model.Icon,
					Title = model.Title,
					Description = model.Description
				};

				
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));




		}


		}
	}

