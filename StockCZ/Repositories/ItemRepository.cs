using StockCZ.Models;
using StockCZ.Models.Domain;
using StockCZ.Models.Dto;

namespace StockCZ.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {


        public ItemRepository(AppDbContext dbContext) : base(dbContext)
        {


        }
        //    public List<Item> GetAllItems()
        //    {
        //        return _itemRepository.GetAll().ToList();
        //    }

        //    public Item GetItemById(int id)
        //    {
        //        return _itemRepository.GetById(id);
        //    }

        //    public int AddItem(ItemDto itemDTO)
        //    {
        //        int newId = _itemRepository.GetMaxId();

        //        var newItem = new Item
        //        {
        //            BaseId = newId,
        //            Name = itemDTO.Name,
        //            Price = itemDTO.Price
        //        };

        //        _itemRepository.Add(newItem);

        //        return newId;
        //    }

        //    public bool UpdateItem(int id, ItemDto itemDTO)
        //    {
        //        var existingItem = _itemRepository.GetById(id);

        //        if (existingItem == null)
        //        {
        //            return false;
        //        }


        //        existingItem.Name = itemDTO.Name;
        //        existingItem.Price = itemDTO.Price;

        //        _itemRepository.Update(existingItem);

        //        return true;
        //    }

        //    public bool DeleteItem(int id)
        //    {

        //        try
        //        {
        //            var itemToDelete = _itemRepository.GetById(id);

        //            if (itemToDelete == null)
        //            {
        //                return false;
        //            }

        //            _itemRepository.Delete(itemToDelete);


        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }

        //    }
        //}
    }
}
