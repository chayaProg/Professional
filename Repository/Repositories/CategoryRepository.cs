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
        public async Task<Category> Add(Category item)
        { Category category = item;
          await  this.context.Categories.AddAsync(item);
            try
            {
                await this.context.save();
                return category;
            }
            catch (Exception)
            {

                throw new Exception("cant save Add category");
            }
         
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
       /* public async Task<List<ProfessionalDescription>> GetForeinghColletionById(int id )
        {
            return await this.context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        }*/

        public async Task<Category> Update(int id, Category item)
        {
            var category =  await this.context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            category.Name= item.Name;
            try
            {
                await this.context.save();
                return category;
            }
            catch (Exception)
            {

                throw new Exception("cant save updates in category");
            }
            
        }
    }
}


