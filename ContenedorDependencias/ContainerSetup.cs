using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;
using Services;
using Repositories;

namespace ContenedorDependencias
{
    public class ContainerSetup
    {
        public static ContainerSetup instance;
        private ContainerBuilder _builder;

        private ContainerSetup() {}

        public void init()
        {
            instance = new ContainerSetup();
        }

        public IContainer BuildContainer()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterType<Repository>().As<IRepository>().SingleInstance();
            _builder.RegisterType<Service>().As<IService>().InstancePerDependency();
            _builder.RegisterType<Controller>().As<IController>().InstancePerLifetimeScope();
            return _builder.Build();
        }
    }
}
