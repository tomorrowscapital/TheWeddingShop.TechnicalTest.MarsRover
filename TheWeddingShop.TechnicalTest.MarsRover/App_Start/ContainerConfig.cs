using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using SimpleInjector;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;
using TheWeddingShop.TechnicalTest.MarsRover.CommandExcuters;

namespace TheWeddingShop.TechnicalTest.MarsRover.App_Start
{
    /// <summary>
    /// Explanation:
    /// Use SimpleInjector of seting up the container of dependency injection. Using dynamic approach of reflection.
    /// </summary>
    public static class ContainerConfig
    {
        private static Container Container;
        public static void Init()
        {
            Container = new Container();

            RegisterAllTypesWithConvention();

            Container.Verify();
        }

        public static TService GetInstance<TService>() where TService : class
        {
            return Container.GetInstance<TService>();
        }

        private static void RegisterAllTypesWithConvention()
        {
            var typesWithInterfaces = typeof(Program).Assembly.GetExportedTypes()
                .Where(t => t.Namespace.StartsWith("TheWeddingShop"))
                .Where(ts => ts.GetInterfaces().Any() && ts.IsClass).ToList();
            var registrations = typesWithInterfaces
                .Where(t => t.GetInterfaces().Length == 1)
                .Select(ti => new { Service = ti.GetInterfaces().Single(), Implementation = ti })
                .Where(r => r.Service.Name == "I" + r.Implementation.Name &&
                 r.Implementation.IsAbstract==false);

            foreach (var reg in registrations)
            {
                Container.Register(reg.Service, reg.Implementation, Lifestyle.Singleton);
            }
            Container.Register<IArea, Plateau>(Lifestyle.Singleton);

            Container.Collection.Register<ICommandExecuter>(
                            typeof(PlataueCommandExecuter),
                            typeof(RoverMoveCommandExecuter),
                            typeof(RoverRotateCommandExecuter));
        }


    }
}
