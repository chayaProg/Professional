using System.IO;
using System;
using Common.Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Intaefaces;
using Repository.Entities;
using Azure;


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

        [HttpGet("getImage/{ImageUrl}")]
        public string GetImage(string ImageUrl)
        {
            if (ImageUrl == null) throw new ArgumentNullException(nameof(ImageUrl));
            else
            {
                //var path = Path.Combine(Environment.CurrentDirectory, "/Controllers" + "/Images/", ImageUrl);
                var path = Path.Combine(Environment.CurrentDirectory + "/Images/", ImageUrl);
                byte[] bytes = System.IO.File.ReadAllBytes(path);
                string imageBase64 = Convert.ToBase64String(bytes);
                string image = string.Format("data:image/jpeg;base64,{0}", imageBase64);
                return image;
            }
        }


        // GET: api/<ResponseController>
        [HttpGet]
        public async Task<List<ResponseDto>> Get()
        {
            var responses = await _service.GetAll();
            foreach (var t in responses)
            {
                t.UrlImage = GetImage(t.UrlImage);
            }
            return responses;
        }
       

        // GET api/<ResponseController>/5
        [HttpGet("{id}")]
        public async Task<ResponseDto> Get1(int id)
        {
            return await _service.GetById(id);
        }


 

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ResponseDto response)
        {

            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + response.Image.FileName);

            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                response.Image.CopyTo(fs);
                fs.Close();
            }
            response.UrlImage = response.Image.FileName;
            
            return Ok(await _service.Add(response));

        }


        // PUT api/<ResponseController>/5
        [HttpPut("{id}")]
        /*public async Task<ActionResult> Put(int id, [FromBody] ResponseDto response)
        {
            return Ok(await _service.Add(response));
            *//*await _service.Update(id, response);*//*
        }*/
        public async void Put(int id, [FromForm] ResponseDto response)
        {
            var myPath = Path.Combine(Environment.CurrentDirectory + "/Images/" + response.Image.FileName);
            Console.WriteLine("myPath: " + myPath);

            using (FileStream fs = new FileStream(myPath, FileMode.Create))
            {
                response.Image.CopyTo(fs);
                fs.Close();
            }
            response.UrlImage = response.Image.FileName;
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
