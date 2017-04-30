using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Unity.WebAPI.Models;

namespace Unity.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Rank> Get()
        {
            Rank context = HttpContext.RequestServices.GetService(typeof(Rank)) as Rank;
            return context.All();
        }

        // GET api/values/5
        [HttpGet("{nickname}")]
        public Rank Get(string nickname)
        {
            Rank context = HttpContext.RequestServices.GetService(typeof(Rank)) as Rank;
            return context.Search(nickname);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{nickname}")]
        public void Put(string nickname, [FromBody]UserScore value)
        {
            Rank context = HttpContext.RequestServices.GetService(typeof(Rank)) as Rank;
            context.Insert(nickname, value.Score);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
