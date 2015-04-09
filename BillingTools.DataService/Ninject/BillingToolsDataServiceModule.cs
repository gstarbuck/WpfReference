using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingTools.DataService.Ninject
{
    public class BillingToolsDataServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBillingToolsDataService>().To<BillingToolsDataService>();
        }
    }
}
