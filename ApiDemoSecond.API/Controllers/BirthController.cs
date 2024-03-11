using ApiDemoSecond.API.Models;
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoSecond.API.Controllers
{
    [ApiController]
    [Route("births")]
    public class BirthController : ControllerBase
    {
        private readonly IBirthRepository _repository;
        private readonly ILoggerManager _loggerManager;

        public BirthController(IBirthRepository repository, ILoggerManager loggerManager)
        {
            _repository = repository;
            _loggerManager = loggerManager;
        }
        [HttpGet]
        public ActionResult Get()
        {
            _loggerManager.LogInfo("Test information log");
            _loggerManager.LogError("Here is an error message from births controller");
            var listOfBirths= _repository.FindAll(false).ToList();
            return Ok(listOfBirths);
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var birth = _repository.Find(id);
            return Ok(birth);
        }
        [HttpPost]
        public ActionResult Add([FromBody] BirthDto birth)
        {

            var newBirth =new Birth {
                DateOfBirth=birth.DateOfBirth,
                FirstName=birth.FirstName,
                MiddleName=birth.MiddleName,
                LastName=birth.LastName,
                Address=birth.Address,
            };
            _repository.Update(newBirth);
            return CreatedAtAction("Get", newBirth);
        }
        [HttpPatch("{id}")]
        public ActionResult Patch([FromBody] JsonPatchDocument<Birth> birth, int id)
        {
            var birthToBeUpdated = _repository.Find(id);
            birth.ApplyTo(birthToBeUpdated);
           _repository.Update(birthToBeUpdated);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult Update([FromBody] BirthDto birth,int id)
        {
            var birthToBeUpdated = _repository.Find(id);
            
             birthToBeUpdated.FirstName = birth.FirstName;
            birthToBeUpdated.MiddleName = birth.MiddleName;
            birthToBeUpdated.LastName = birth.LastName;
            birthToBeUpdated.Address = birth.Address;
            birthToBeUpdated.DateOfBirth = birth.DateOfBirth;
            _repository.Update(birthToBeUpdated);
           return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var birth =_repository.Find(id);
            _repository.Delete(birth);
            return Ok();
        }
    }
}
