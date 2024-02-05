using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Intaefaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Professional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalDescriptionController : ControllerBase
    {
        private readonly IService<ProfessionalDescriptionDto> _service;
        public ProfessionalDescriptionController(IService<ProfessionalDescriptionDto> service)
        {
            _service = service;
        }
        // GET: api/<ProfessionalDescriptionController>
        [HttpGet]
        public async Task<List<ProfessionalDescriptionDto>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<ProfessionalDescriptionController>/5
        [HttpGet("{id}")]
        public async Task<ProfessionalDescriptionDto> Get1(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<ProfessionalDescriptionController>
        [HttpPost]
        public async Task Post([FromBody] ProfessionalDescriptionDto professionalDes)
        {
            await _service.Add(professionalDes);
        }

        // PUT api/<ProfessionalDescriptionController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ProfessionalDescriptionDto professionalDes)
        {
            await _service.Update(id, professionalDes);
        }

        // DELETE api/<ProfessionalDescriptionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
