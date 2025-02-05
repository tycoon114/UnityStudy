using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    GameObject objectGenerator;
    // �߻� ����� ���� 
    //�浹 �� ������Ʈ�� �������� �ִ� ���ҵ� ���� 

    void Start()
    {
        objectGenerator = GameObject.Find("Object Generator");
        //objectGenerator = GameObject.FindWithTag("a");
        //object = FindObjectOfType<ObjectGenerator>();
        //objectGenerator = FindObjectOfType(typeof(ObjectGenerator));

        //Find�� ���� ������ ������ Ŀ���� ���� ���� �߻�, ����� ��Ȳ�� �°� �±׳� Ÿ�Ե����� �˻����� �����ϴ� ��� ���
        //���� �ش簪�� ���ٸ� null

    }

    /// <summary>
    /// ��ü�� �߻��ϴ� ����� ���� �Լ� (�޼ҵ�)
    /// </summary>
    /// <param name="directiion"> ��ü�� �߻� ���� </param>

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
