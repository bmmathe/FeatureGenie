using System;
using NUnit.Framework;
using FeatureGenieService.ServiceInterface;
using FeatureGenieService.ServiceModel;
using ServiceStack.Testing;
using ServiceStack;

namespace FeatureGenieService.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(FeatureService).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<FeatureService>();

            var response = service.Any(new Features { ApplicationName = "Application1" });

            Assert.That(response, Is.EqualTo(""));
        }
    }
}
