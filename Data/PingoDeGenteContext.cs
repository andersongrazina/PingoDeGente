using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PingoDeGenteAppApi.Model;

namespace PingoDeGenteAppApi.Data
{
    public class PingoDeGenteContext
    {
        private readonly IMongoDatabase _database = null;

        public PingoDeGenteContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<Student> Students
        {
            get
            {
                return _database.GetCollection<Student>("Student");
            }
        }
        public IMongoCollection<Class> Classes
        {
            get
            {
                return _database.GetCollection<Class>("Class");
            }
        }
    }
}
