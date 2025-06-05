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
                throw new InvalidOperationException("�������� �����Ǿ� ���� �ʽ��ϴ�.");
            }
            return _item;
        }
    }


    //���� ����
    public bool IsEquipped=> _item != null;

    //����
    public void Equip(UserInventoryData item)
    {
        //�������� ���Կ� ������ ����
        if (IsEquipped)
        { 
            Unequip();
        }

        _item = item;

    }



    //��������
    public void Unequip()
    {
        if(IsEquipped == false)
        {

            throw new InvalidOperationException("�������� �����Ǿ� ���� �ʽ��ϴ�.");
        }
        _item = null;
    }
}
