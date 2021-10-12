using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Net;
using System.Net.Http;

namespace yarins_task
{
    public class JobIntreview
    {
        
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string _id { get; set; }
            public string _tJobInterview { get; set; }
            public string _vTakeMe { get; set; }
        
    }
}
