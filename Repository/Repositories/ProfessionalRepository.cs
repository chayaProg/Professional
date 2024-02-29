using Azure;
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
    public class ProfessionalRepository:IRepository<Professional> 
    {
        private readonly IContext _context;
        public ProfessionalRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Professional> Add(Professional item)
        {
            Professional professional = item;
            await _context.Professionals.AddAsync(item);
            try
            {
                await _context.save();
                return professional;
            }
            catch (Exception)
            {

                throw new Exception("fall in add professional");
            }
            
        }

        public async Task Delete(int id)
        {
            _context.Professionals.Remove(await GetById(id));
            await _context.save();
        }

        public async Task<List<Professional>> GetAll()
        {
            return await _context.Professionals.ToListAsync();
        }

        public async Task<Professional> GetById(int id)
        {
            return await _context.Professionals.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Professional> Update(int id, Professional item)
        {
            var professional =await _context.Professionals.FirstOrDefaultAsync(x => x.Id == id);
            professional.Name = item.Name;
            professional.Identity = item.Identity;
            //עדכון רק לid?או לעדכן גם את האובייקט
            professional.AreaId = item.AreaId;
            //צריך לעשותעדכון לרשימה?
            /*professional.ProfessionalDescriptions=item.ProfessionalDescriptions;*/
            professional.Email = item.Email;
            professional.Phone = item.Phone;
            try
            {
                await _context.save();
                return professional;
            }
            catch (Exception)
            {

                throw new Exception ("fall in update professional");
            }
            
        }
    }
}
