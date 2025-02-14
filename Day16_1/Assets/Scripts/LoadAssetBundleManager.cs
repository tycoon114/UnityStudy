using System.Collections;
using System.IO;
using UnityEngine;

public class LoadAssetBundleManager : MonoBehaviour
{

    string path = "Assets/Bundles/asset3";

    void Start()
    {
        StartCoroutine(LoadAsync(path));
    }

    IEnumerator LoadAsync(string path) {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
        
        //������Ʈ�� ���� ������ ���
        yield return request;
        
        //������Ʈ�� ���� �޾ƿ� ���� ������ ������ ����
        AssetBundle bundle = request.assetBundle;
        
        //���޹��� ������ ���� ������ �ε�
        GameObject prefab3 = bundle.LoadAsset<GameObject>("RedSphere");
        Instantiate(prefab3);

        //GameObject prefab2 = bundle.LoadAsset<GameObject>("GreenSphere");
        //Instantiate(prefab2);

        //GameObject prefab1 = bundle.LoadAsset<GameObject>("BlueSphere");
        //Instantiate(prefab1);
    }

}
