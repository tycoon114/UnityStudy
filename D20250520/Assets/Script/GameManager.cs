using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameManager : MonoBehaviour
{
    IInventoryService inventoryService;
    [SerializeField] private InventoryUI _inventoryUI;

    void Start()
    {


    }

    private void Update()
    {
        //스페이스 키를 누르면 랜덤 아이템 획득
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventoryService.AcquireRandomItem();
            _inventoryUI.Refresh();
        }
    }
}