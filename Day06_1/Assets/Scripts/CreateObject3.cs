using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject prefab;
    // [SerializeField]
    // ����ȭ , Ư�� �����ͳ� ������Ʈ�� �籸�� �� �� �ִ� ����(����)���� ��ȯ �ϴ� ���� 
    //����Ƽ������ �����ϰ� private ������ �����͸� �ν����Ϳ��� ���� �� �ְ� ���� 

    GameObject sample;

    private void Start()
    {
        prefab = Resources.Load<GameObject>("Prefabs/table");
        //Resources.Load<T>("������ġ/���¸�")
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
           
            
            sample = Instantiate(prefab);
            sample.AddComponent<VectorSample>();

            //AddComponent ������Ʈ�� ������Ʈ ��� �߰�
            //GetComponent ��ũ��Ʈ���� �ش� ������Ʈ ����� �����ͼ� ���
        }
    }

}
