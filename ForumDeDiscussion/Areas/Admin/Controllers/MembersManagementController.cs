using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ForumDeDiscussion.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Membre.ROLE_ADMIN)]
    public class MembersManagementController : Controller
    {
        private readonly ForumDeDiscussionDbContext _context;

        public MembersManagementController(ForumDeDiscussionDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MembersManagement()
        {
            return View();
        }
    }
}
