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
    }
}