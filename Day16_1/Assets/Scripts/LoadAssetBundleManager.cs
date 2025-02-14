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
        
        //리퀘스트가 끝날 때까지 대기
        yield return request;
        
        //리퀘스트를 통해 받아온 에셋 번들의 정보를 적용
        AssetBundle bundle = request.assetBundle;
        
        //전달받은 번들을 통해 에셋을 로드
        GameObject prefab3 = bundle.LoadAsset<GameObject>("RedSphere");
        Instantiate(prefab3);

        //GameObject prefab2 = bundle.LoadAsset<GameObject>("GreenSphere");
        //Instantiate(prefab2);

        //GameObject prefab1 = bundle.LoadAsset<GameObject>("BlueSphere");
        //Instantiate(prefab1);
    }

}
