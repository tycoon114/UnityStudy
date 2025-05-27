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
    IReadOnlyList<UserInventoryDataViewModel> FindAll();
}

public class InventoryService : IInventoryService
{
    private IUserInventoryDataRepository _inventoryDataRepository;
    private IItemRepository _itemRepository;

    public IReadOnlyList<UserInventoryData> Items => _inventoryDataRepository.FindAll();

    public void Save() => _inventoryDataRepository.Save();


    public IReadOnlyList<UserInventoryDataViewModel> FindAll()
    {
        return _inventoryDataRepository.FindAll().Select(userInventoryData =>
        {
            Item item = _itemRepository.FindById(userInventoryData.ItemId);

            return new UserInventoryDataViewModel
                (item.GradePath, item.IconPath);
        }).ToList();
    }

    public InventoryService(IUserInventoryDataRepository inventoryDataRepository, IItemRepository itemRepos)
    {
        _inventoryDataRepository = inventoryDataRepository;
        _itemRepository = itemRepos;
    }
}