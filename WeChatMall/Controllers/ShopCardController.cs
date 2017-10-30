using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.IService;
using Shop.Model;
namespace WeChatMall.Controllers
{
    public class ShopCardController : Controller
    {
        // GET: ShopCard
        public IShopCartService ShopCartService { get; set; }  //购物车表
        public IProductService ProductService { get; set; }  //商品信息表
        public ActionResult Index()
        {
            //查看购物车
            var ShopCartResult = ShopCartService.GetEntities(x => true);
            ViewBag.ShopCart = ShopCartResult.ToList();
            ViewBag.ProductInfo = ProductService;
            return View();
        }
        public ActionResult DeleteFrist()
        {
            //删除单条购物车
            ShopCart sc = new ShopCart()
            {
                ScartId = int.Parse(Request["CartId"]),
            };
            ShopCartService.Remove(sc);
            return RedirectToAction("Index");
        }
    }
}