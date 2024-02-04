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
    public class AreaRepository : IRepository<Area>
    {
        private readonly IContext _context;
        public AreaRepository(IContext context)
        {
            _context= context;
        }
        public async Task Add(Area item)
        {
            await _context.Areas.AddAsync(item);
            await _context.save();
        }
        public async Task<Area> GetById(int id)
        {
            return await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
        }
       

        public async Task<List<Area>> GetAll()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task Delete(int id)
        {
            _context.Areas.Remove(await GetById(id));
            await _context.save();

        }

        public async Task Update(int id, Area item)
        {
            var  area= await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
            area.Name= item.Name;
            _context.save();
        }
    }
}
