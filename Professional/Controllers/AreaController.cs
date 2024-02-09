using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Intaefaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Professional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        
        private readonly IService<AreaDto> _service;
        public AreaController(IService<AreaDto> service)
        {
            _service = service;
        }
        // GET: api/<AreaController>
        [HttpGet]
        public async Task<List<AreaDto>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<AreaController>/5
        [HttpGet("{id}")]
        public async Task<AreaDto> Get1(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<AreaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AreaDto area)
        {
            try {
                await _service.Add(area);
                    return Ok(area);
            }
            catch(Exception ex) { 
                return NotFound();
            };
        }

        // PUT api/<AreaController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] AreaDto area)
        {
            await _service.Update(id, area);
        }

        // DELETE api/<AreaController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
