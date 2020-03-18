using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pensjonat.Data;
using Pensjonat.UI.ViewModel;
using System.Linq;

namespace Pensjonat.UI.Test
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void TestOdswiezShowedList()
        {

            var vm = new MaintenanceFormViewModel(true);


            vm.Init();

            Assert.IsTrue(vm.ShowedList.Count() > 0);
        }

        [TestMethod]
        public void Testlist()
        {
            var vm = new MaintenanceFormViewModel(true);

            vm.Init();
            Assert.IsTrue(vm.lista.Count() > 0);
        }
    }

}


