using UESAN.StoreDB.DOMAIN.Core.DTO;

namespace UESAN.StoreDB.DOMAIN.Core.Interfaces
{
    public interface ICategoryServices
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<CateogryListDTO>> GetCategories();
        Task<CateogryListDTO> GetCategoryByID(int id);
        Task<int> Insert(CateogryDescriptionDTO categoryDTO);
        Task<bool> Update(CategoryDTO categoryDTO);
        Task<CategoryProductsDTO> GetCategoryWithProducts(int id);
    }
}