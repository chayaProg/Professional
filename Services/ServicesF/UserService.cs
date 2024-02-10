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
    public class UserService : IService<UserDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _repository;
        public UserService(IMapper mapper, IRepository<User> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task Add(UserDto entity)
        {
            await _repository.Add(_mapper.Map<User>(entity));
        }
        
        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task<List<UserDto>> GetAll()
        {
            return _mapper.Map<List<UserDto>>(await _repository.GetAll());
        }

        public async Task<UserDto> GetById(int id)
        {
            return _mapper.Map<UserDto>(await _repository.GetById(id));
        }

        public async Task Update(int id, UserDto entity)
        {
            await _repository.Update(id, _mapper.Map<User>(entity));
        }
    }
}
