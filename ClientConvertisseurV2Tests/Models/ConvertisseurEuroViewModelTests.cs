using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientConvertisseurV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientConvertisseurV2.ViewModels;

namespace ClientConvertisseurV2.Models.Tests
{
    [TestClass()]
    public class ConvertisseurEuroViewModelTests
    {
        [TestMethod()]
        public void GetDevisesAsyncTest()
        {
            {
                //Arrange
                WSService service = new WSService("http://localhost:5235/api/");
                //Act
                List<Devise> result = service.GetDevisesAsync("devises").Result;
                //Assert
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(result, typeof(List<Devise>));
                Assert.AreEqual(3, result.Count());
            }
        }

        [TestMethod()]
        public void WSServiceTest()
        {
            //Arrange
            WSService service = new WSService("http://localhost:5235/api/");
            //Act

            //Asert
            Assert.IsNotNull(service);
        }
    }
}