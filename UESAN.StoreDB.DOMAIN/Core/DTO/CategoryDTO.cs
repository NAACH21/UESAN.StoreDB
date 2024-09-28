using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESAN.StoreDB.DOMAIN.Core.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public bool? IsActive { get; set; }
    }
    public class CateogryListDTO 
    {
        public int Id { get; set; }

        public string? Description { get; set; }

    }
    public class CateogryDescriptionDTO
    {
        public string? Description { get; set; }

    }
    public class CategoryProductsDTO
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public IEnumerable<ProductListDTO> Products { get; set; }
    }

}
