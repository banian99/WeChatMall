using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.IService;
using Shop.Model;
namespace WeChatMall.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public IBannerService BannerService { get; set; }  //Banner表
        public INoticeService NoticeService { get; set; }  //Notice 公告表
        public IProductService ProductService { get; set; } //Product 商品信息表

        public ActionResult Index()
        {
            //获取Banner中的数据 
            var BannerResult = BannerService.GetEntities(x => true);
            ViewBag.Banner = BannerResult.ToList();
            //获取滚动Notice中的数据
            var NoticeResult = NoticeService.GetEntities(y => true);         
            ViewBag.Notice = NoticeResult.ToList();
            //获取热销商品Product中的数据
            var ProductResult = ProductService.GetEntities(w => true).Take(3);
            ViewData["Product"] = ProductResult.ToList();
            //获取最新商品Product中的数据    
            var NewProduct = ProductService.GetEntities(k => true).OrderByDescending(x=>x.PTime).Take(3);
            ViewBag.NewTimeinfo = NewProduct.ToList();

            return View();
        }
       
        public ActionResult Search()
        {
            return PartialView();
        }
      
    }
}