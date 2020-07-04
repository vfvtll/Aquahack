using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aquahach.EFDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aquahach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET api/values
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                AquahackContext result = new AquahackContext();
                var data = result.Users.Where(c=>c.Id==id);
                var response = new
                {
                    data = data.ToList()
                };
                return Ok(response);
            }
            catch (Exception e)
            {
                var response = new
                {
                    error = e.StackTrace
                };
                return StatusCode(512, response);
            }
        }
        

        // POST api/values
        [HttpPost]
        public void Post([FromBody] User data)
        {
            AquahackContext db = new AquahackContext();
            db.Users.Add(data);
            db.SaveChanges();
        }


        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AquahackContext db =new AquahackContext();
            var data = db.Users.Where(o => o.Id == id).First();
            db.Users.Remove(data);
        }
    }
}