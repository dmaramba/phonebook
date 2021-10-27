using Autofac;
using PhoneBookManager.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookManager.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PhoneBookService>()
               .As<IPhoneBookService>()
               .InstancePerLifetimeScope();

        }

    }
}
