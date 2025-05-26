using System.Collections.Generic;
public class InventoryService
{ 
    private IUserInventoryDataRepository _inventoryDataRepository;
    public IReadOnlyList<UserInventoryData> Items => _inventoryDataRepository.FindAll();

    public InventoryService(IUserInventoryDataRepository inventoryDataRepository)
    {
        _inventoryDataRepository = inventoryDataRepository;
    }
}