using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Library.Common;
using Library.Model.Common;
using Library.Model;
using Library.Repository;
using Library.Repository.Common;
using Library.Service;
using Library.Service.Common;


namespace Library.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //dependecies

            //models
            builder.RegisterType<Author>().As<IAuthorCommon>().InstancePerRequest();
            builder.RegisterType<Book>().As<IBookCommon>().InstancePerRequest();


            //repositories
            builder.RegisterType<AuthorRepository>().As<IAuthorRepositoryCommon>().InstancePerRequest();
            builder.RegisterType<BookRepository>().As<IBookRepositoryCommon>().InstancePerRequest();


            //services
            builder.RegisterType<AuthorService>().As<IAuthorServiceCommon>().InstancePerRequest();
            builder.RegisterType<BookService>().As<IBookServiceCommon>().InstancePerRequest();

            //common
            //builder.RegisterType<Pager>().As<IPager>().InstancePerRequest();
            //builder.RegisterType<FilterData>().As<IFiltering>().InstancePerRequest();
            //builder.RegisterType<Sorting>().As<ISorting>().InstancePerRequest();

            //mapperS
            builder.RegisterType<Mapper>().As<IMapper>().InstancePerRequest();

            builder.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




            var container = builder.Build();



            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        




        AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
