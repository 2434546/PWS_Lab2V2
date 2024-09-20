using ForumDeDiscussion.Data.Context;
using ForumDeDiscussion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using ForumDeDiscussion.Helpers;
using ForumDeDiscussion.ViewModels;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.Members.AnyAsync(m => m.UserName == viewModel.UserName || m.Email == viewModel.Email);
                if (existingUser)
                {
                    ModelState.AddModelError("", "Un utilisateur avec ce nom ou cet email existe déjà.");
                    return View(viewModel);
                }

                string hashedPassword = CryptographyHelper.HashPassword(viewModel.Password);

                var newMember = new Member
                {
                    Name = viewModel.Name,
                    Firstname = viewModel.Firstname,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    Password = hashedPassword,
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();
                return RedirectToAction("MembersManagement", "MembersManagement");
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("MembersManagement");
        }
        
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _context.Members.FirstOrDefaultAsync(m => m.Id == int.Parse(userId));

            if (user == null)
            {
                return NotFound();
            }

            var viewModel = new EditProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                FirstName = user.Firstname
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(EditProfileViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var user = await _context.Members.FirstOrDefaultAsync(m => m.Id == int.Parse(userId));

                if (user != null)
                {
                    user.UserName = viewModel.UserName;
                    user.Email = viewModel.Email;
                    user.Name = viewModel.Name;
                    user.Firstname = viewModel.FirstName;
                    
                    if (!string.IsNullOrWhiteSpace(viewModel.NewPassword))
                    {
                        user.Password = CryptographyHelper.HashPassword(viewModel.NewPassword);
                    }

                    _context.Update(user);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "Profil mis à jour avec succès.";
                    return RedirectToAction("MembersManagement", "MembersManagement");
                }

                ModelState.AddModelError("", "Une erreur est survenue lors de la mise à jour du profil.");
            }

            return View(viewModel);
        }
    }
}
