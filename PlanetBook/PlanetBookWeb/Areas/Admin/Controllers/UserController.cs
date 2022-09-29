using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using PlanetBook.DataAccess.Data;
using PlanetBook.DataAccess.Repository.IRepository;
using PlanetBook.Models;
using PlanetBook.Utility;
using System;
using System.Data;
using System.Linq;

namespace PlanetBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Employee)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }


        #region APIs Call
        [HttpGet]
        public IActionResult GetAll()
        {
            var userList = _db.ApplicationUsers.Include(u => u.Company).ToList();
            var userRole = _db.UserRoles.ToList();
            var roles = _db.Roles.ToList();
            foreach (var user in userList)
            {
                var roleId = userRole.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;
                if (user.Company == null)
                {
                    user.Company = new Company()
                    {
                        Name = ""
                    };
                }
            }

            return Json(new { data = userList });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
                return Json(new { success = false, message = "Lỗi khi khóa/ mở khóa" });
            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
                objFromDb.LockoutEnd = DateTime.Now;
            else
                objFromDb.LockoutEnd = DateTime.Now.AddDays(15);
            _db.SaveChanges();
            return Json(new { success = true, message = "Thành công!" });
        }
        #endregion
    }
}
