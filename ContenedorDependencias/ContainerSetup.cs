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
        private ContainerBuilder _builder;
        public IContainer BuildContainer()
        {
            _builder = new ContainerBuilder();
            _builder.RegisterType<Repository>().As<IRepository>();
            _builder.RegisterType<Service>().As<IService>();
            _builder.RegisterType<Controller>().As<IController>();
            return _builder.Build();
        }
    }
}
