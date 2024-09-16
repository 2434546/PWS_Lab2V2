using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Models;
using ForumDeDiscussion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumDeDiscussion.Controllers;

public class SubjectsController : Controller
{
    private readonly ForumDeDiscussionDbContext _context;
        
    private readonly ILogger<SubjectsController> _logger;

    public SubjectsController(ForumDeDiscussionDbContext context, ILogger<SubjectsController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Subjects(int sectionId)
    {
        var subjects = await _context.Subjects
            .Where(s => s.SectionId == sectionId)
            .Select(subject => new SubjectViewModel
            {
                SubjectId = subject.Id,
                Name = subject.Title,
            }).ToListAsync();
        
        ViewBag.SectionId = sectionId;
        
        return View(subjects);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AddSubjectViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var subject = new Subject
            {
                SectionId = viewModel.SectionId,
                Title = viewModel.Name
            };

            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Subjects), new { sectionId = viewModel.SectionId });
        }

        TempData["Error"] = "Une erreur est survenue lors de la création du sujet.";
        return RedirectToAction(nameof(Subjects), new { sectionId = viewModel.SectionId });
    }


    public async Task<IActionResult> Edit(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject == null)
        {
            return NotFound();
        }

        return View(subject);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Subject subject)
    {
        if (id != subject.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _context.Update(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Subjects), new { sectionId = subject.SectionId });
        }

        return View(subject);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var subject = await _context.Subjects.FindAsync(id);
        if (subject != null)
        {
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Subjects), new { sectionId = subject.SectionId });
    }
}