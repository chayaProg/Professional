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
    public class ProfessionalDesRepository : IRepository<ProfessionalDescription>
    {
        private readonly IContext _context;
        public ProfessionalDesRepository(IContext context)
        {
            _context = context;
        }
         public async Task<ProfessionalDescription> Add(ProfessionalDescription item)
        {
             ProfessionalDescription professionaldes = item;
            await _context.ProfessionalDescriptions.AddAsync(item);
            try
            {
                await _context.save();
                return professionaldes;
            }
            catch (Exception)
            {

                throw new Exception("Professional description in Add fall ");
            }
           
        }

        public async Task Delete(int id)
        {

            _context.ProfessionalDescriptions.Remove(await GetById(id));
            await _context.save();
        }

        public async Task<List<ProfessionalDescription>> GetAll()
        {
            return _context.ProfessionalDescriptions.ToList();
        }

        public async Task<ProfessionalDescription> GetById(int id)
        {
            return await _context.ProfessionalDescriptions.Include(profdes=>profdes.Professional).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ProfessionalDescription> Update(int id, ProfessionalDescription item)
        {
            var professionalDescription = await _context.ProfessionalDescriptions.FirstOrDefaultAsync(x => x.Id == id);
            professionalDescription.Years_of_experience = item.Years_of_experience;
            professionalDescription.Details = item.Details;
            professionalDescription.Fair_price = item.Fair_price;
            professionalDescription.Professionalism= item.Professionalism;
            //האם צריך גם לתת לשנות את האובייקטים מהסוג השונה?
            professionalDescription.CategoryId = item.CategoryId;
            professionalDescription.ProfessionalId = item.ProfessionalId;
            //צריך  לעשות?
            /*   professionalDescription.Responses = item.Responses;*/
            try
            {
                await _context.save();
                return professionalDescription;
            }
            catch (Exception)
            {

                throw new Exception("");
            }
            
        }
    }
}
