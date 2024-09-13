using ForumDeDiscussion.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace ForumDeDiscussion.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ForumDeDiscussionDbContext _context;

        public HomeController(ForumDeDiscussionDbContext context)
        {
            _context = context;
        }
    }
}
