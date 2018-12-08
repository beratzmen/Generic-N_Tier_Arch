using Generic.Bll;
using Generic.Entities;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Generic.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //ProductManager _productManager = new ProductManager(new EFProduct());
        //IProductService _productService=new ProductManager(new EFProductDal);
        private ProductManager _productManager;
        public ProductController(ProductManager productDal)
        {
            _productManager = productDal;
        }

        //toplu kayıt listeler
        public ActionResult Index()
        {
            return View(_productManager.GetAll());
        }
        //tek kayıt listeler
        public ActionResult Get(int id)
        {
            Expression<Func<Products, bool>> predicate = x => x.ProductID == id;
            return View(_productManager.Get(predicate));
        }
        //seçilen kaydı siler
        public ActionResult Delete(int id)
        {
            _productManager.Delete(_productManager.Get(x => x.ProductID == id));
            return RedirectToAction("Index", "Home");
        }
        //yeni kayıt ekler
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Products product)
        {
            _productManager.Insert(product);
            return RedirectToAction("Index", "Home");
        }
        //mevcut bir kaydı günceller
        public ActionResult Update(int id)
        {
            return View(_productManager.Get(x => x.ProductID == id));
        }
        [HttpPost]
        public ActionResult Update(Products product)
        {
            _productManager.Update(product);
            return RedirectToAction("Index", "Home");
        }
        //Başlangıç harfine göre arama yapar.
        public ActionResult GetStartName(string startsWith)
        {
            return View(_productManager.GetProductName(startsWith));
        }
    }
}