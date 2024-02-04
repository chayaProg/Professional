﻿using Azure;
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

        public async Task Add(Professional item)
        {
            await _context.Professionals.AddAsync(item);
            await _context.save();
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

        public async Task Update(int id, Professional item)
        {
            var professional =await _context.Professionals.FirstOrDefaultAsync(x => x.Id == id);
            professional.Name = item.Name;
            professional.Professionalism = item.Professionalism;
           /* professional.Responses = item.Responses;*/
            professional.Categories = item.Categories;
            professional.Years_of_experience = item.Years_of_experience; 
            professional.Details = item.Details;
            professional.Img=item.Img;
            professional.Area=item.Area;
            await _context.save();
        }
    }
}