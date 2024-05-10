using Microsoft.AspNetCore.Mvc;
using Resturant_pro.Models;
using Resturant_pro.AccessData.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Resturant_pro.Utility;


namespace Resturant_Pro.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CategoryController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }



        public IActionResult Index()
        {
            List<Category> categorylist = _UnitOfWork.Category.GetAll().ToList();
            return View(categorylist);
        }


        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Category category)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Add(category);
                _UnitOfWork.save();
                TempData["Success"] = "Your category has ben added successfuly";
                return RedirectToAction("Index");
            }
            else
            {

                return View(category);
            }
        }



        public IActionResult Edit(int? Id)
        {
            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var category = _UnitOfWork.Category.Get(u => u.Id == Id);
            if (category == null)
            {
                return base.NotFound(nameof(Category.Id));
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Category.Update(category);
                _UnitOfWork.save();
                TempData["Success"] = "Your category has ben Editing successfuly";
                return RedirectToAction("Index");
            }
            else
            {
                return View(category);
            }
        }


        public IActionResult Remove(int? Id)
        {

            if (Id == 0 || Id == null)
            {
                return NotFound();
            }
            var category = _UnitOfWork.Category.Get(u => u.Id == Id);
            if (category == null)
            {
                return base.NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Remove(Category category)
        {
            _UnitOfWork.Category.Remove(category);
            _UnitOfWork.save();
            TempData["Success"] = "Your category has ben removed successfuly";
            return RedirectToAction("Index");
        }
    }
}
