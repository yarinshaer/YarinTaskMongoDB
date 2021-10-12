using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using yarins_task;

namespace yarins_task.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class JobController : ControllerBase
    {
        private IConfiguration config;
        private readonly IMongoCollection<JobIntreview> _jobInterView;
     
        public JobController(IConfiguration _config)
        {
            config = _config;

            string dbName = config.GetValue<string>("DbSetting:_dbName");
            string collectionName = config.GetValue<string>("DbSetting:_collectionName");
            string connectionString = config.GetValue<string>("DbSetting:_mongoDbURL");

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(dbName);
            _jobInterView=database.GetCollection<JobIntreview>(collectionName);

        }
        [HttpGet]
        public JobIntreview Get(string id)
        {   
            return _jobInterView.Find<JobIntreview>(x =>x._id==id).FirstOrDefault();
        }

        [HttpPut]
        public JobIntreview Put(string _id, string _t, string _v)
        {
            try
            {
                var result = _jobInterView.Find<JobIntreview>(x => x._id == _id).FirstOrDefault();
                result._vTakeMe = _v;
                result._tJobInterview = _t;
                _jobInterView.ReplaceOne(x => x._id == _id, result);
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
          

        }
    }
}
