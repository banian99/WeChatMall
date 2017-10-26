using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;

namespace WeChatMall.Controllers
{
    public class ConcentController : Controller
    {
        // GET: Concent  内容页
        public IProductService ProductService { get; set; }  //商品信息表
        public IShopCartService ShopCartService { get; set; } //购物车表
        public ActionResult Index(string id)
        {
            //商品详情页
            //string Proid = Request["myID"];
            var ProductResult = ProductService.GetEntity(x => x.PCode == id);
            var ProductResultM = ProductService.GetEntities(x => x.PCode == id);
            ViewBag.ProductItem = ProductResultM.ToList();
            Session["Product"]= ProductResultM.ToList();
            return View(ProductResult);
        }
        public ActionResult AddProduct()
        {
            //添加购物车
            var ProductID = Request["ProID"]; //商品id
            var ProductNum = Request["Pnum"]; //商品数量
            var ProductEnum = ShopCartService.GetEntities(x => true);
            var MyProduct = ProductEnum.FirstOrDefault(x => true);
            MyProduct.SPcode = ProductID;
            MyProduct.SNum = ProductNum;
            ShopCartService.Add(MyProduct);
        
            return RedirectToAction("Index");
        }
      
    }
}