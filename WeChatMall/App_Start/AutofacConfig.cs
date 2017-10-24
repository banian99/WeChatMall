using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace WeChatMall.App_Start
{
    public class AutofacConfig
    {
        //实例化一个builder
        //反射using system.Reflection
        public static void RegisterDependency()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //使用高层次，以属性的方式实现
            //如果注册使用方式不加.PropertiesAutowired() 表示依赖注入的方式默认是构造函数，如果加上
            //表示使用属性实现  Properties 属性
            var iRepository = Assembly.Load("Shop.IRepository");//IDAL
            var iService = Assembly.Load("Shop.IService");//IBLL

            var repository = Assembly.Load("Shop.Repository");//DAL
            var service = Assembly.Load("Shop.Service");//BLL

            //注册程序集类型，就是实现方，低层次的  以接口
            //程序集的名称必须是以Repository结尾
            builder.RegisterAssemblyTypes(iRepository, repository).Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces();
            //Service结尾
            builder.RegisterAssemblyTypes(iService, service).Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();

            //实例化一个容器
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //以autofac的注入替换原有的实现方式

        }
    }
}