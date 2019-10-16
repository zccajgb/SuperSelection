using DomainModel.Documents.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cmd = new CreateSelectivityAndActivityCalculationCommand { Name = "name" };
            var json = JsonConvert.SerializeObject(cmd);
        }
    }
}
