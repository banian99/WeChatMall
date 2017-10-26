using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IService;
namespace WeChatMall.Controllers
{
    public class ProductSortController : Controller
    {
        // GET: ProductSort  产品分类
        public IProductSortService ProductSortService { get; set; }  //产品类别表
        
        public ActionResult Index()
        {
            //一级菜单栏
            string proud = 0.ToString();
            var ProductSortResult = ProductSortService.GetEntities(m => m.ProSorID == proud);
            ViewBag.ProductSort = ProductSortResult.ToList();
            Session["Pro_sorId"] = ProductSortResult.ToList();
            return View();
        }
        //二级菜单栏
        string id = null;
        public ActionResult Fleat()
        {

              id = Request["mydata"]; 
            if (id == null)
            {

                IEnumerable<ProductSort> pro = Session["Pro_sorId"] as IEnumerable<ProductSort>;
                ProductSort Pro_first = pro.FirstOrDefault(x => true);
                id = Pro_first.ProID;
            }
            var ProductSortNum = ProductSortService.GetEntities(k => k.ProSorID == id);
            ViewBag.ProductSortText = ProductSortNum.ToList();
            return PartialView();
        }
        public ActionResult ProSearch()
        {
            //搜索栏
            return PartialView();
        }
       
    }
}