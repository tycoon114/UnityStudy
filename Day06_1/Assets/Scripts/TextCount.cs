using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextCount : MonoBehaviour
{

    public Text countText;

    public int count = 1;

    void Start()
    {
        //�ڷ�ƾ ��� ���
        //StartCoroutine("�Լ� �̸� ( IEnumertator ������ �Լ�)")
        // 1. ���ڿ��� ���� �ش� �Լ��� ã�Ƽ� ����
        // ��Ÿ�� �־ ������ �߻����� ����

        //�ش� �ڷ�ƾ ���� ���� ����
        StartCoroutine("CountPlus");
        //StopCoroutine("CountPlus");

        // 2. �ش� �Լ��� ȣ���� ���� ����� ��ȯ�޴� ����, ��Ÿ �߻��� ���� üũ ����
        //�Լ� ���� ���� ���, �� ������δ� StopCoroutine �� ���� �ܺο����� ��������� ��� �� �� ����
        //StartCoroutine(CountPlus());


    }

    IEnumerator CountPlus() 
    {

        while (true) {
            count++;
            countText.text = count.ToString("N0");
            //N0�� ����3�ڸ� �������� , �� ǥ���ϴ� ����
            yield return null;

        }

        /*        Debug.Log("AAAA");

                yield return new WaitForSeconds(1);
                //yeild �� �Ͻ������� CPU�� ������ �ٸ��Լ��� �����ϴ� Ű����
                Debug.Log("BBBB");
                yield return new WaitForSeconds(5);
                Debug.Log("CCCC");
        */



    }

}
