using UnityEngine;

//�Է��̳� �ٸ� �̺�Ʈ�� ó���Ѵ�.
//���� ���� ������Ʈ�� �ٸ� ������Ʈ�� ����� ������.
//����� ������Ʈ�� �Ѱ��� �ϸ� �ؾ� �ȴ�.
public class PlayerControlller : MonoBehaviour
{

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;

    MeshRenderer meshRenderer;
    //Transform myTransform;
    void Awake()
    {
        //�������ڸ��� ������Ʈ ã��, �Ź� ã�°� ���� �������� ���� 1���� ã�°� ������ ���� ����
        //������ transform ������Ʈ�� ã�� �ʿ� ����. �ٸ� ������Ʈ�� ��� �̷������� �ϸ�ȴ�

        meshRenderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //velocity => vector ũ��� ����
        //s = v*t => speed * direction * time
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //transform.position +=  transform.up * v * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed);

        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotationSpeed;


        ////������ �ִ� ����
        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
        //}
        //else if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        //}


    }
}
