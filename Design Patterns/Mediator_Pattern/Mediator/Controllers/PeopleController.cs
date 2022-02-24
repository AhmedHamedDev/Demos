using Library.Commands;
using Library.Models;
using Library.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PeopleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public async Task<List<Person>> GetPeople()
        {
            return await _mediator.Send(new GetPersonListQuery());
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _mediator.Send(new GetPersonByIdQuery(id));
        }

        // POST api/<PeopleController>
        [HttpPost]
        public async Task<Person> Post([FromBody] Person value)
        {
            return await _mediator.Send(new InsertPersonCommand(value.FirstName, value.LastName));
        }
    }
}
