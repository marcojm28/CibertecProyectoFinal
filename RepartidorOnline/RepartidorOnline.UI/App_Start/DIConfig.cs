using RepartidorOnline.Application.Interfaces.Repositories;
using RepartidorOnline.Application.Interfaces.UseCases;
using RepartidorOnline.Application.UseCases;
using RepartidorOnline.Infraestructure.Repositories;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI.App_Start
{
    public class DIConfig
    {
        public static void Configure() 
        {
            // Simple Injector set up
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IUsuarioUseCase, UsuarioUseCase>(Lifestyle.Scoped);
            container.Register<ITiendaRepository, TiendaRepository>(Lifestyle.Scoped);
            container.Register<ITiendaUseCase, TiendaUseCase>(Lifestyle.Scoped);
            container.Register<IProductoRepository, ProductoRepository>(Lifestyle.Scoped);
            container.Register<IProductoUseCase, ProductoUseCase>(Lifestyle.Scoped);
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}