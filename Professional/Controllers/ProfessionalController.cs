using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Intaefaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Professional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        private readonly IService<ProfessionalDto> _service;
        public ProfessionalController(IService<ProfessionalDto> service)
        {
            _service = service;
        }
        // GET: api/<ProfessionalController>
        [HttpGet]
        public async Task<List<ProfessionalDto>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<ProfessionalController>/5
        [HttpGet("{id}")]
        public async Task<ProfessionalDto> Get1(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<ProfessionalController>
        [HttpPost]
        public async Task Post([FromBody] ProfessionalDto professional)
        {
            await _service.Add(professional);
        }

        // PUT api/<ProfessionalController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProfessionalDto professional)
        {
            await _service.Update(id, professional);
        }

        // DELETE api/<ProfessionalController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
