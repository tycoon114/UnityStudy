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
        //파일 경로는 유니티에서의 Asset 폴더
        var data = JsonUtility.FromJson<Item01>(loadJson);
        Debug.Log("가나다라  " + data.itemName);

        data.itemName = "changed";
        data.itemDescription = "정상화 ";

        // 파일로 내보내기 (save)
        File.WriteAllText(Application.dataPath+"/itemData02.json",JsonUtility.ToJson(data));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
