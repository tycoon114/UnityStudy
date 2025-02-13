using System;
using UnityEngine;

public class ItemSample : MonoBehaviour
{
    public Item item;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            ItemInfo();
        }
    }

    private void ItemInfo()
    {
        Debug.Log(item.name);
        Debug.Log(item.description);
        Debug.Log(item.id);
        Debug.Log(item.price);
    }
}
