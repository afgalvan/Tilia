using BoDi;
using TechTalk.SpecFlow;
using Tilia.Integration.Test.Mocks;

namespace Tilia.Integration.Test.Hooks
{
    [Binding]
    public sealed class ApplicationHooks
    {
        private static TestDbContext _context;

        [BeforeScenario(Order = 1)]
        public static void BeforeScenario(IObjectContainer container)
        {
            _context = new TestDbContext();
            container.RegisterInstanceAs(_context);
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            _context.Database.EnsureDeleted();
        }
    }
}

