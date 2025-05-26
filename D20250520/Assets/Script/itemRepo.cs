using UnityEngine;
using System;
using System.Collections.Generic;

//사용할 아이템 객체 - > 도메인 객체나 엔터티라고도 한다.
public enum ItemType
{
    None,
    Weapon,
    Shield,
    ChestArmor,
    Gloves,
    Boots,
    Accessary
}

public enum ItemGrade
{
    None,
    Common,
    UnCommon,
    Rare,
    Epic,
    Legendary
}


public sealed class Item
{
    private int _id;
    private ItemType _type;
    private ItemGrade _grade;
    private int _atk;
    private int _dfn;
    private string _name;

    public Item(int id, ItemType type, ItemGrade grade, int atk, int dfn, string name)
    {
        _id = id;
        _atk = atk;
        _dfn = dfn;
        _name = name;

        _type = GetItemType(id);
        _grade = GetGrade(id);

    }
    public override string ToString()
    {
        return $"Item(id: {_id}, name: {_name}, type: {_type}, grade: {_grade}, atk: {_atk}, def: {_dfn})";
    }

    private ItemType GetItemType(int id)
    {
        int value = id / 10000;

        switch (value)
        {
            case 1:
                return ItemType.Weapon;
            case 2:
                return ItemType.Shield;
            case 3:
                return ItemType.ChestArmor;
            case 4:
                return ItemType.Gloves;
            case 5:
                return ItemType.Boots;
            case 6:
                return ItemType.Accessary;
            default:
                return ItemType.None;
        }

    }

    private ItemGrade GetGrade(int id)
    {
        int value = id / 10000 % 1000;

        switch (value)
        {
            case 1:
                return ItemGrade.Common;
            case 2:
                return ItemGrade.UnCommon;
            case 3:
                return ItemGrade.Rare;
            case 4:
                return ItemGrade.Epic;
            case 5:
                return ItemGrade.Legendary;
            default:
                return ItemGrade.None;

        }
    }
}


public interface IItemRepository
{
    IReadOnlyList<Item> FindAll();
}

public class JsonItemRepository : IItemRepository
{

    private List<Item> _items;
    public JsonItemRepository()
    {
        LoadJson();

    }
    public IReadOnlyList<Item> FindAll() => _items.AsReadOnly();

    [Serializable]
    public class ItemModel
    {
        public int item_id;
        public string item_name;
        public int attack_power;
        public int defense;
    }

    [Serializable]
    class ItemList
    {
        public ItemModel[] data;
    }

    //List<Item> = LoadItem()
    void LoadJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("items");
        string json = jsonFile.text;

        ItemList itemList = JsonUtility.FromJson<ItemList>(jsonFile.text);

        _items = new List<Item>(); // 리스트 타입 수정

        foreach (ItemModel item in itemList.data) // 변수명 그대로 유지
        {
            _items.Add(new Item(
                item.item_id,
                ItemType.None,
                ItemGrade.None,
                item.attack_power,
                item.defense,
                item.item_name
            ));
        }

    }
}
