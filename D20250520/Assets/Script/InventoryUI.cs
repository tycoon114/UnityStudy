using Gpm.Ui;
using System.IO;
using TMPro;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public int Count = 1000;
    [SerializeField] private InfiniteScroll _infinitiScroll;

    InventoryService _inventoryService;

    private void Awake()
    {
        _inventoryService = CreateService();
    }
    void Start()
    {
        Refresh();
    }

    public void Refresh()
    { 
        _infinitiScroll.Clear();
        string path = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        IUserInventoryDataRepository repo = new
            UserInventoryDataRepository(path);
        IItemRepository itemRepos = new JsonItemRepository();

        InventoryService inventoryService = new InventoryService(repo, itemRepos);

        foreach (var dataViewModel in inventoryService.UnEquippedItem)
        {
            Sprite gradeBackSprite = Resources.Load<Sprite>($"Textures/Grade/{dataViewModel.GradeSpritePath}");
            Sprite itemSprite = Resources.Load<Sprite>($"Textures/Item/{dataViewModel.ItemPath}");

            var slotData = new InventoryItemSlotData(gradeBackSprite, itemSprite);
            _infinitiScroll.InsertData(slotData);
        }
    }

    private void CreateService()
    { 
    
    }


}
