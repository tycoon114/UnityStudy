using System;

public enum EquipSlotType
{
    None,
    Weapon,
    Shield,
    ChestArmor,
    Gloves,
    Boots,
    Accessary
}


public class EquipSlot
{
    private EquipSlotType _type;
    private UserInventoryData? _item;

    public EquipSlot(EquipSlotType type)
    { 
        _type = type;
    }

    public UserInventoryData EquipItem
    {
        get
        {
            if (IsEquipped == false)
            {
                throw new InvalidOperationException("아이템이 장착되어 있지 않습니다.");
            }
            return _item;
        }
    }


    //장착 여부
    public bool IsEquipped=> _item != null;

    //장착
    public void Equip(UserInventoryData item)
    {
        //아이템이 슬롯에 있으면 변경
        if (IsEquipped)
        { 
            Unequip();
        }

        _item = item;

    }



    //장착해제
    public void Unequip()
    {
        if(IsEquipped == false)
        {

            throw new InvalidOperationException("아이템이 장착되어 있지 않습니다.");
        }
        _item = null;
    }
}
