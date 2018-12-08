using Generic.Bll;
using Generic.Dal.Abstract;
using Generic.Dal.Concrete;
using Generic.Entities;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Generic.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        //CategoryManager _categoryManager = new CategoryManager(new EFCategory());
        //ICategoryService _categoryService=new CategoryManager(new EFCategoryDal);
        private CategoryManager _categoryManager;
        public CategoryController(CategoryManager categoryDal)
        {
            _categoryManager = categoryDal;
        }

        //kategorilerin listesi
        public ActionResult Index()
        {
            return View(_categoryManager.GetAll());
        }
        //tek kayıt listeler
        public ActionResult Get(int id)
        {
            Expression<Func<Categories, bool>> predicate = x => x.CategoryID == id;
            return View(_categoryManager.Get(predicate));
        }
        //seçilen kaydı siler
        public ActionResult Delete(int id)
        {
            _categoryManager.Delete(_categoryManager.Get(x => x.CategoryID == id));
            return RedirectToAction("Index", "Home");
        }
        //yeni kayıt ekler
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Categories category)
        {
            _categoryManager.Insert(category);
            return RedirectToAction("Index", "Home");
        }
        //mevcut bir kaydı günceller
        public ActionResult Update(int id)
        {
            return View(_categoryManager.Get(x => x.CategoryID == id));
        }
        [HttpPost]
        public ActionResult Update(Categories category)
        {
            _categoryManager.Update(category);
            return RedirectToAction("Index", "Home");
        }
    }
}