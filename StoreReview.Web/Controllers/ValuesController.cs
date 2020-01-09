using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreReview.Core.Domain;
using StoreReview.Core.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StoreReview.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IRepository<Shop> _repository;

        public ValuesController(IRepository<Shop> repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public Shop[] Get()
        {
            var shops = _repository.GetAll().ToArray();
            //return new string[] { "value1", "value2" };
            return shops;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody]string value)
        {
            return "dsadsadsadsadsa";
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
