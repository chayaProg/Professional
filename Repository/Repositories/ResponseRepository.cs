﻿
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
    public class ResponseRepository : IRepository<Response>
    {
        private readonly IContext _context;
        public ResponseRepository(IContext context)
        {
            _context = context;
        }
        public async Task Add(Response item)
        {
            await _context.Responses.AddAsync(item);
          await _context.save();
        }
        public async Task<Response> GetById(int id)
        {
            return await _context.Responses.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task Delete(int id)
        {
            _context.Responses.Remove(await GetById(id));
            await _context.save();
        }

        public async Task<List<Response>> GetAll()
        {
            return await _context.Responses.ToListAsync();
        }



        public async Task Update(int id, Response item)
        {
            var response =  await _context.Responses.FirstOrDefaultAsync(x => x.Id == id);
            response.Img= item.Img;
            //הרי לא צריך לשנות תגובה בכל אופן?
            /*  response.response_description= item.response_description;*/
            //לאפשר שינוי 
            /*response.ProfessionalDesId = item.ProfessionalDesId;
            response.UserId = item.UserId;*/
            await _context.save();

        }
    }
}
