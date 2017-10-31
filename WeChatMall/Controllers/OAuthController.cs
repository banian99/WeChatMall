using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using Senparc.Weixin.MP.Helpers;
using System.Configuration;

namespace WeChatMall.Controllers
{
    public class OAuthController : Controller
    {
        // GET: OAuth
        //1.方法中需要appid，appsecret
        public static readonly string appID = ConfigurationManager.AppSettings["appID"];
        public static readonly string appsecret = ConfigurationManager.AppSettings["appsecret"];
        public static readonly string Domin = "http://wx.lingnian.xin";
        public ActionResult Index(string returnUrl)
        {
            //微信中需要使用的地址都是外网地址  域名/returnUrl
            //1.构造带有域名的回调Url 地址需要在函数中带有 $表示变量的占位符
            var redirect_uri = $"http://wx.lingnian.xin{Url.Action("CallBack", new { returnUrl })}";
            //state可以由开发者自己定义，作用就相当于一个验证码
            string state = "wx" + DateTime.Now.Millisecond;
            //把拼接好的state保存下来
            Session["state"] = state;//一旦验证比较以后，需要对session中的state session["state"]=null;
            string redirect = OAuthApi.GetAuthorizeUrl(appID, redirect_uri, state, Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
            //注意 该处的授权验证地址  是内置好的， 只需要跳转请求即可

            return Redirect(redirect); //到用户可以点击"授权登录"；
        }

        //写回调函数  相当于用户点击同意授权之后，返回的一个授权凭证，还有状态码，以及最初请求的第三方url

        public ActionResult CallBack(string code, string state, string returnUrl)
        {
            //1.比较state 是否相同，相当于验证码的比较
            if (Session["state"]?.ToString() != state)
            {
                Session["state"] = null;
                return Content("验证失败");
            }
            Session["state"] = null;

            //判断凭证code
            if (string.IsNullOrEmpty(code))
            {
                //返回授权页面 获取给出提示
                return Content("您拒绝授权");
            }
            //如果code 存在 则需要拿code换 accessToken 返回的是一个对象  包含有accesstoken
            var oauthAccessToken = OAuthApi.GetAccessToken(appID, appsecret, code);
            if (oauthAccessToken.errcode != Senparc.Weixin.ReturnCode.请求成功)
            {
                return Content($"错误消息：{oauthAccessToken.errmsg}");
            }
            Session["oauthAccessToken"] = oauthAccessToken;//保存起来 供过滤器判断
            try
            {
                OAuthUserInfo userInfo = OAuthApi.GetUserInfo(oauthAccessToken.access_token, oauthAccessToken.openid);
                Session["userInfo"] = userInfo;
                return Redirect(returnUrl);
            }
            catch
            {
                var redirect_uri = $"http://wx.lingnian.xin{Url.Action("CallBack", new { returnUrl })}";
                //state可以由开发者自己定义，作用就相当于一个验证码
                string statee = "wx" + DateTime.Now.Millisecond;
                //把拼接好的state保存下来
                Session["state"] = statee;//一旦验证比较以后，需要对session中的state session["state"]=null;
                string redirect = OAuthApi.GetAuthorizeUrl(appID, returnUrl, state, Senparc.Weixin.MP.OAuthScope.snsapi_userinfo);
                //注意 该处的授权验证地址  是内置好的， 只需要跳转请求即可

                return Redirect(redirect);
            }

        }
        //配置 js-sdk
        public ActionResult JsSdkConfig()
        {
            string url = $"http://wx.lingnian.xin{Request.RawUrl}";
            //方法中的参数就是每一个需要使用接口的页面地址
            JsSdkUiPackage jssdkpackge = JSSDKHelper.GetJsSdkUiPackage(appID, appsecret, url);
            return PartialView(jssdkpackge);
        }
    }
}