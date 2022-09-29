using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using PlanetBook.DataAccess.Repository.IRepository;
using PlanetBook.Models;
using PlanetBook.Utility;
using System.Data;

namespace PlanetBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            CoverType coverType = new CoverType();
            if (id == null)
                //Create
                return View(coverType);
            var param = new DynamicParameters();
            param.Add("@Id", id);
            coverType = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get, param);
            if (coverType == null)
                return NotFound();

            return View(coverType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            if (ModelState.IsValid)
            {
                var param = new DynamicParameters();
                param.Add("@Name", coverType.Name);

                if (coverType.Id == 0)
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Create, param);
                else
                {
                    param.Add("@Id", coverType.Id);
                    _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Update, param);
                }    
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }    
            return View(coverType);
        }

        #region APIs Call
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.SP_Call.List<CoverType>(SD.Proc_CoverType_GetAll, null);
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var param = new DynamicParameters();
            param.Add("@Id", id);
            var objFromDb = _unitOfWork.SP_Call.OneRecord<CoverType>(SD.Proc_CoverType_Get, param);
            if (objFromDb == null)
                return Json(new { success = false, message = "Lỗi khi xóa!" });
            _unitOfWork.SP_Call.Execute(SD.Proc_CoverType_Delete, param);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Xóa thành công!" });
        }
        #endregion
    }
}
