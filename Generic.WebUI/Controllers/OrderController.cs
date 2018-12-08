using Generic.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;
using Generic.WebUI.Models;

namespace Generic.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private OrderManager _orderManager;
        public OrderController(OrderManager orderDal)
        {
            _orderManager = orderDal;
        }
        //paging - E.D. (6,7)
        public int pageSize = 5;
        public ViewResult Index(int page = 1)
        {
            var orderList = _orderManager.GetAll();
            return View(new OrderViewModel
            {
                Orders = orderList.Skip((page - 1) * pageSize).Take(5).ToList(),
                PagingInfo = new PagingInfo
                {
                    ItemsPerPage = pageSize,
                    TotalItems = orderList.Count,
                    CurrentPage = page
                }
            });
        }


        public ActionResult Login()
        {
            return View();
        }



        public ActionResult LearnJquery()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult LearnAjax()
        //{
        //    return View(_orderManager.GetAll());
        //}
        //[HttpPost]
        //public ActionResult LearnAjax()
        //{
        //    return View();
        //}




        //jqGrid-Pager eksiği var.
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult GetData()
        {
            int pageNo = Convert.ToInt32(Request["page"]);
            int lenght = Convert.ToInt32(Request["rows"]);
            string sortColumnName = Request["sidx"];
            string sortDirection = Request["sord"];
            bool _search = Convert.ToBoolean(Request["_search"]);
            string searchColumName = Request["searchField"];
            string searchKeyword = Request["searchString"];
            string searchOper = Request["searchOper"];

            var orderList = _orderManager.GetAll();

            //shorting
            if (sortColumnName != "")
                orderList.OrderBy(sortColumnName + " " + sortDirection).ToList();

            //search
            if (_search)
            {
                switch (searchOper)
                {
                    case "eq":
                        orderList = orderList.Where(searchColumName + "=@0", searchKeyword).ToList();
                        break;
                    default:
                        break;
                }
            }

            int totalPage = Convert.ToInt32(((float)orderList.Count / (float)lenght) + 0.5);
            int totalRecordCount = orderList.Count;

            //paging
            orderList = orderList.Skip((pageNo - 1) * lenght).Take(lenght).ToList();

            return Json(new { rows = orderList, page = pageNo, rowNum = lenght, records = totalRecordCount, total = totalPage }, JsonRequestBehavior.AllowGet);
        }
    }
}