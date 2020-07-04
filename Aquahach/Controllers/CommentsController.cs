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
    public class CommentsController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] Comment data)
        {
            AquahackContext db = new AquahackContext();
            db.Comments.Add(data);
            db.SaveChanges();
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AquahackContext db = new AquahackContext();
            var data = db.Comments.Where(o => o.Id == id).First();
            db.Comments.Remove(data);
        }
    }
}