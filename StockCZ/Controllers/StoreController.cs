using Microsoft.AspNetCore.Mvc;
using StockCZ.Models.Domain;
using StockCZ.Models.Dto;
using StockCZ.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class StoreController : Controller
{
    private readonly IStoreRepository _storeRepository;

    public StoreController(IStoreRepository storeRepository)
    {
        _storeRepository = storeRepository;
    }

    public async Task<IActionResult> Index()
    {
        var stores = (await _storeRepository.GetAllAsync()).ToList();
        return View(stores);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(StoreViewModel storeDTO)
    {
        if (ModelState.IsValid)
        {
            int newId = await _storeRepository.GetMaxIdAsync();

            var newStore = new Store
            {
                BaseId = newId,
                Name = storeDTO.Name
            };
            await _storeRepository.AddAsync(newStore); 
            return RedirectToAction(nameof(Index));
        }
        return View(storeDTO);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var store = await _storeRepository.GetByIdAsync(id);

        if (store == null)
        {
            return NotFound();
        }

        var storeDTO = new StoreViewModel
        {
            Name = store.Name
        };

        return View(storeDTO);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, StoreViewModel storeDTO)
    {
        if (ModelState.IsValid)
        {
            var existingStore = await _storeRepository.GetByIdAsync(id);

            if (existingStore == null)
            {
                return NotFound();
            }

  
            existingStore.Name = storeDTO.Name;

            await _storeRepository.UpdateAsync(existingStore);

            return RedirectToAction(nameof(Index));
        }

        return View(storeDTO);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var store = await _storeRepository.GetByIdAsync(id);

        if (store == null)
        {
            return NotFound();
        }

        return View(store);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var store = await _storeRepository.GetByIdAsync(id);

        if (store == null)
        {
            return NotFound();
        }

        await _storeRepository.DeleteAsync(store);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var store = await _storeRepository.GetByIdAsync(id);

        if (store == null)
        {
            return NotFound();
        }

        return View(store);
    }
}
