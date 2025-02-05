using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    GameObject objectGenerator;
    // 발사 기능을 제공 
    //충돌 시 오브젝트를 고정시켜 주는 역할도 진행 

    void Start()
    {
        objectGenerator = GameObject.Find("Object Generator");
        //objectGenerator = GameObject.FindWithTag("a");
        //object = FindObjectOfType<ObjectGenerator>();
        //objectGenerator = FindObjectOfType(typeof(ObjectGenerator));

        //Find가 가장 쉽지만 범위가 커지면 성능 저하 발생, 따라사 상황에 맞게 태그나 타입등으로 검색범위 제한하는 방식 사용
        //씬에 해당값이 없다면 null

    }

    /// <summary>
    /// 물체를 발사하는 기능을 가진 함수 (메소드)
    /// </summary>
    /// <param name="directiion"> 물체의 발사 방향 </param>

    public void Shoot(Vector3 directiion)
    {
        GetComponent<Rigidbody>().AddForce(directiion);
        Debug.Log("HIT");

    }


    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        
        GetComponentInChildren<ParticleSystem>().Play();

        if (collision.gameObject.tag == "terrain") { 
            Destroy(gameObject, 1.0f);
        }else if(collision.gameObject.tag == "target")
        {
            objectGenerator.GetComponent<ObjectGenerator>().ScorePlus(10);
            Destroy(gameObject, 1.5f);
        }

    }
}
