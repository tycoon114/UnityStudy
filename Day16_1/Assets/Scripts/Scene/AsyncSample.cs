using System.Threading.Tasks;
using UnityEngine;

public class AsyncSample : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("�۾��� ����");
        Sample1();
        Debug.Log("���μ��� 1 ");
    }

    private async void Sample1() 
    {
        Debug.Log("���μ��� 2");
        await Task.Delay(5000);
        Debug.Log(" ���μ��� 3");
    }

}
