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
        //�����ϰ� ������ ȹ���Ͽ� �κ��丮�� �߰�

        //������ ������ �ĺ��ڸ� ����
        int randomItemId = Item.GetRandomItemId();

        //���� �κ��丮 ������ ��ü�� �����.
        var item = UserInventoryData.Acquire(randomItemId);

        //�κ��丮�� �������� �߰��Ѵ�.
        _userInventory.AquireItem(item);
    }
}