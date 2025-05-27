using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        List<UserInventoryData> items = new()
        {
            UserInventoryData.Acquire(11001),
            UserInventoryData.Acquire(12001),
            UserInventoryData.Acquire(13001),
            UserInventoryData.Acquire(14001),
        };

        string path = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        IUserInventoryDataRepository repo = new
            UserInventoryDataRepository(path);

        IItemRepository itemRepos = new JsonItemRepository();

        InventoryService inventoryService = new InventoryService(repo , itemRepos);

        //foreach (var item in repo.FindAll())
        //{
        //    Debug.Log($"{item}");
        //}

        //repo.Save();
    }
}