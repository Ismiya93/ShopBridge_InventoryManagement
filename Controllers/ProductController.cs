using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge_InventoryManagement.Contract;
using ShopBridge_InventoryManagement.Core;
using ShopBridge_InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge_InventoryManagement.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        /**
         * ProductController constructor.
         */
        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        /**
         * GET: /Product/Create
         */
        public IActionResult Create()
        {
            return View(new Models.Products());
        }

        /**
         * POST: /Product/Create
         * @param productModel Product model
         */
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description,Price")] Models.Products productModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepository.CreateProduct(productModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
            }

            return View(productModel);
        }

        /**
         * GET: /Product/Details/<id>
         * @param id Product ID
         */
        public async Task<IActionResult> Details(long id)
        {
            if (id == 0)
                return NotFound();

            var productModel = await _productRepository.GetProductByID(id);

            if (productModel == null)
                return NotFound();

            return View(productModel);
        }

        /**
         * GET: /Product/Edit/<id>
         * @param id Product ID
         */
        public async Task<IActionResult> Edit(long id)
        {
            if (id == 0)
                return NotFound();

            var productModel = await _productRepository.GetProductByID(id);

            if (productModel == null)
                return NotFound();

            return View(productModel);
        }

        /**
         * POST: /Product/Edit/<id>
         * @param id Product ID
         * @param productModel Product model
         */
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id,Products productModel)
        {
            if (id != productModel.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _productRepository.UpdateProduct(productModel);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ProductModelExists(productModel.ID))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(productModel);
        }

        /**
         * GET: /Product/Delete/<id>
         * @param id Product ID
         */
        public async Task<IActionResult> Delete(long id)
        {
            if (id == 0)
                return NotFound();

            var productModel = await _productRepository.GetProductByID(id);

            if (productModel == null)
                return NotFound();

            return View(productModel);
        }

        /**
         * POST: /Product/Delete/<id>
         * @param id Product ID
         */
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            try
            {
                var productModel = await _productRepository.DeleteProduct(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                    throw;
            }
        }

        /**
         * GET: [ /Product/, /Product/Index ]
         */
        public async Task<IActionResult> Index()
        {
            return View(await _productRepository.GetAllProduct());
        }

        /**
         * Returns the specified product if it exists.
         * @param id Product ID
         */
        private bool ProductModelExists(long id)
        {
            return _productRepository.IsProductExists(id);
        }

    }
}
