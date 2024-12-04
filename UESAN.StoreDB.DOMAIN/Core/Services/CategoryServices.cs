using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UESAN.StoreDB.DOMAIN.Core.DTO;
using UESAN.StoreDB.DOMAIN.Core.Entities;
using UESAN.StoreDB.DOMAIN.Core.Interfaces;

namespace UESAN.StoreDB.DOMAIN.Core.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CateogryListDTO>> GetCategories()
        {
            var categories = await _categoryRepository.GetCategories();
            var categoriesDTO = new List<CateogryListDTO>();
            foreach (var category in categories)
            {
                var categoryDTO = new CateogryListDTO();
                categoryDTO.Id = category.Id;
                categoryDTO.Description = category.Description;
                categoriesDTO.Add(categoryDTO);
            }
            return categoriesDTO;
        }
        public async Task<CateogryListDTO> GetCategoryByID(int id)
        {
            var category = await _categoryRepository.GetCategoryByID(id);
            if (category == null)
            {
                return null;
            }

            var categoryDTO = new CateogryListDTO
            {
                Id = category.Id,
                Description = category.Description
            };

            return categoryDTO;

        }

        public async Task<int> Insert(CateogryDescriptionDTO categoryDTO)
        {
            var category = new Category();
            category.Description = categoryDTO.Description;
            int id = await _categoryRepository.Insert(category);
            return id;
        }

        public async Task<bool> Delete(int id)
        {
            var cat = await _categoryRepository.Delete(id);
            return cat;
        }


        public async Task<bool> Update(CategoryDTO categoryDTO)
        {
            var category = new Category();
            category.Id = categoryDTO.Id;
            category.Description = categoryDTO.Description;
            category.IsActive = categoryDTO.IsActive;
            bool resp = await _categoryRepository.Update(category);
            return resp;
        }

        public async Task<CategoryProductsDTO> GetCategoryWithProducts(int id)
        {
            var category = await _categoryRepository.GetCategoryWithProducts(id);

            var categoryProductsDTO = new CategoryProductsDTO();
            categoryProductsDTO.Id = category.Id;
            categoryProductsDTO.Description = category.Description;

            var products = new List<ProductListDTO>();
            foreach (var pd in category.Product) 
            {
                var product = new ProductListDTO();
                product.Id = pd.Id;
                product.Description = pd.Description;
                products.Add(product);
            }
            categoryProductsDTO.Products = products;
            return categoryProductsDTO;
        }
    }
}
