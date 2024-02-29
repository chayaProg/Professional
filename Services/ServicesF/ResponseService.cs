using AutoMapper;
using Common.Entity;
using Microsoft.AspNetCore.Http;
using Repository.Entities;
using Repository.Intarfaces;
using Repository.Repositories;
using Services.Intaefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesF
{
    public class ResponseService : IService<ResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Response>   _repository;
        public ResponseService(IMapper mapper, IRepository<Response> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ResponseDto> Add(ResponseDto entity)
        {
            Response response = _mapper.Map<Response>(entity);
            
            /*response.Img = entity.img.FileName;*/
            response.Response_date = DateTime.Now;
            return _mapper.Map<ResponseDto>(await _repository.Add(response));

        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<ResponseDto>> GetAll()
        {

            return _mapper.Map<List<ResponseDto>>(await _repository.GetAll());

        }

        public async Task<ResponseDto> GetById(int id)
        {

            return _mapper.Map<ResponseDto>(await _repository.GetById(id));
        }
      
        public async Task<ResponseDto> Update(int id, ResponseDto entity)
        {
            return _mapper.Map<ResponseDto>(await _repository.Update(id, _mapper.Map<Response>(entity)));

        }
    }
}
