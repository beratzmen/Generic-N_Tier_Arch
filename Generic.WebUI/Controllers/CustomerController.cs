using Generic.Bll;
using Generic.Entities;
using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Generic.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager;
        public CustomerController(CustomerManager customerDal)
        {
            _customerManager = customerDal;
        }

        //tüm müşterilerin listesi
        public ActionResult Index()
        {
            return View(_customerManager.GetAll());
        }
        //tek kayıt listeler
        public ActionResult Get(string id)
        {
            Expression<Func<Customers, bool>> predicate = x => x.CustomerID == id;
            return View(_customerManager.Get(predicate));
        }
        //seçilen kaydı siler
        public ActionResult Delete(string id)
        {
            _customerManager.Delete(_customerManager.Get(x => x.CustomerID == id));
            return RedirectToAction("Index", "Home");
        }
        //yeni kayıt ekler
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customers customer)
        {
            _customerManager.Insert(customer);
            return RedirectToAction("Index", "Home");
        }
        //mevcut bir kaydı günceller
        public ActionResult Update(string id)
        {
            return View(_customerManager.Get(x => x.CustomerID == id));
        }
        [HttpPost]
        public ActionResult Update(Customers customer)
        {
            _customerManager.Update(customer);
            return RedirectToAction("Index", "Home");
        }
    }
}