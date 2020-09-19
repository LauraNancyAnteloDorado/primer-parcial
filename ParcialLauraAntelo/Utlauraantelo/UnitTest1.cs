using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParcialLauraAntelo.Controllers;

namespace Utlauraantelo
{
    [TestClass]
    public class UnitTestAnteloD
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            AnteloDsController controller = new AnteloDsController();

            //Act
            var ResultadoG = controller.GetAnteloDs();

            //Assert
            Assert.IsNotNull(ResultadoG);
        }
    }
}
