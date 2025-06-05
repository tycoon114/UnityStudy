using Gpm.Ui;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InfiniteScroll _infiniteScroll;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "UserInventoryData.json");

        IUserInventoryDataRepository repo = new UserInventoryDataRepository(path);
        IItemRepository itemRepo = new JsonItemRepository();

        InventoryService inventoryService = new InventoryService(repo, itemRepo);

        // ---
        foreach (var dataViewModel in inventoryService.FindAll())
        {
            // DTO
            Sprite gradeBackgroundSprite = Resources.Load<Sprite>($"Textures/{dataViewModel.GradeSpritePath}");
            Sprite itemIconSprite = Resources.Load<Sprite>($"Textures/{dataViewModel.ItemIconPath}");

            var slotData = new InventoryItemSlotData(gradeBackgroundSprite, itemIconSprite, dataViewModel.Quantity);

            _infiniteScroll.InsertData(slotData);
        }
    }
}
