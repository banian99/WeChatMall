using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace WeChatMall.Filters
{
    public class OAuthAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //1.应该使用哪个值，来判断用户是否可以直接进入
            if (filterContext.HttpContext.Session["oauthAccessToken"] == null)
            {
                //如果不满足条件，跳转到授权页面，注意：一定要带有一个参数表示 returnUrl
                //1.获取用户当前需要访问的页面Url
                string returnurl = filterContext.HttpContext.Request.RawUrl;

                //2.带参数地址进入授权页面
                UrlHelper url = new UrlHelper(filterContext.RequestContext);
                filterContext.Result = new RedirectResult(url.Action("Index", "OAuth", new { returnurl }));
            }
        }
    }
}