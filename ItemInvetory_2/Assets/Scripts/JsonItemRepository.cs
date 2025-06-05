using System;
using System.Collections.Generic;
using System.Text;
using TMPro.Examples;
using UnityEngine;

public enum ItemType
{
    None,
    Weapon,
    Sheild,
    ChestArmor,
    Gloves,
    Boots,
    Accessary
}

public enum ItemGrade
{
    None,
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

// 우리 게임에서 사용할 아이템 객체 => 도메인 객체 / 엔터티(Entity)
public sealed class Item
{
    private int _id;
    private string _name;
    private ItemType _type;
    private ItemGrade _grade;
    private int _atk;
    private int _def;

    public int Id => _id;
    public string GradePath => $"{_grade}";
    public string IconPath
    {
        get
        {
            StringBuilder sb = new StringBuilder(_id.ToString());
            sb[1] = '1';
            return sb.ToString();
        }
    }

    public Item(int id, string name, int atk, int def)
    {
        _id = id;
        _name = name;
        _atk = atk;
        _def = def;

        _type = GetType(id);
        _grade = GetGrade(id);
    }

    public override string ToString()
    {
        return $"Item(id: {_id}, name: {_name}, type: {_type}, grade: {_grade}, atk: {_atk}, def: {_def})";
    }

    private ItemType GetType(int id)
    {
        int value = id / 10000;
        switch (value)
        {
            case 1:
                return ItemType.Weapon;
            case 2:
                return ItemType.Sheild;
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
        int value = id % 10000 / 1000;
        switch (value)
        {
            case 1:
                return ItemGrade.Common;
            case 2:
                return ItemGrade.Uncommon;
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
    Item FindBy(int id);
}

// Item 관련 Persistency를 담당한다.
public class JsonItemRepository : IItemRepository
{
    private List<Item> _items;

    public JsonItemRepository()
    {
        _items = LoadItems();
    }

    // 반환 타입
    public IReadOnlyList<Item> FindAll() => _items.AsReadOnly();

    // DTO; Data Transfer Object
    // 외부와 소통하기 위한 객체. 직렬화만을 위한 객체. 데이터 전송만을 위한 객체
    [Serializable]
    class ItemModel
    {
        public int item_id;
        public string item_name;
        public int attack_power;
        public int defense;
    }

    [Serializable]
    class ItemModelList
    {
        public ItemModel[] data;
    }

    List<Item> LoadItems()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("items");
        string json = jsonFile.text;
        ItemModelList itemModelList = JsonUtility.FromJson<ItemModelList>(json);

        var items = new List<Item>();
        foreach (ItemModel itemModel in itemModelList.data)
        {
            items.Add(new Item(itemModel.item_id, itemModel.item_name, itemModel.attack_power, itemModel.defense));
        }

        return items;
    }

    public Item FindBy(int id)
    {
        return _items.Find(item => item.Id == id);
    }
}