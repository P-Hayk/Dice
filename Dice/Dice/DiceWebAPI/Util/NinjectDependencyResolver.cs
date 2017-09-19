using Dice.Bll.BLs;
using Dice.Bll.Interfaces;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiceWebAPI.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IPlayerBll>().To<PlayerBll>().InRequestScope();
            kernel.Bind<IPlayerSessionBll>().To<PlayerSessionBll>().InRequestScope();
            kernel.Bind<IGameBll>().To<GameBll>().InRequestScope();
            kernel.Bind<IStepBll>().To<StepBll>().InRequestScope();
        }
    }
}