using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsDataInsertionJob.Model
{
    public class ProjectData
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("OrganizationURL")]
        public string OrganizationURL { get; set; } = null!;
        [BsonElement("PersonalToken")]
        public string PersonalToken { get; set; } = null!;
    }
}
