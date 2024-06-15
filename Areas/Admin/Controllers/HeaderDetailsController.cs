using kurikulum.Areas.Admin.ViewModels.HeaderDetails;
using kurikulum.Helper;
using kurikulum.Models.Context;
using kurikulum.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kurikulum.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class HeaderDetailsController : Controller
    {
        readonly private AppDbContext _context;
        readonly private IFormFileService _formFileService;

        public HeaderDetailsController(AppDbContext context , IFormFileService formFileService)
        {
            _context = context;
            _formFileService = formFileService;
        }
        public async Task<IActionResult> Index()
        {
            var headerDetails = await _context.HeaderDetails.ToListAsync();


            return View(headerDetails);
        }

        public async Task<IActionResult> Create()
        {
            var headerDetails = await _context.HeaderDetails.ToListAsync();

            if (headerDetails.Count() != 0) return RedirectToAction(nameof(Index));


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(UpdateHeaderDetailsVM model)
        {
            if(!ModelState.IsValid) return View(model);



            if (_formFileService.IsImage(model.FormFile) != null)


            {
                ModelState.AddModelError("model.FormFile", "Zehmet olmasa duzgun formatda şəkil elavə edin !");
            }

            var photo = await _formFileService.UploadAsync(model.FormFile);

            HeaderDetails _headerDetails = new HeaderDetails()
            {
                Title = model.Title,
                Description = model.Description,    
                Photo= photo,   

            };
            await _context.HeaderDetails.AddAsync(_headerDetails);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Update(string id)
        {
            var headerDetails = await _context.HeaderDetails.FindAsync(id);
            if (headerDetails == null) return NotFound();

            return View(headerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Update(string id)
        {

            return RedirectToAction(nameof(Index);
        }


    }
}
