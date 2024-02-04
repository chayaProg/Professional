using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Intarfaces;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly IContext context;
        public CategoryRepository(IContext context)
        {
            this.context = context;
        }
        public async Task Add(Category item)
        {
          await  this.context.Categories.AddAsync(item);
          await this.context.save();
        }

        public async Task Delete(int id)
        {
           
            this.context.Categories.Remove(await GetById(id));
           await this.context.save();
        }

        public async Task<List<Category>> GetAll()
        {
            return this.context.Categories.ToList();
        }

        public async Task<Category> GetById(int id)
        {
            return  await this.context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(int id, Category item)
        {
            var category =  await this.context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            category.Name= item.Name;
            await  this.context.save();
        }
    }
}


