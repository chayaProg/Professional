using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Services.Intaefaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Professional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService<CategoryDto> _service;
        public CategoryController(IService<CategoryDto> service)
        {
            _service = service;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<CategoryDto>> Get()
        {
            
            return await _service.GetAll();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public async Task<CategoryDto> Get1(int id)
        {
            return await _service.GetById(id);
        }

        /*[HttpGet("GetPro/{id}")]
        public async Task<List<ProfessionalDescriptionDto>> GetPro(int id)
        {
            return await _service.
        }*/

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult>  Post([FromBody] CategoryDto category)
        {
            return Ok(await _service.Add(category));
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDto category)
        {
            try
            {
                await _service.Update(id, category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            /*await _service.Update(id, category);*/
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
