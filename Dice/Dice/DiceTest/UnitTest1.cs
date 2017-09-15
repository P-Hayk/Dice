using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;

using Dice.DAL.Interfaces;
using Dice.Bll.Interfaces;
using System.Web.Mvc;
using Dice.Bll.BLs;
using Ninject.Modules;
using DiceTest.Util;

namespace DiceTest
{
    [TestClass]
    public class UnitTest1
    {

        IKernel kernel;
        [TestMethod]
        public void TestMethod1()
        {



            kernel = new StandardKernel(new MyClass());
            System.Web.Mvc.DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));


            var playerBll = DependencyResolver.Current.GetService<IPlayerBll>();
            playerBll.LoginPlayer(null);
        }



    }

    class MyClass : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<MockUnitOfWork>();
          

        }
    }


}
