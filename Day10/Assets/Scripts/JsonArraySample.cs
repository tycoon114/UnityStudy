using UnityEngine;
using System;
using System.Collections.Generic;


[Serializable]
public class Item {
    public string itemName;
    public int itemCount;

}

[Serializable]
public class InventoryA {
    public List<Item> itemInventory; // json ���Ͽ��� ����ϰ� �ִ� �̸��� �״�� ���
    //public Item[] inventory; ����Ƽ������ �迭�� ����Ʈ�� ���� ���

}
public class JsonArraySample : MonoBehaviour
{
    //���ҽ� ������ �̿��� ������ �ε� ��� ���

    void Start()
    {

        TextAsset textAsset = Resources.Load<TextAsset>("itemInventory");

        InventoryA inventory = JsonUtility.FromJson<InventoryA>(textAsset.text);

        int total = 0;

        foreach (Item item in inventory.itemInventory) { 
            Debug.Log(item);
            total++;

        }
        Debug.Log(total);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
