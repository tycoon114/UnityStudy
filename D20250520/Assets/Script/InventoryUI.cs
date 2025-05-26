using Gpm.Ui;
using System.IO;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public int Count = 1000;
    [SerializeField] private InfiniteScroll _infinitiScroll;
    void Start()
    {

        string path = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        IUserInventoryDataRepository repo = new
            UserInventoryDataRepository(path);

        InventoryService inventoryService = new InventoryService(repo);

        foreach (UserInventoryData item in inventoryService.Items)
        {

            //new InventoryItemSlotData()
            //{ 
            
            //}

        }
    }



    void Update()
    {

    }
}
