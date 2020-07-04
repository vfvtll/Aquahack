using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aquahach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                AquahackContext result = new AquahackContext();
                var data = result.Plants.Where(c => c.Id == id).Include("PhotoOb");
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

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                AquahackContext result = new AquahackContext();
                var data = result.Plants.Include("PhotoOb").Take(10);
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
    }
}