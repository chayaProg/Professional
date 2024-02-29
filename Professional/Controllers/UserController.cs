using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Services.Intaefaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Professional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IService<UserDto> _service;
        public UserController(IService<UserDto> service)
        {
            _service = service;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserDto>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get1(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDto user)
        {
            return Ok(await _service.Add(user));
            /*await _service.Add(user);*/
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserDto user)
        {
            try
            {
                await _service.Update(id, user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
           /* await _service.Update(id, user);*/
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
