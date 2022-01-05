using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Entities;
using NLayerProject.Core.Service;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _PersonService;

        public PersonsController(IService<Person> PersonService)
        {
            _PersonService = PersonService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var persons = await _PersonService.GetAllAsync();
            return Ok(persons);
        }
        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newperson = await _PersonService.AddAsync(person);
            return Ok(newperson);

        }


    }
}
