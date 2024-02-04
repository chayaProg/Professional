﻿using AutoMapper;
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
    public class CategoryService : IService<CategoryDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;
        public CategoryService(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Add(CategoryDto entity)
        {
            await _repository.Add(_mapper.Map<Category>(entity));
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

        public async Task Update(int id, CategoryDto entity)
        {
            await _repository.Update(id, _mapper.Map<Category>(entity));
        }
    }
}