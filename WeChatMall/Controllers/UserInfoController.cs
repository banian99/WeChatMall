using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeChatMall.Filters;

namespace WeChatMall.Controllers
{
    [OAuth]
    public class UserInfoController : Controller
    {
        // GET: UserInfo
        public ActionResult Index()
        {
            var userInfo = Session["userInfo"];
            //return View(userInfo);
            return View();
        }
    }
}