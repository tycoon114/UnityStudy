using Unity.VisualScripting;
using UnityEngine;

public class VectorSample : MonoBehaviour
{

    Vector3 vec = new Vector3();

    float x = 1.0f;
    float y = 1.0f;
    float z = 1.0f;

    float point = 5.0f;

    float attackPosition = 5.0f;

    //Vector3 custom_vec = new Vector3(x,y,z);

    //����Ƽ �⺻ ����(���� ��)
    //Vector3 a = Vector3.up ->  (0,1,0), down (0,-1,0). left(-1,0,0) right(1,0,0), forward(0,0,1) ,back (0,0,-1) one (1,1,1) zero(0,0,0)

    // ���� �⺻ ���� (����, ����, ������, ����)
    Vector3 a = new Vector3(1, 2, 0);
    Vector3 b = new Vector3(3, 4, 0);

    Vector3 some =  Vector3.zero;

    Vector3 aSite = new Vector3(10, 0, 0);
    Vector3 bSite = new Vector3(5, 0, 0);

    void Start()
    {
        //���� - �ܰ������� �ϳ��� ���ʴ�� ó��, ������ ����Ǿ ����� ����. Ư�� �����ǿ��� ������ ������ ��� ó��
        Vector3 c = a + b;
        var trapAir = some + new Vector3(0, point);

        //���� - �� ������Ʈ���� �ٸ� ������Ʈ������ �Ÿ��� ������ ���ϴ� ��Ȳ�� ���, ������ �߿���
        Vector3 distance = aSite - bSite;
        //�Ÿ��� ���� �� ������ �Ÿ��� ���ų� �����ٸ� �����϶� ���� �ڵ带 ���� �� �� �ִ�.

        //���� - ������ �� ���п� ��Į�� ���� ���Ѵ�. ���� * ��Į�� -> ������ ������ ������ �׸�Ű�� ����. ������ü���� ������ ���ְ� ������ ũ�⸦ �����ϴ� ��� ���
        Vector3 e = a * 2;

        //������ - 
        Vector3 posF = Vector3.one;
        posF = posF / 4;

        //������ ����
        // ���� : 2, 3D ��� ����, �� ������ ������ ���ϰ� �� ����� ��� ���ϴ� ���� ���
        //�� ��ǥ�� �󸶳� �������� �Ǵ��մϴ�. �� ���� ������ ����
        Vector3 k = new Vector3(1, 2, 3);
        Vector3 l = new Vector3(4, 5, 0);

        float dot = Vector3.Dot(k, l);
        // k *l = (kx *lx) + (ky* ly) +(kz *lz);

        //���� : 3D���� ��� (3D �׷���)
        //���� ���� ���ÿ� ���ȴ�. (������ ����̳� ������ ���� ������ ���� �ǹ�)
        Vector3 cross = Vector3.Cross(k, l);


        //������ ũ��( ������ ����), ������ �� ������ ������ ���� ������
        Vector3 m = new Vector3(1, 2, 3);

        float mag = m.magnitude;




    }

}
