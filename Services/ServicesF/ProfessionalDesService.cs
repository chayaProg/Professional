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
    internal class ProfessionalDesService:IService<ProfessionalDescriptionDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<ProfessionalDescription> _repository;
        public ProfessionalDesService(IRepository<ProfessionalDescription> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(ProfessionalDescriptionDto entity)
        {
            await _repository.Add(_mapper.Map<ProfessionalDescription>(entity));
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<ProfessionalDescriptionDto>> GetAll()
        {
            return _mapper.Map<List<ProfessionalDescriptionDto>>(await _repository.GetAll());
        }

        public async Task<ProfessionalDescriptionDto> GetById(int id)
        {
            return _mapper.Map<ProfessionalDescriptionDto>(await _repository.GetById(id));
        }

        public async Task Update(int id, ProfessionalDescriptionDto entity)
        {
            await _repository.Update(id, _mapper.Map<ProfessionalDescription>(entity));
        }
    }
}
