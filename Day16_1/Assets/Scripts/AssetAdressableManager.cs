using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAdressableManager : MonoBehaviour
{
    //AssetReference는 특정 타입을 지정하지 않고 어드레서블 리소스를 참조한다.
    //AssetReferenceGameObject는 어드레서블 리소스 중에서 GameObject에 해당하는 값을 참조한다.
    //AssetReferenceT는 제네릭을 통해 특정 형태의 어드레서블 리소스를 참조한다.
    public AssetReferenceGameObject capsule;

    public GameObject go = new GameObject();

    private void Start()
    {
        StartCoroutine("Init");
    }

    IEnumerator Init() { 
        var init = Addressables.InitializeAsync();
        yield return init;
    }


    public void OnCreateButtonEnter() {

        capsule.InstantiateAsync().Completed += (obj) =>
        {
            go = obj.Result;
        };
    }

    public void OnReleaseButtonEnter()
    {
        Addressables.ReleaseInstance(go); //해제
    }

}
