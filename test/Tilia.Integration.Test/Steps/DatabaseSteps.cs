using System.Threading.Tasks;
using Domain.Users;
using Newtonsoft.Json;
using TechTalk.SpecFlow;
using Tilia.Integration.Test.Mocks;

namespace Tilia.Integration.Test.Steps
{
    [Binding]
    public class DatabaseSteps
    {
        private readonly TestDbContext _databaseContext;

        public DatabaseSteps(TestDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [Given(@"an empty database")]
        public void GivenAnEmptyDatabase()
        {
            _databaseContext.Database.EnsureDeleted();
            _databaseContext.Database.EnsureCreated();
        }

        [Given(@"the following user already exists:")]
        public async Task GivenTheFollowingUserAlreadyExists(string userSchema)
        {
            var user = JsonConvert.DeserializeObject<User>(userSchema);
            await _databaseContext.Users.AddAsync(user);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
