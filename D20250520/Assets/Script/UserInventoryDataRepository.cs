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
    IReadOnlyList<UserInventoryData> FindAll();
    void Save();
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

    public IReadOnlyList<UserInventoryData> FindAll()
    {
        throw new NotImplementedException();
    }

    public void Save()
    {
        throw new NotImplementedException();
    }

}

//테스트 데이터를 위한 레포지토리 
public class TestUserInventoryDataRepository : IUserInventoryDataRepository
{

    private List<UserInventoryData> _items;
    public string _path;


    public TestUserInventoryDataRepository(string path, List<UserInventoryData> items)
    {
        _path = path;
        _items = items;
    }

    public IReadOnlyList<UserInventoryData> FindAll() => _items.AsReadOnly();


    public void Save()
    {
        var modelList = new List<UserInventoryDataModel>();

        foreach (var item in _items)
        {
            modelList.Add(new UserInventoryDataModel()
            {
                _serial_number = item.SerialNumber,
                _item_id = item.ItemId,
            });
        }

        var dto = new UserInventoryDataModelList()
        {
            data = modelList
        };


        string json = JsonUtility.ToJson(dto);
        File.WriteAllText(_path, json);
    }
}