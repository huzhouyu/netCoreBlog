using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bokeSite.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bokeSite.Controllers
{
    [Route("[controller]")]
    public class ApiController : Controller
    {
        // GET: api/<controller>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="teset"></param>
        /// <param name="nicheng"></param>
        /// <returns></returns>
        [HttpGet("CMDID")]
        public userinfo Get(string teset,string nicheng="来自未来")
        {
           
            return new userinfo() { username=teset,nicheng=nicheng};
        }



        // public IAsyncResult
        //GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id, string str)
        {
            //Ok()
            return id + "=" + str;
        }




        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        /// <summary>
        /// 来自test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
