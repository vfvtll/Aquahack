using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aquahach.EFDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aquahach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                AquahackContext result = new AquahackContext();
                var data = result.Blogs.Include("PhotoOb").Take(10);
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

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                AquahackContext result = new AquahackContext();
                var data = result.Blogs.Where(c => c.Id == id).Include("PhotoOb");
                var comments = result.Comments.Where(c => c.BlogId == id).Take(10);
                var response = new
                {
                    data = data.ToList(),
                    comments = comments.ToList()
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
        public void Post([FromBody] Blog data)
        {
            AquahackContext db = new AquahackContext();
            db.Blogs.Add(data);
            db.SaveChanges();
        }
        [HttpPatch]
        public void Patch(Blog data)
        {

            AquahackContext db = new AquahackContext();
            Blog dataAttach = new Blog { Id = data.Id };
            db.Blogs.Attach(dataAttach); /// track your stub model
            db.Entry(dataAttach).CurrentValues.SetValues(data); /// reflection

            db.SaveChanges();
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AquahackContext db = new AquahackContext();
            var data = db.Blogs.Where(o => o.Id == id).First();
            db.Blogs.Remove(data);
        }
    }
}