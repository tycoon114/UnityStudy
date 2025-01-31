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

    //유니티 기본 벡터(제공 값)
    //Vector3 a = Vector3.up ->  (0,1,0), down (0,-1,0). left(-1,0,0) right(1,0,0), forward(0,0,1) ,back (0,0,-1) one (1,1,1) zero(0,0,0)

    // 벡터 기본 연산 (덧셈, 뺄셈, 나눗셈, 곱셈)
    Vector3 a = new Vector3(1, 2, 0);
    Vector3 b = new Vector3(3, 4, 0);

    Vector3 some =  Vector3.zero;

    Vector3 aSite = new Vector3(10, 0, 0);
    Vector3 bSite = new Vector3(5, 0, 0);

    void Start()
    {
        //덧셈 - 단계적으로 하나씩 차례대로 처리, 순서가 변경되어도 결과는 같다. 특정 포지션에서 점프한 느낌의 계산 처리
        Vector3 c = a + b;
        var trapAir = some + new Vector3(0, point);

        //뺄셈 - 한 오브젝트에서 다른 오브젝트까지의 거리와 방향을 구하는 상황에 사용, 순서가 중요함
        Vector3 distance = aSite - bSite;
        //거리를 측정 후 지정한 거리와 같거나 가깝다면 공격하라 같은 코드를 생성 할 수 있다.

        //곱셈 - 벡터의 각 성분에 스칼라 값을 곱한다. 벡터 * 스칼라 -> 원본과 동일한 방향을 그르키는 벡터. 방향자체에는 영향을 안주고 벡터의 크기를 변경하는 경우 사용
        Vector3 e = a * 2;

        //나눗셈 - 
        Vector3 posF = Vector3.one;
        posF = posF / 4;

        //내적과 외적
        // 내적 : 2, 3D 모두 가능, 두 벡터의 성분을 곱하고 그 결과를 모두 더하는 연산 방식
        //각 좌표가 얼마나 평행한지 판단합니다. 두 벡터 사이의 각도
        Vector3 k = new Vector3(1, 2, 3);
        Vector3 l = new Vector3(4, 5, 0);

        float dot = Vector3.Dot(k, l);
        // k *l = (kx *lx) + (ky* ly) +(kz *lz);

        //외적 : 3D에서 사용 (3D 그래픽)
        //법선 벡터 계산시에 사용된다. (법선은 평면이나 직선에 대해 수직인 것을 의미)
        Vector3 cross = Vector3.Cross(k, l);


        //벡터의 크기( 벡터의 길이), 벡터의 각 성분의 제곱의 합의 제곱근
        Vector3 m = new Vector3(1, 2, 3);

        float mag = m.magnitude;




    }

}
