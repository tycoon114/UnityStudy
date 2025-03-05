using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


//�Է��̳� �ٸ� �̺�Ʈ�� ó���Ѵ�.
//���� ���� ������Ʈ�� �ٸ� ������Ʈ�� ����� ������.
//����� ������Ʈ�� �Ѱ��� �ϸ� �ؾ� �ȴ�.
public class PlayerController : MonoBehaviour
{
    MeshRenderer meshRenderer;

    public GameObject missile;

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;

    public Transform[] shootPoint;


    void Awake()
    {
        shootPoint = GameObject.Find("ShootPoint").GetComponentsInChildren<Transform>();
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
        transform.position += transform.up * v * Time.deltaTime * moveSpeed;
        //transform.Translate(new Vector3(h,v,0).normalized  * Time.deltaTime * moveSpeed);
        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotationSpeed;

        if (Input.GetButtonDown("Fire1"))
        {
            GameObject gameObj = Instantiate(missile);

            for (int i = 0; i < shootPoint.Length; i++)
            {
                gameObj.transform.position = shootPoint[i].position;
                gameObj.transform.rotation = shootPoint[i].rotation;
            }

        }
    }

}
