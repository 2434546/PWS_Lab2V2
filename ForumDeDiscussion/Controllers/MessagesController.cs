using System.Security.Claims;
using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Models;
using ForumDeDiscussion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumDeDiscussion.Controllers;

public class MessagesController : Controller
{
    private readonly ForumDeDiscussionDbContext _context;
        
    private readonly ILogger<MessagesController> _logger;
    
    public MessagesController(ForumDeDiscussionDbContext context, ILogger<MessagesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Messages(int id)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var messages = await _context.Messages
            .Where(m => m.SubjectId == id)
            .Select(message => new MessageViewModel
            {
                MessageId = message.Id,
                Contenu = message.Content,
                Auteur = message.Member.UserName,
                Date = message.Date
            }).ToListAsync();

        ViewBag.SujetId = id;
        ViewBag.CurrentUserId = userId;

        return View(messages);
    }

    
    [HttpPost]
    public async Task<IActionResult> SendMessage(int subjectId, string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            TempData["Error"] = "Veuillez entrer un message.";
            return RedirectToAction(nameof(Messages), new { id = subjectId });
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        
        try
        {
            var message = new Message
            {
                Content = content,
                SubjectId = subjectId,
                MemberId = int.Parse(userId),
                Date = DateTime.Now
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Message envoyé avec succès!";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erreur lors de l'envoi d'un message.");
            TempData["Error"] = "Une erreur s'est produite lors de l'envoi du message.";
        }

        return RedirectToAction(nameof(Messages), new { id = subjectId });
    }
}