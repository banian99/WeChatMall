using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Model;
using Shop.IRepository;
using Shop.IService;

namespace WeChatMall.Controllers
{
    public class NoticeController : Controller
    {
        // GET: Notice  公告控制器
        public INoticeService NoticeService { get; set; }
        public ActionResult Index()
        {
            var NoticeResult = NoticeService.GetEntities(x => true);
            ViewBag.Notice = NoticeResult.ToList();
            return View();
        }
        //公告详情
        public ActionResult IndexInfo(int id)
        {
            
            var NoticeContext = NoticeService.GetEntities(x => x.Nid == id);
            ViewBag.NoticeText = NoticeContext.ToList();
            return View();
        }
       
    }
}