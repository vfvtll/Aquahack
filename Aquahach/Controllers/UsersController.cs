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
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                AquahackContext result = new AquahackContext();
                var data = result.Users.Where(c => c.Id == id);
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

        
        [HttpPost]
        public void Post([FromBody] User data)
        {
            AquahackContext db = new AquahackContext();
            db.Users.Add(data);
            db.SaveChanges();
        }
        [HttpPatch]
        public void Patch(User data)
        {

            AquahackContext db = new AquahackContext();
            User dataAttach = new User { Id = data.Id };
            db.Users.Attach(dataAttach); /// track your stub model
            db.Entry(dataAttach).CurrentValues.SetValues(data); /// reflection

            db.SaveChanges();
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AquahackContext db = new AquahackContext();
            var data = db.Users.Where(o => o.Id == id).First();
            db.Users.Remove(data);
        }
    }
}