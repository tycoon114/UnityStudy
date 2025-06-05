using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

[Serializable]
class UserInventoryDataModel
{
    public long _serial_number;
    public int _item_id;

    public static UserInventoryDataModel From(UserInventoryData data)
    {
        return new UserInventoryDataModel()
        {
            _serial_number = data.SerialNumber,
            _item_id = data.ItemId
        };
    }

    public static UserInventoryData ToDomain(UserInventoryDataModel model)
    {
        return new UserInventoryData(model._serial_number, model._item_id);
    }
}

[Serializable]
class UserInventoryDataModelList
{
    public List<UserInventoryDataModel> data;
}


public interface IUserInventoryDataRepository
{
    Inventory Load();
    void Save(Inventory inventory);
}

public class UserInventoryDataRepository : IUserInventoryDataRepository
{
    private List<UserInventoryData> _items;
    private string _path;

    public UserInventoryDataRepository(string path)
    {
        _path = path;
        string json = File.ReadAllText(_path);
        var modelList = JsonUtility.FromJson<UserInventoryDataModelList>(json);

        _items = modelList.data
            .Select(modelList =>
        UserInventoryDataModel.ToDomain(modelList)).ToList();
    }

    public void Save()
    {
        // 1. json으로 변환
        var modelList = _items
            .Select(item => UserInventoryDataModel.From(item))
            .ToList();
        var dto = new UserInventoryDataModelList()
        {
            data = modelList
        };
        var json = JsonUtility.ToJson(dto);

        // 2. 파일입출력 라이브러리 사용해서 저장
        File.WriteAllText(_path, json);
    }

    public Inventory Load()
    {

        if(false == File.Exists(_path))
        {
            return new Inventory(new List<UserInventoryData>());
        }

        string json = File.ReadAllText(_path);
        var modelList = JsonUtility.FromJson<UserInventoryDataModelList>(json);


        var userItems = modelList.data
            .Select(model => UserInventoryDataModel.ToDomain(model))
            .ToList();

        return new Inventory(userItems);
    }

    public void Save(Inventory inventory)
    {
        //인벤토리를 파일로 저장
                var modelList = inventory.Items
            .Select(item => UserInventoryDataModel.From(item))
            .ToList();
        var dto = new UserInventoryDataModelList()
        {
            data = modelList
        };
        var json = JsonUtility.ToJson(dto);

        // 2. 파일입출력 라이브러리 사용해서 저장
        File.WriteAllText(_path, json);
    }

}