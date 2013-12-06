using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OctoFX.SmokeTests
{
    [TestFixture]
    public class SmokeTestFixture
    {
        [Test]
        public void EnsureWebSiteIsRunning()
        {
            var responseText = new WebClient().DownloadString(ConfigurationManager.AppSettings["endpoint"]);

            Assert.That(responseText, Is.StringContaining("OctoFX makes it easy to buy and sell"));
        }
    }
}
