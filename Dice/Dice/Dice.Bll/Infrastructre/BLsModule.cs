using Dice.DAL.Interfaces;
using Dice.DAL.Repositories;
using Ninject.Modules;
using Ninject.Web.Common;

namespace Dice.Bll.Infrastructre
{
    public class BLsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}
