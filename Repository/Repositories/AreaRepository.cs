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
        public async Task<Area> Add(Area item)
        {
            Area area = item;
            await _context.Areas.AddAsync(item);
            try { 
                await _context.save();
                return area;
            }
            catch (Exception e){
                throw new Exception();
            }
           
            
              
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

        public async Task<Area> Update(int id, Area item)
        {
            var  area= await _context.Areas.FirstOrDefaultAsync(x => x.Id == id);
            area.Name= item.Name;
            try
            {
                await _context.save();
                return area;

            }
            catch (Exception)
            {

                throw new Exception("dont save updates area");
            }
           
        }
        // לא יבוא פה לישדי שימוש
        /* public async Task<List<Area>> GetForeinghColletionById(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}
