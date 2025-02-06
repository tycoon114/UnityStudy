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
    public List<Item> itemInventory; // json 파일에서 사용하고 있는 이름을 그대로 사용
    //public Item[] inventory; 유니티에서는 배열과 리스트는 같은 취급

}
public class JsonArraySample : MonoBehaviour
{
    //리소스 폴더를 이용한 데이터 로드 방법 사용

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
