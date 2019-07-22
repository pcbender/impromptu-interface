using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImpromptuInterface;
using ImpromptuInterface.Build;


namespace UnitTestImpromptuInterface
{
#if !SILVERLIGHT && !SELFRUNNER && !NETSTANDARD2_1

    using NUnit.Framework;
    [SetUpFixture]
    public class FixtureSetup
    {
        private IDisposable Builder;
        
        [OneTimeSetUp]
        public void Setup()
        {
            Builder = BuildProxy.WriteOutDll("ImpromptuEmit");
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            Builder.Dispose();
        }
    }
#endif
}
