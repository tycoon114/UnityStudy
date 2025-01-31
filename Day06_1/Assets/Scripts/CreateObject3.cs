using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject prefab;
    // [SerializeField]
    // 직렬화 , 특정 데이터나 오브젝트를 재구성 할 수 있는 형태(포맷)으로 변환 하는 과정 
    //유니티에서는 간단하게 private 형태의 데이터를 인스펙터에서 읽을 수 있게 설정 

    GameObject sample;

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/table");
        //Resources.Load<T>("폴더위치/에셋명")
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
           
            
            sample = Instantiate(prefab);
            sample.AddComponent<VectorSample>();

            //AddComponent 오브젝트에 컴포넌트 기능 추가
            //GetComponent 스크립트에서 해당 컴포넌트 기능을 가져와서 사용
        }
    }

}
