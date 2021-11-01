using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SharedLib.Users;

namespace Server.Test
{
    [TestFixture]
    public class HubConnectionTest
    {
        [Test]
        public void TestConnectionWithServer()
        {
            Assert.Pass();
        }
    }
}
