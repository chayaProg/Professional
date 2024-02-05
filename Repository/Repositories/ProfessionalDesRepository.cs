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
         public async Task Add(ProfessionalDescription item)
        {
            await _context.ProfessionalDescriptions.AddAsync(item);
            await _context.save();
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
            return await _context.ProfessionalDescriptions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(int id, ProfessionalDescription item)
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
            await _context.save();
        }
    }
}
