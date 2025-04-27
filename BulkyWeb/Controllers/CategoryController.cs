using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        {
            _db = db;
        }
        public IActionResult Index()
        {
           List<Category> objCategoryList = _db.categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name.ToLower() == obj.DisplayOrder.ToString()){
                ModelState.AddModelError("name", "The Display order cannot match the Name.");
            }
           
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created sucessfully";
            }
            return RedirectToAction("Index");
        }



        public IActionResult Edit(int? id)
        {
            if ((id==null || id== 0))
            {
                return NotFound();
            }
            Category categoryfromDb = _db.categories.Find(id);
            
            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
        
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Edited sucessfully";
                return RedirectToAction("Index");
            }
            return View();
           
        }


        public IActionResult Delete(int? id)
        {
            if ((id == null || id == 0))
            {
                return NotFound();
            }
            Category categoryfromDb = _db.categories.Find(id);

            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }

        [HttpPost, ActionName ("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.categories.Find(id); 
            if(obj == null)
            {
                return NotFound();
            }
            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted sucessfully";
            return RedirectToAction("Index");
            
           

        }
    }
}
