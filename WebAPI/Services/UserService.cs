using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace WebAPI.Services
{
    public class UserService
    {
        private readonly IMongoCollection<Users> _users;

        public UserService(IECommerceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<Users>(settings.UsersCollectionName);

        }

        public List<Users> Get() =>
            _users.Find(user => true).Toist();

        public Users Get(string _id) {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "ADMIN");
           return _users.Find(BsonSerializer.Deserialize<Users>(filter)).FirstOrDefault();
     }

        public Users Create(Users user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string _id, Users userIn) =>
            _users.ReplaceOne(user => user._id == _id, userIn);

        public void Remove(Users userIn) =>
            _users.DeleteOne(user => user._id == userIn._id);

        public void Remove(string _id) =>
            _users.DeleteOne(user => user._id == _id);
    }
}
