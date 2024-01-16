using Microsoft.AspNetCore.Mvc;
using StockCZ.Models.Dto;
using StockCZ.Repositories;
using StockCZ.Models.Domain;
using System;
using System.Threading.Tasks;

namespace StockCZ.Controllers
{
    public class StockMovementController : Controller
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IStockMovementRepository _stockMovementRepository;

        public StockMovementController(
            IStoreRepository storeRepository,
            IItemRepository itemRepository,
            IStockMovementRepository stockMovementRepository)
        {
            _storeRepository = storeRepository;
            _itemRepository = itemRepository;
            _stockMovementRepository = stockMovementRepository;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new PurchaseViewModel
            {
                Stores = await _storeRepository.GetAllAsync(),
                Items = await _itemRepository.GetAllAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Purchase(PurchaseViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var stockMovement = new StockMovementViewModel
                {
                   
                    StoreId = viewModel.SelectedStoreId,
                    ItemId = viewModel.SelectedItemId,
                    Quantity = viewModel.Quantity,
                    Date = DateTime.Now
                };

                var existingStock = await _stockMovementRepository.GetStockMovementByItemAndStockId(stockMovement.StoreId, stockMovement.ItemId);

                if (existingStock != null)
                {
                    existingStock.Quantity += stockMovement.Quantity;
                    existingStock.Date = DateTime.Now;

                    await _stockMovementRepository.UpdateAsync(existingStock);
                }
                else
                {
                    int newId = await _stockMovementRepository.GetMaxIdAsync();
                    var newStockMovement = new StockMovement
                    {
                        BaseId = newId,
                        StoreId = stockMovement.StoreId,
                        ItemId = stockMovement.ItemId,
                        Quantity = stockMovement.Quantity,
                        Date = DateTime.Now,
                    };

                    await _stockMovementRepository.AddAsync(newStockMovement);
                }

                return RedirectToAction("Index");
            }

            viewModel.Stores = await _storeRepository.GetAllAsync();
            viewModel.Items = await _itemRepository.GetAllAsync();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetQuantityInStock(int storeId, int itemId)
        {
            var stockMovement = await _stockMovementRepository.GetStockMovementByItemAndStockId(storeId, itemId);
            var quantityInStock = stockMovement?.Quantity ?? 0;
            return Json(new { quantity = quantityInStock });
        }
    }
}
