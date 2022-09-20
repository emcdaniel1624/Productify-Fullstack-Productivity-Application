using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Productify.DAL.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productify.API.Models
{
    public class Task : INoSqlEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string TaskName { get; set; } = null!;
    }
}
