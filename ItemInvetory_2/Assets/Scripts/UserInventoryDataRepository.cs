// Repository : 객체의 퍼시스턴시
// ㄴ 영속성 메모리에 객체를 저장하거나
// ㄴ 영속성 메모리로부터 객체를 복원한다.

using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;



[Serializable]
class UserInventoryDataModel
{
    public long serial_number;
    public int item_id;
    public int quantity;

    public static UserInventoryDataModel From(UserInventoryData data)
    {
        return new UserInventoryDataModel()
        {
            serial_number = data.SerialNumber,
            item_id = data.ItemId
        };
    }

    public static UserInventoryData ToDomain(UserInventoryDataModel model)
    {
        return new UserInventoryData(model.serial_number, model.item_id, model.quantity);
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
    void Save(); // 영속성 메모리에 저장한다.
}


public class UserInventoryDataRepository : IUserInventoryDataRepository
{
    private List<UserInventoryData> _items;
    private readonly string _path;

    // 생성자에서 할일은?
    public UserInventoryDataRepository(string path)
    {
        _path = path;

        // 파일 입력으로 메모리로 파일 내용 로드
        // ㄴ 1. json 텍스트 로드
        string json = File.ReadAllText(path);
        // ㄴ 2. json 파싱
        var modelList = JsonUtility.FromJson<UserInventoryDataModelList>(json);

        _items = modelList.data
            .Select(model => UserInventoryDataModel.ToDomain(model))
            .ToList();
    }

    public IReadOnlyList<UserInventoryData> FindAll()
    {
        return _items.AsReadOnly();
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
}

// 테스트 데이터를 위한 레포지토리
public class TestUserInventoryDataRepository : IUserInventoryDataRepository
{
    private List<UserInventoryData> _items;
    private readonly string _path;

    public TestUserInventoryDataRepository(string path, List<UserInventoryData> items)
    {
        _path = path;
        _items = items;
    }

    // 임시 객체를 반환하도록 만든다면?
    public IReadOnlyList<UserInventoryData> FindAll() => _items.AsReadOnly();

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
}