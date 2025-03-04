using UnityEngine;

//입력이나 다른 이벤트를 처리한다.
//현재 게임 오브젝트에 다른 컴포넌트에 명령을 내린다.
//사용자 컴포넌트는 한가지 일만 해야 된다.
public class PlayerControlller : MonoBehaviour
{

    float moveSpeed = 3.0f;
    float rotationSpeed = 60.0f;

    MeshRenderer meshRenderer;
    //Transform myTransform;
    void Awake()
    {
        //시작하자마자 컴포넌트 찾기, 매번 찾는것 보다 시작하자 마자 1번만 찾는게 성능이 좋기 때문
        //하지만 transform 컴포넌트는 찾을 필요 없다. 다른 컴포넌트일 경우 이런식으로 하면된다

        meshRenderer = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //velocity => vector 크기랑 방향
        //s = v*t => speed * direction * time
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");


        //transform.position +=  transform.up * v * Time.deltaTime * moveSpeed;
        transform.Translate(Vector3.up * v * Time.deltaTime * moveSpeed);

        transform.eulerAngles += transform.forward * -h * Time.deltaTime * rotationSpeed;


        ////누르고 있는 동안
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
