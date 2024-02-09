using System.IO;
using System;
using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Intaefaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Professional.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IService<ResponseDto> _service;
        public ResponseController(IService<ResponseDto> service)
        {
            _service = service;
        }
        // GET: api/<ResponseController>
        [HttpGet]
        public async Task<List<ResponseDto>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<ResponseController>/5
        [HttpGet("{id}")]
        public async Task<ResponseDto> Get1(int id)
        {
            return await _service.GetById(id);
        }

        // POST api/<ResponseController>
        [HttpPost]
        public async Task Post([FromBody] ResponseDto response)
        {
            string imagePath = response.img;
           /* string targetDirectory = Environment.CurrentDirectory + "/Images/" ;*/
            string targetDirectory = Path.Combine(Environment.CurrentDirectory, "Images");
            string fileName = Path.GetFileName(imagePath);
            string destinationPath = Path.Combine(targetDirectory, fileName); 
            using (var sourceStream = new FileStream(imagePath, FileMode.Open))
            using (var destinationStream = new FileStream(destinationPath, FileMode.Create))
            {
                await sourceStream.CopyToAsync(destinationStream);
            }
           

            await _service.Add(response);
        }

        // PUT api/<ResponseController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] ResponseDto response)
        {
            await _service.Update(id, response);
        }

        // DELETE api/<ResponseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }
    }
}
