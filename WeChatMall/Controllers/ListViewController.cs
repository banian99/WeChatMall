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
            //查询所有产品
            var Product_Info = ProductService.GetEntities(y => y.ProductSortId == ProId);
            ViewBag._Products = Product_Info.ToList();
            //根据时间排序
            var TimeProduct = ProductService.GetEntities(k => k.ProductSortId == ProId).OrderByDescending(x => x.PTime).Take(3);
            ViewBag.Timeinfo = TimeProduct.ToList();
            //根据价格排序
            var PriceProduct = ProductService.GetEntities(k => k.ProductSortId == ProId).OrderByDescending(x => x.Price).Take(3);
            ViewBag.Priceinfo = PriceProduct.ToList();
            return View();
        }
    }
}