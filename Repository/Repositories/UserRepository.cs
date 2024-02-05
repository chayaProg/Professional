using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Intarfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            _context = context;
        }
        public async Task Add(User item)
        {
            await _context.Users.AddAsync(item);
            await _context.save();
        }

        public async Task Delete(int id)
        {
            _context.Users.Remove(await GetById(id));
            await _context.save();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task Update(int id, User item)
        {
           var user= await _context.Users.FirstOrDefaultAsync(x=>x.Id==id); 
          user.Name=item.Name;
          user.Email=item.Email;
          user.Phone=item.Phone;
            await _context.save();

        }
    }
}
