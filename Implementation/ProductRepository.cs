using Microsoft.EntityFrameworkCore;
using ShopBridge_InventoryManagement.Contract;
using ShopBridge_InventoryManagement.Core;
using ShopBridge_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_InventoryManagement.Implementation
{
    public class ProductRepository: IProductRepository
    {
        private readonly AppDbContext dbContext;
        public ProductRepository(AppDbContext dbCtx)
        {
            this.dbContext = dbCtx;
        }
        public async Task<int> CreateProduct(Products model)
        {
            try
            {
                dbContext.Add(model);
                await this.dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<Products> GetProductByID(long id)
        {
            try
            {
                return await this.dbContext.Product.SingleOrDefaultAsync(product => product.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<int> UpdateProduct(Products model)
        {
            try
            {
                this.dbContext.Update(model);
                await this.dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<int> DeleteProduct(long id)
        {
            try
            {
                Products model = await GetProductByID(id);
                this.dbContext.Remove(model);
                await this.dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<List<Products>> GetAllProduct()
        {
            try
            {
                return await this.dbContext.Product.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public bool IsProductExists(long id)
        {
            try
            {
                return dbContext.Product.Count(product => product.ID == id) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
