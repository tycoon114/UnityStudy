
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Inventory
{

    //���� �κ��丮 ������ �ʵ� ����
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


    //������ ���� ��� ������ ��ȸ
    public IReadOnlyCollection<UserInventoryData> Items => _items.AsReadOnly();

    //�������� ������ �ִ��� ��ȸ
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

    //���ο� ������ �߰�
    public void AddItem(UserInventoryData item)
    {
        _items.Add(item);
    }
}
