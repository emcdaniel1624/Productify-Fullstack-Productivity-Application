using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using NoSqlProvider.Entity;
using NoSqlProvider.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productify.API.Models
{
    public class Project : Document
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ProjectName { get; set; } = null!;
    }
}
