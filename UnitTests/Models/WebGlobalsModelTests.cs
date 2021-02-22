using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class WebGlobalsModelTests
    {
        [Test]
        public void WebGlobalsModel_Default_Should_Pass()
        {
            // Arrange

            // Act

            // Reset

            // Assert
            Assert.AreEqual("https://itemgetpost.azurewebsites.net/API/", WebGlobalsModel.WebSiteAPIURL);
        }
    }
}
