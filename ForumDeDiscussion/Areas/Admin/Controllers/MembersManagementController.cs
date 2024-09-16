using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace ForumDeDiscussion.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Member.ROLE_ADMIN)]
    public class MembersManagementController : Controller
    {
        private readonly ForumDeDiscussionDbContext _context;

        public MembersManagementController(ForumDeDiscussionDbContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> MembersManagement()
        {
            var members = await _context.Members.ToListAsync();
            return View(members);
        }
    }
}
