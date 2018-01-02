using MVCWebNorthWind.Models;
using MVCWebNorthWind.Respositories;
using MVCWebNorthWind.Respositories.Interface;
using MVCWebNorthWind.Services;
using MVCWebNorthWind.Services.Interface;
using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Configuration;
using Unity;
using Unity.AspNet.Mvc;
using Unity.Injection;
using Unity.Lifetime;

namespace MVCWebNorthWind
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //unitOfwork
            UnitOfWorkRegister(container);
            //repository layer
            RepositoryRegister(container);
            //service layer
            ServiceRegister(container);
        }

        private static void UnitOfWorkRegister(IUnityContainer container)
        {

            var entity = new NorthwindEntities();
            container.RegisterType<IUnitOfWork, UnitOfWork>(
                new InjectionConstructor(entity));
        }

        private static void ServiceRegister(IUnityContainer container)
        {
            container.RegisterType<ICustomerService, CustomerService>();
        }

        private static void RepositoryRegister(IUnityContainer container)
        {
            container.RegisterType<IGenerRespository<Customers>, 
                GenerRespository<Customers>>(new PerRequestLifetimeManager());
         
        }



    }
}