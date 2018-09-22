using System;
using System.IO;
using Beyova.CodingBot.SqlServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Beyova.CodingBot.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class SolutionCodingBotUnitTest
    {
        /// <summary>
        /// Automatics the unit test.
        /// </summary>
        [TestMethod]
        public void AutoUnitTest()
        {
            ServiceSolutionCodingBotOptions options = new ServiceSolutionCodingBotOptions
            {
                UseLowerCamelNamingForJsonSeriliazation = true,
                SolutionName = "BeyovaCodingBotExample",
                NameSpace = "Beyova.CodingBot.Example"
            };

            var package = ServiceSolutionCodingBot.Generate(options);
            package.GenerateSqlPublishScript();

            var storageContainer = new FileContainer(Path.Combine(EnvironmentCore.ApplicationBaseDirectory, "Output"));
            package.PutIntoStorageContainer(storageContainer);

            storageContainer.WriteToDestination();
        }
    }
}
