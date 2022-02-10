using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TICS.Data;
using TICS.Models;
using TICS.Service;

namespace TICS.APIControllers
{
    /// <summary>
    /// Strictly an API controller and shouldnt return any views.
    /// Used to create, update, or return Person data
    /// 
    /// Implements Controller instead of ControllerBase since this dual functions as a view controller and API
    /// </summary>
    [ApiController]
    [Route("api/PersonAPIController")]   
    public class PersonAPIController : Controller
    {
        private IPersonService _personService;

        public PersonAPIController(IPersonService personService)
        {
            _personService = personService;
        }


        [HttpGet("{id}")]
        public ActionResult<Person> Get(int id)
        {
           return _personService.GetPerson(id);
        }

        
    }
}
