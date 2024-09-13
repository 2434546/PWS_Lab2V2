using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForumDeDiscussion.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SectionsManagementController : Controller
    {
        private readonly ForumDeDiscussionDbContext _context;

        public SectionsManagementController(ForumDeDiscussionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SectionManagement()
        {
            var sections = _context.sections.OrderBy(s => s.Id).ToList();
            return View(sections);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Section section)
        {
            if (ModelState.IsValid)
            {
                _context.sections.Add(section);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SectionManagement));
            }
            return View(section);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var section = _context.sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Section section)
        {
            if (ModelState.IsValid)
            {
                _context.sections.Update(section);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(SectionManagement));
            }
            return View(section);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var section = _context.sections.Find(id);
            if (section == null)
            {
                return NotFound();
            }
            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var section = _context.sections.Find(id);
            if (section != null)
            {
                _context.sections.Remove(section);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(SectionManagement));
        }
    }
}
