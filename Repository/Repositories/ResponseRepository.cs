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
        public async Task<Response> Add(Response item)
        {    Response response = item;
            try
            {
                await _context.Responses.AddAsync(item);
                /* ProfessionalDescription professionalDescription = _context.Responses.FirstOrDefault(x => x.Id == item.Id).ProfessionalDes;*/
                ProfessionalDescription professionalDescription = _context.ProfessionalDescriptions.FirstOrDefault(x => x.Id == item.ProfessionalDesId);
                professionalDescription.NumResponses++;
                professionalDescription.Professionalism = (professionalDescription.Professionalism + item.Professionalism);
                professionalDescription.Fair_price = (professionalDescription.Fair_price + item.Fair_price);
                try
                {
                    await _context.save();
                    return response;
                }
                catch (Exception)
                {

                    throw new Exception("fall in save in add response");
                }
            }
            catch
            { throw new Exception("fall in add in add response"); }
            
            
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



        public async Task<Response> Update(int id, Response item)
        {
            var response =  await _context.Responses.FirstOrDefaultAsync(x => x.Id == id);
            response.UrlImage= item.UrlImage;
            //הרי לא צריך לשנות תגובה בכל אופן?
            /*  response.response_description= item.response_description;*/
            //לאפשר שינוי 
            /*response.ProfessionalDesId = item.ProfessionalDesId;
            response.UserId = item.UserId;*/
            try
            {
                await _context.save();
                return response;
            }
            catch (Exception)
            {

                throw new Exception("fall update response");
            }
            

        }
    }
}
