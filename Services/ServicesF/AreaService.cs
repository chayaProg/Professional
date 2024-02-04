using AutoMapper;
using Common.Entity;
using Repository.Entities;
using Repository.Intarfaces;
using Services.Intaefaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesF
{
    public class AreaService : IService<AreaDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Area> _repository;
        public AreaService(IRepository<Area> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Add(AreaDto entity)
        {
            await _repository.Add(_mapper.Map<Area>(entity));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<AreaDto>> GetAll()
        {
            return _mapper.Map<List<AreaDto>>(await _repository.GetAll());
        }

        public async Task<AreaDto> GetById(int id)
        {
            return _mapper.Map<AreaDto>(await _repository.GetById(id));
        }

        public async Task Update(int id, AreaDto entity)
        {
            await _repository.Update(id, _mapper.Map<Area>(entity));
        }
    }
}
