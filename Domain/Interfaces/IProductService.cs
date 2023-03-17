using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProduct(int id);
        Task<ProductDTO> AddProduct(ProductDTO product);
        Task<ProductDTO> UpdateProduct(ProductDTO product);
        Task DeleteProduct(int productId);
    }
}
