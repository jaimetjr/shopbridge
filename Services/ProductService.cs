using AutoMapper;
using Domain.Base;
using Domain.DTO;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : BaseDataContext, IProductService
    {
        public ProductService(IConfiguration config, IMapper mapper) : base(config, mapper)
        {
        }

        public async Task<ProductDTO> AddProduct(ProductDTO product)
        {
            try
            {
                var model = _mapper.Map<Product>(product);
                await _context.Products.AddAsync(model);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductDTO>(model);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            try
            {
                var products = await _context.Products.ToListAsync();
                return _mapper.Map<List<ProductDTO>>(products); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDTO> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products.FirstOrDefaultAsync(x => x.Product_Id == id);
                if (product == null)
                    throw new Exception("Product not found");
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO model)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Product_Id == model.Product_Id);
                if (product == null)
                    throw new Exception("Product not found");

                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.CreatedBy = model.CreatedBy;
                product.CreatedAt = model.CreatedAt;
                product.ModifiedAt = model.ModifiedAt;
                product.ModifiedBy = model.ModifiedBy;              
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return _mapper.Map<ProductDTO>(product);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteProduct(int productId)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(x => x.Product_Id == productId);
                if (product == null)
                    throw new Exception("Product not found");

                var productModel = _mapper.Map<Product>(product);

                _context.Products.Remove(productModel);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
