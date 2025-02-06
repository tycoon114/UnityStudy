using System.IO;
using UnityEngine;

[System.Serializable]
public class Item01 {
    public string itemName;
    public string itemDescription;
}

public class JsonLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string loadJson = File.ReadAllText(Application.dataPath + "/itemData01.json");
        //���� ��δ� ����Ƽ������ Asset ����
        var data = JsonUtility.FromJson<Item01>(loadJson);
        Debug.Log("�����ٶ�  " + data.itemName);

        data.itemName = "changed";
        data.itemDescription = "����ȭ ";

        // ���Ϸ� �������� (save)
        File.WriteAllText(Application.dataPath+"/itemData02.json",JsonUtility.ToJson(data));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
