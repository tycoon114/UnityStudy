using UnityEngine;


//�Է��̳� �ٸ� �̺�Ʈ�� ó���Ѵ�.
//���� ���� ������Ʈ�� �ٸ� ������Ʈ�� ����� ������.
//����� ������Ʈ�� �Ѱ��� �ϸ� �ؾ� �ȴ�.
public class PlayerController11 : MonoBehaviour
{
    MeshRenderer meshRenderer;

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;


    void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        //velocity => vector ũ��� ����
        //s = v * t => speed * direction * time 

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


        //������ǥ��, ���� ��ǥ��
        //������ ������
        //transform.position += transform.up * v * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed);
        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotationSpeed;
    }
}
