using UnityEngine;
[System.Serializable]
public class SampleData {
    public int i;
    public float f;
    public bool b;
    public Vector3 v;
    public string s;
    public int[] iArray;
}

public class JsonExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SampleData sampleData = new SampleData();
        sampleData.i = 0;
        sampleData.f = 1.0f;
        sampleData.b = false;
        sampleData.v = Vector3.zero;
        sampleData.s = "hello";
        sampleData.iArray = new int[] { 1, 2 };

        string jsonData = JsonUtility.ToJson(sampleData);
        Debug.Log(jsonData);
    
        var sample2 = JsonUtility.FromJson<SampleData>(jsonData);

        Debug.Log(sample2.s);
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
