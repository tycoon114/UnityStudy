using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class VectorSample2 : MonoBehaviour
{



    void Start()
    {
        // 1. Nomalization (����ȭ) ������ ũ�⸦ 1�� ����
        //      ���� ������ ������ ũ�⸸ 1�� ����, ũ�⸦ 1�� �����ϸ� ������ ���⸸ ����ϸ� ���� ������ ó���ϱ� ���� ������ ���
        //      ���� ��� �Է����� ĳ������ 3D �̵� ���� �� �̵��� �밢�� ���, �Ϲ����� ���� ���⺸�� �̵��ӵ��� �� ���� ��Ȳ�� �߻� �� �� ����
        Vector3 a = new Vector3(1, 2, 0);
        Vector3 nomalizA = a.normalized;

        // 2. �� ���� ������ �Ÿ� ��� 
        Vector3 positionA = new Vector3(1, 2, 3);
        Vector3 positoinB = new Vector3(4, 5, 6);

        float distance = Vector3.Distance(positionA, positoinB);

        // 3. ���� ����(Linear Interpolation) ->Lerp
        //   ������ ���� �����Ǿ�����, �� ���̿� ��ġ�� ���� �����ϱ� ���� �����Ÿ��� ���� ���������� ����ϴ� ���
        Vector3 Result = Vector3.Lerp(positionA, positoinB, 0.5f);

    }

}
