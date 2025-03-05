using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


//입력이나 다른 이벤트를 처리한다.
//현재 게임 오브젝트에 다른 컴포넌트에 명령을 내린다.
//사용자 컴포넌트는 한가지 일만 해야 된다.
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
        //velocity => vector 크기랑 방향
        //s = v * t => speed * direction * time 

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");


        //로컬좌표계, 월드 좌표계
        //세상의 위방향
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
