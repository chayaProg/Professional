using AutoMapper;
using Common.Entity;
using Repository.Entities;
using Repository.Intarfaces;
using Services.Intaefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesF
{
    public class ProfessionalService : IService<ProfessionalDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Professional> _repository;
        public ProfessionalService(IMapper mapper,IRepository<Professional> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task Add(ProfessionalDto entity)
        {
            await _repository.Add(_mapper.Map<Professional>(entity));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<ProfessionalDto>> GetAll()
        {
            return _mapper.Map<List<ProfessionalDto>>(await _repository.GetAll());
        }

        public async Task<ProfessionalDto> GetById(int id)
        {
            return _mapper.Map<ProfessionalDto>(await _repository.GetById(id));
        }

        public async Task Update(int id, ProfessionalDto entity)
        {
            await _repository.Update(id, _mapper.Map<Professional>(entity));
        }
    }
}
