using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlanetBook.DataAccess.Repository.IRepository;
using PlanetBook.Models;
using PlanetBook.Models.ViewModels;
using PlanetBook.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlanetBookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomePageController : Controller
    {
        private readonly ILogger<HomePageController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomePageController(ILogger<HomePageController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category,CoverType");
            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            //if (claim != null)
            //{
            //    var count = _unitOfWork.ShoppingCart
            //        .GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count();
            //    HttpContext.Session.SetInt32(SD.ShoppingCart_Session, count);
            //}

            return View(productList);
        }

        public IActionResult Details(int id)
        {
            var productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id, includeProperties: "Category,CoverType");
            ShoppingCart carObj = new ShoppingCart()
            {
                Product = productFromDb,
                ProductId = productFromDb.Id
            };
            return View(carObj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            shoppingCart.Id = 0;
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingCart.ApplicationUserId = claim.Value;
                ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.
                    GetFirstOrDefault(u => u.ApplicationUserId == shoppingCart.ApplicationUserId 
                    && u.ProductId == shoppingCart.ProductId, includeProperties:"Product");
                if (cartFromDb == null)
                {
                    _unitOfWork.ShoppingCart.Add(shoppingCart);
                }    
                else
                {
                    cartFromDb.Count += shoppingCart.Count;
                    //_unitOfWork.ShoppingCart.Update(cartFromDb);
                }
                _unitOfWork.Save();

                var count = _unitOfWork.ShoppingCart
                    .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).ToList().Count();
                //HttpContext.Session.SetObject(SD.ShoppingCart_Session, shoppingCart);
                //var obj = HttpContext.Session.GetObject<ShoppingCart>(SD.ShoppingCart_Session);
                HttpContext.Session.SetInt32(SD.ShoppingCart_Session, count);
                return RedirectToAction("Index");
            }
            else
            {
                var productFromDb = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == shoppingCart.Id, 
                    includeProperties: "Category,CoverType");
                ShoppingCart carObj = new ShoppingCart()
                {
                    Product = productFromDb,
                    ProductId = productFromDb.Id
                };
            }
            
            return View(shoppingCart);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
