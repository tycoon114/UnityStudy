//장착을 관리하고 서비스에 의해서 관리됨


using System.Collections.Generic;
using System.Linq;
using static UnityEditor.Progress;

public class Equipment
{
    //6개의 슬롯 관리
    //맵으로 관리

    private Dictionary<EquipSlotType, EquipSlot> _equipSlots;

    public Equipment()
    {
        _equipSlots[EquipSlotType.Weapon] = new EquipSlot(EquipSlotType.Weapon);
        _equipSlots[EquipSlotType.Shield] = new EquipSlot(EquipSlotType.Shield);
        _equipSlots[EquipSlotType.ChestArmor] = new EquipSlot(EquipSlotType.ChestArmor);
        _equipSlots[EquipSlotType.Gloves] = new EquipSlot(EquipSlotType.Gloves);
        _equipSlots[EquipSlotType.Boots] = new EquipSlot(EquipSlotType.Boots);
        _equipSlots[EquipSlotType.Accessary] = new EquipSlot(EquipSlotType.Accessary);
    }

    public IReadOnlyDictionary<EquipSlotType,UserInventoryData> EquippedItems
    {
        get
        {
            return _equipSlots.Where(kvp=> kvp.Value.IsEquipped)
                              .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.EquipItem);
        }
    }



    public void Equip(EquipSlotType type, UserInventoryData item)
    {
        _equipSlots[type].Equip(item);


    }

    public void Unequip(EquipSlotType type)
    {
        _equipSlots[type].Unequip();
    }

    private int GetIndexFrom(EquipSlotType type)
    {
        return (int)type;
    }
}