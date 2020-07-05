using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Aquahach.EFDB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aquahach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult Get([FromBody]CalculatorItem data)
        {

            try
            {
                string url = "https://waterfootprint.org/calculator-extended";
                using (var webClient = new WebClient())
                {
                    var pars = new NameValueCollection();
                    pars.Add("Country_ID", data.Country_ID.ToString());
                    pars.Add("cereal", data.cereal.ToString());
                    pars.Add("meat", data.meat.ToString());
                    pars.Add("income", data.income.ToString());
                    pars.Add("bathnumber", data.bathnumber.ToString());
                    pars.Add("carweek", data.carweek.ToString());
                    pars.Add("coffee", data.coffee.ToString());
                    pars.Add("diary", data.diary.ToString());
                    pars.Add("dishminute", data.dishminute.ToString());
                    pars.Add("dishnumber", data.dishnumber.ToString());
                    pars.Add("dishweek", data.dishweek.ToString());
                    pars.Add("egg", data.egg.ToString());
                    pars.Add("fat", data.fat.ToString());
                    pars.Add("fruit", data.fruit.ToString());
                    pars.Add("gardenminute", data.gardenminute.ToString());
                    pars.Add("gardenweek", data.gardenweek.ToString());
                    pars.Add("laundryload", data.laundryload.ToString());
                    pars.Add("poolcapacity", data.poolcapacity.ToString());
                    pars.Add("poolnumber", data.poolnumber.ToString());
                    pars.Add("rinsingminute", data.rinsingminute.ToString());
                    pars.Add("root", data.root.ToString());
                    pars.Add("showerminute", data.showerminute.ToString());
                    pars.Add("showernumber", data.showernumber.ToString());
                    pars.Add("sugar", data.sugar.ToString());
                    pars.Add("tap1", data.tap1.ToString());
                    pars.Add("tea", data.tea.ToString());
                    pars.Add("vegetable", data.vegetable.ToString());
                    var response = webClient.UploadValues(url, pars);
                    string str = Encoding.UTF8.GetString(response);
                    var startIndex = str.IndexOf("InstanceBeginEditable");
                    str = str.Substring(startIndex);
                    startIndex = str.IndexOf("<br>");
                    for (int i = 0; i < 4; i++)
                    {
                        str = str.Substring(startIndex + 4);
                        startIndex = str.IndexOf("<br>");
                    }

                    startIndex = str.IndexOf("</font>");
                    str = str.Substring(0, startIndex);
                    var answer = new
                    {
                        total = str
                    };
                    return Ok(answer);
                }

            }
            catch (Exception e)
            {
                return StatusCode(512);
            }
        }
    }
}