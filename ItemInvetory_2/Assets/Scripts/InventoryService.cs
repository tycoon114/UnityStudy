using System.Collections.Generic;
using System.Linq;

public class UserInventoryDataViewModel
{
    public string GradeSpritePath { get; }
    public string ItemIconPath { get; }
    public int Quantity { get; }

    public UserInventoryDataViewModel(string gradeSpritePath, string itemIconPath, int quantity)
    {
        GradeSpritePath = gradeSpritePath;
        ItemIconPath = itemIconPath;
        Quantity = quantity;
    }
}

public interface IInventoryService
{
    IReadOnlyList<UserInventoryDataViewModel> FindAll();
}


/// <summary>
/// 인벤토리의 기능
/// </summary>
public class InventoryService : IInventoryService
{
    private IUserInventoryDataRepository _inventoryDataRepository;
    private IItemRepository _itemRepository;
    /// <summary>
    /// 유저가 획득한 아이템
    /// </summary>
    /// UserInventoryDataRepository.FindAll()
    public IReadOnlyList<UserInventoryData> Items => _inventoryDataRepository.FindAll();

    public void Save() => _inventoryDataRepository.Save();

    public IReadOnlyList<UserInventoryDataViewModel> FindAll()
    {   
        return _inventoryDataRepository.FindAll()
            .Select(userInventoryData =>
            {
                Item item = _itemRepository.FindBy(userInventoryData.ItemId);

                return new UserInventoryDataViewModel(item.GradePath, item.IconPath, userInventoryData.Quantity);
            })
            .ToList();
    }

    public InventoryService(IUserInventoryDataRepository inventoryDataRepository, IItemRepository itemRepository)
    {
        _inventoryDataRepository = inventoryDataRepository;
        _itemRepository = itemRepository;
    }
}