using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;
using UESAN.StoreDB.DOMAIN.Infrastructure.Data;

namespace UESAN.StoreDB.DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public string obtenerApellido()
        {

            return "";
        }


        //public  IEnumerable<Category> GetCategories()
        //{
        //    var categorias = _dbContext.Category.ToList();
        //    return categorias;
        //}
        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categorias = await _dbContext.Category.ToListAsync();
            return categorias;
        }

        //Get category by ID

        public async Task<Category> GetCategoryByID(int id)
        {
            var category = await _dbContext
                .Category
                .Where(c => c.Id == id && c.IsActive == true)
                .FirstOrDefaultAsync();
            return category;
        }

        //create categori
        //public async Task<int> Insert(Category category)
        //{
        //    await _dbContext.Category.AddAsync(category);
        //    _dbContext.SaveChangesAsync();
        //    return category.Id;
        //}

        public async Task<int> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? category.Id : -1;
        }

        //Update category
        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        //Delete category

        public async Task<bool> Delete(int id)
        {
            var category = _dbContext
                            .Category
                            .FirstOrDefault(c => c.Id == id);
            //_dbContext.Category.Remove(category);
            if (category != null)
            {
                return false;
            }
            category.IsActive = false;

            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
