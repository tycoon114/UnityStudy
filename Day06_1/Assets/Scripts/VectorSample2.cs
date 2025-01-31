using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class VectorSample2 : MonoBehaviour
{



    void Start()
    {
        // 1. Nomalization (정규화) 벡터의 크기를 1로 설정
        //      같은 방향을 가지되 크기만 1로 설정, 크기를 1로 고정하면 벡터의 방향만 고려하면 다음 연산을 처리하기 쉽기 때문에 사용
        //      예를 들어 입력으로 캐릭터의 3D 이동 진행 시 이동이 대각일 경우, 일반적인 단일 방향보다 이동속도가 더 빠른 상황이 발생 할 수 있음
        Vector3 a = new Vector3(1, 2, 0);
        Vector3 nomalizA = a.normalized;

        // 2. 두 지점 사이의 거리 계산 
        Vector3 positionA = new Vector3(1, 2, 3);
        Vector3 positoinB = new Vector3(4, 5, 6);

        float distance = Vector3.Distance(positionA, positoinB);

        // 3. 선형 보간(Linear Interpolation) ->Lerp
        //   끝점의 값이 제공되었을때, 그 사이에 위치한 값을 추정하기 위해 직선거리에 따라 선형적으로 계산하는 방식
        Vector3 Result = Vector3.Lerp(positionA, positoinB, 0.5f);

    }

}
