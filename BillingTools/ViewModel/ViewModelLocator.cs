/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Rair.BillingTools"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using BillingTools.DataService.Ninject;
using GalaSoft.MvvmLight;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;
using Ninject.Modules;
using System.Collections;
using System.Collections.Generic;

namespace Rair.BillingTools.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {

        private static readonly IKernel _kernel;
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        static ViewModelLocator()
        {
            _kernel = new StandardKernel(GetKernelModules(ViewModelBase.IsInDesignModeStatic).ToArray());
        }

        private static IEnumerable<INinjectModule> GetKernelModules(bool isDesignTime)
        {
            if (isDesignTime)
            {
                //TODO: implement memory data service module to enable designer and unit testing
                yield return new BillingToolsDataServiceModule();
            }
            else
            {
                yield return new BillingToolsDataServiceModule();
            }
        }

        public MainViewModel Main { get { return _kernel.Get<MainViewModel>(); } }

        public StatisticalReportsViewModel StatisticalReports { get { return _kernel.Get<StatisticalReportsViewModel>(); } }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}