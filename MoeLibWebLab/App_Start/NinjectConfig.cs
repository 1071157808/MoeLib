using System;
using System.Web;
using System.Web.Http;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using MoeLibWebLab;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.WebApi;
using WebActivatorEx;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectConfig), "Start")]
[assembly: ApplicationShutdownMethod(typeof(NinjectConfig), "Stop")]

namespace MoeLibWebLab
{
    /// <summary>
    ///     Ninject Configuration
    /// </summary>
    public static class NinjectConfig
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();
        private static readonly StandardKernel Kernel = new StandardKernel();

        /// <summary>
        ///     RegisterDependencyResolver to HttpConfiguration
        /// </summary>
        /// <param name="config">HttpConfiguration</param>
        public static void RegisterDependencyResolver(HttpConfiguration config) => config.DependencyResolver = new NinjectDependencyResolver(Kernel);

        /// <summary>
        ///     Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        ///     Stops the application.
        /// </summary>
        public static void Stop() => Bootstrapper.ShutDown();

        /// <summary>
        ///     Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            Kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            Kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices();
            return Kernel;
        }

        /// <summary>
        ///     Registers the services.
        /// </summary>
        private static void RegisterServices()
        {
            // This is where we tell Ninject how to resolve service requests
        }
    }
}