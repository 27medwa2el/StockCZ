using Microsoft.AspNetCore.Mvc;
using StockCZ.Models.Domain;
using StockCZ.Models.Dto;
using StockCZ.Repositories;
using System.Linq;
using System.Threading.Tasks;

public class ItemController : Controller
{
    private readonly IItemRepository _itemRepository;

    public ItemController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IActionResult> Index()
    {
        var items = (await _itemRepository.GetAllAsync()).ToList();
        return View(items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ItemViewModel itemDTO)
    {
        if (ModelState.IsValid)
        {
            int newId = await _itemRepository.GetMaxIdAsync();
            var newItem = new Item
            {
                BaseId = newId,
                Name = itemDTO.Name,
                Price = itemDTO.Price
            };
            await _itemRepository.AddAsync(newItem);
            return RedirectToAction(nameof(Index));
        }
        return View(itemDTO);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var itemDTO = new ItemViewModel
        {
            Name = item.Name,
            Price = item.Price
        };

        return View(itemDTO);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, ItemViewModel itemDTO)
    {
        if (ModelState.IsValid)
        {
            var existingItem = await _itemRepository.GetByIdAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = itemDTO.Name;
            existingItem.Price = itemDTO.Price;

            await _itemRepository.UpdateAsync(existingItem);

            return RedirectToAction(nameof(Index));
        }

        return View(itemDTO);
    }
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        await _itemRepository.DeleteAsync(item);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var item = await _itemRepository.GetByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }
}
