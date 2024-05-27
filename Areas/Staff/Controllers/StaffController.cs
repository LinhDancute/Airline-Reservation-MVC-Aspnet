using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using App.Areas.Identity.Controllers;
using App.Data;
using App.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Areas.Staff.Controllers
{
    [Authorize(Roles = RoleName.Administrator)]
    [Area("Staff")]
    [Route("/ManageStaff/[action]")]
    public class StaffController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        private readonly UserManager<App.Models.Staff.Staff> _userManager;

        public StaffController(ILogger<RoleController> logger, RoleManager<IdentityRole> roleManager, AppDbContext context, UserManager<App.Models.Staff.Staff> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        //
        // GET: /ManageStaff/Index
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery(Name = "p")] int currentPage)
        {
            var model = new StaffListModel();
            model.currentPage = currentPage;

            var qr = _userManager.Users.OrderBy(u => u.FirstName);

            model.totalStaffs = await qr.CountAsync();
            model.countPages = (int)Math.Ceiling((double)model.totalStaffs / model.ITEMS_PER_PAGE);

            if (model.currentPage < 1)
                model.currentPage = 1;
            if (model.currentPage > model.countPages)
                model.currentPage = model.countPages;

            var qr1 = qr.Skip((model.currentPage - 1) * model.ITEMS_PER_PAGE)
                        .Take(model.ITEMS_PER_PAGE)
                        .Select(u => new StaffAndRole()
                        {
                            Id = u.Id,
                            FirstName = u.FirstName,
                            LastName = u.LastName,
                        });

            model.staffs = await qr1.ToListAsync();

            foreach (var staff in model.staffs)
            {
                var roles = await _userManager.GetRolesAsync(staff);
                staff.RoleNames = string.Join(",", roles);
            }

            return View(model);
        }
    }
}