using ShopBridge_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_InventoryManagement.Contract
{
    public interface IProductRepository
    {
       Task<int> CreateProduct(Products model);
       Task<Products> GetProductByID(long id);
       Task<int> UpdateProduct(Products model);
       Task<int> DeleteProduct(long id);
       Task<List<Products>> GetAllProduct();
       bool IsProductExists(long id);
    }
}
