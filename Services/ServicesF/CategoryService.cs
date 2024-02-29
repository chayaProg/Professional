using AutoMapper;
using Common.Entity;
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
    public class CategoryService : IService<CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CategoryDto> Add(CategoryDto entity)
        {
            return _mapper.Map<CategoryDto>(await _repository.Add(_mapper.Map<Category>(entity)));
        }  

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            return _mapper.Map<List<CategoryDto>>(await _repository.GetAll());
        }

        public async Task<CategoryDto> GetById(int id)
        {
            return _mapper.Map<CategoryDto>(await _repository.GetById(id));

        }
        /*public List<ProfessionalDescriptionDto> GetProffById(int id)
        {
            return (_mapper.Map<List<ProfessionalDescriptionDto>>(((CategoryRepository)_repository).GetProffById(id)));
        }*/


        public async Task<CategoryDto> Update(int id, CategoryDto entity)
        {
            return _mapper.Map<CategoryDto>(await _repository.Update(id, _mapper.Map<Category>(entity)));

        }
    }
}
