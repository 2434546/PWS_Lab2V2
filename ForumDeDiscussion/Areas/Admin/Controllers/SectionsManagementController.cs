using ForumDeDiscussion.Areas.Admin.ViewModels;
using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Models;
using ForumDeDiscussion.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ForumDeDiscussion.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Member.ROLE_ADMIN)]
    public class SectionsManagementController : Controller
    {
        private readonly ForumDeDiscussionDbContext _context;

        public SectionsManagementController(ForumDeDiscussionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SectionsManagement()
        {
            var sections = _context.Sections
                .Select(s => new SectionListViewModel { SectionId = s.Id, Name = s.Title })
                .ToList();

            return View(sections);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SectionListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var section = new Section { Title = viewModel.Name };
                _context.Sections.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SectionsManagement));
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SectionListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var section = await _context.Sections.FindAsync(viewModel.SectionId);
                if (section != null)
                {
                    section.Title = viewModel.Name;
                    _context.Sections.Update(section);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction(nameof(SectionsManagement));
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var section = await _context.Sections.FindAsync(id);
            if (section != null)
            {
                _context.Sections.Remove(section);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(SectionsManagement));
        }

        [HttpGet]
        public IActionResult GetSectionDetails(int id)
        {
            var section = _context.Sections
                .Where(s => s.Id == id)
                .Select(s => new SectionListViewModel { SectionId = s.Id, Name = s.Title })
                .FirstOrDefault();

            return Json(section);
        }
    }
}
