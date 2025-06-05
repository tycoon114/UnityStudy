using System;
using System.Collections.Generic;
using System.Linq;

public class UserInventory
{
    private Inventory _inventory;
    private Equipment _equipment;


    public static UserInventory CreateEmpty()
    {
        return new UserInventory(Inventory.CreateEmpty(), Equipment.CreateEmpty());
    }

    public UserInventory(Inventory inventory, Equipment equipment)
    {
        _inventory = inventory;
        _equipment = equipment;
    }

    public void AquireItem(UserInventoryData item)
    {
        _inventory.AddItem(item);
    }

    public IReadOnlyCollection<UserInventoryData> Items => _inventory.Items;
    public IReadOnlyDictionary<EquipSlotType, UserInventoryData> EquippedItems => _equipment.EquippedItems;


    public IReadOnlyCollection<UserInventoryData> UnequippedItems
    {
        get
        {
            //�κ��丮�� ��� ������ �� ������ �������� �����ϰ� ��ȯ
            var equiped = EquippedItems.Values.ToHashSet();

            return Items
                .Where(item => !equiped.Contains(item) == false)
                .ToList();
        }
    }
}