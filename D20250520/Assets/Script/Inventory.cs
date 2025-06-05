
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Inventory
{

    //유저 인벤토리 데이터 필드 선언
    private List<UserInventoryData> _items;

    public Inventory(List<UserInventoryData> items)
    {
        _items = items;
    }


    public static Inventory CreateWith(List<UserInventoryData> items)
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items), "Items cannot be null");
        }
        return new Inventory(items);
    }

    public static Inventory CreateEmpty()
    {
        return new Inventory(new List<UserInventoryData>());
    }


    //유저가 가진 모든 아이템 조회
    public IReadOnlyCollection<UserInventoryData> Items => _items.AsReadOnly();

    //아이템을 가지고 있는지 조회
    public bool Contains(long serialNumber)
    {
        var found = _items.Find(item => item.SerialNumber == serialNumber);

        if (found != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //새로운 아이템 추가
    public void AddItem(UserInventoryData item)
    {
        _items.Add(item);
    }
}
