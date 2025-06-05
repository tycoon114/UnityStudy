using System;
using System.Collections.Generic;
using System.Linq;

public class UserInventoryDataViewModel
{
    private string gradePath;
    private string iconPath;

    public UserInventoryDataViewModel(string gradePath, string iconPath)
    {
        this.gradePath = gradePath;
        this.iconPath = iconPath;
    }

    public string GradeSpritePath { get; }
    public string ItemPath { get; }
}

public interface IInventoryService
{
    //IReadOnlyList<UserInventoryDataViewModel> FindAll();
    IReadOnlyCollection<UserInventoryDataModel> UnEquippedItem();
    void AcquireRandomItem();
}

public class InventoryService : IInventoryService
{
    private IUserInventoryDataRepository _inventoryDataRepository;
    private IItemRepository _itemRepository;
    private UserInventory _userInventory;

    //public IReadOnlyList<UserInventoryData> Items => _inventoryDataRepository.FindAll();

    public void Save() => _inventoryDataRepository.Save();

    public InventoryService(IUserInventoryDataRepository inventoryDataRepository, IItemRepository itemRepos)
    {
        _inventoryDataRepository = inventoryDataRepository;
        _itemRepository = itemRepos;
        _inventory = _inventoryDataRepository.Load();
    }

    public IReadOnlyCollection<UserInventoryDataViewModel> UnEquippedItem
    {
        get {
            return _inventory.Items.Select(userItem =>
            {
                var item = _itemRepository.FindById(userItem.ItemId);
                if (item == null)
                {
                    return null;
                }
            });
        
        }
    }

    public void AcquireRandomItem()
    {
        //랜덤하게 아이템 획득하여 인벤토리에 추가

        //랜덤한 아이템 식별자를 생성
        int randomItemId = Item.GetRandomItemId();

        //유저 인벤토리 데이터 객체를 만든다.
        var item = UserInventoryData.Acquire(randomItemId);

        //인벤토리에 아이템을 추가한다.
        _userInventory.AquireItem(item);
    }
}