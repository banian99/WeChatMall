using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.IService;

namespace WeChatMall.Controllers
{
    public class ListViewController : Controller
    {
        public IProductService ProductService { get; set; }  //产品信息表
        // GET: ListView  列表页
        public ActionResult Index(int id)
        {
            
            string ProId = id.ToString();
            var Product_Info = ProductService.GetEntities(y => y.ProductSortId == ProId);
            ViewBag._Products = Product_Info.ToList();
            return View();
        }
    }
}