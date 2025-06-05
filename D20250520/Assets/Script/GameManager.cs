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
        //�����̽� Ű�� ������ ���� ������ ȹ��
        if(Input.GetKeyDown(KeyCode.Space))
        {
            inventoryService.AcquireRandomItem();
            _inventoryUI.Refresh();
        }
    }
}