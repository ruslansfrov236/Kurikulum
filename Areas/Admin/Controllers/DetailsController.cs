using kurikulum.Areas.Admin.ViewModels.Details;
using kurikulum.Models.Context;
using kurikulum.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kurikulum.Areas.Admin.Controllers
{
    public class DetailsController : Controller
    {
        readonly private AppDbContext _context;

        public DetailsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var details = await _context.Details.ToListAsync();


            return View(details);
        }

        public async Task<IActionResult> Create()
            => View();
        [HttpPost]
        public async Task<IActionResult> Create(CreateDetailsVM model)
        {
            if (!ModelState.IsValid) return View(model);

            await _context.Details.AddAsync(new Details()
            {

                Description = model.Description,
            });


            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(string id)
        {
            var details = await _context.Details.FindAsync(id);
            if (details == null) return NotFound();

            return View(details);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateDetailsVM model)
        {
            if (!ModelState.IsValid) return View(model);

           var details =  new Details()
            {
             

                Description = model.Description

            };

            await _context.SaveChangesAsync();
        }
    }
}
