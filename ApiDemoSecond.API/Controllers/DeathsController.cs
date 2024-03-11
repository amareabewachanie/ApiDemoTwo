using ApiDemoSecond.API.Models;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoSecond.API.Controllers
{
    [ApiController]
    [Route("deaths")]
    public class DeathsController:ControllerBase
    {
        private readonly OcraContext _context = default;
        public DeathsController(OcraContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult List()
        {
            return Ok(_context.Deaths.ToList());
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_context.Deaths.FirstOrDefault(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult Add([FromBody] DeathDto death) {
            _context.Deaths.Add(new Death
            {
                FirstName = death.FirstName,
                LastName = death.LastName,
                MiddleName = death.MiddleName,
                DateOfDeath = death.DateOfDeath,
            });
            _context.SaveChanges();
            return CreatedAtAction("List", death);
        }
        [HttpPatch("{id}")]
        public ActionResult Patch([FromBody]JsonPatchDocument<Death> death, int id)
        {
            var deathToBePached = _context.Deaths.FirstOrDefault(x => x.Id == id);
           
            death.ApplyTo(deathToBePached);
            _context.Update(deathToBePached);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] DeathDto death,int id)
        {
            var deathToBeUpdated=_context.Deaths.FirstOrDefault(a=>a.Id==id);
            deathToBeUpdated.FirstName = death.FirstName;
            deathToBeUpdated.DateOfDeath = death.DateOfDeath;
            deathToBeUpdated.MiddleName = death.MiddleName;
            deathToBeUpdated.LastName = death.LastName;
            _context.Update(deathToBeUpdated);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var death = _context.Deaths.FirstOrDefault(a=>a.Id == id);
            _context.Deaths.Remove(death);
            _context.SaveChanges();
            return Ok();
        }
    }
}
