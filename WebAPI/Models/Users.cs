using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class Users
    {

        //[BsonRepresentation(BsonType.ObjectId)]
        //public string Id { get; set; }

        //[BsonElement("UserName")]
        [BsonId]
        public string _id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
