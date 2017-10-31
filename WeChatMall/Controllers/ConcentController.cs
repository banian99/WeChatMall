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
           
            return View(ProductResult);
        }
        public ActionResult AddProduct()
        {
            //添加购物车
            var ProductID = Request["ProID"]; //商品id
            int ProductNum = int.Parse(Request["Pnum"]); //商品数量
            //先查询购物车
            var    ProductEnum = ShopCartService.GetEntities(x => x.SPcode==ProductID);
            //然后查询购物车属性
           
            var ProductResult = ProductEnum.FirstOrDefault(x => true);
            
            //调用属性
            if (ProductEnum.Count() > 0)
            {

                ProductResult.SPcode = ProductID;
                ProductResult.SNum = ProductResult.SNum + ProductNum;
                ShopCartService.Modify(ProductResult);
                return RedirectToAction("Index");
            }
            else
            {
                ShopCart sc = new ShopCart()
                {
                    SPcode = ProductID,
                    SNum = ProductNum,
                    //SCid=Session["userInfo"]
                };
                //ProductResult.SPcode = ProductID;
                //ProductResult.SNum = ProductNum;
                ShopCartService.Add(sc);
                return RedirectToAction("Index");
            }



        }

    }
}