using System.Threading.Tasks;
using UnityEngine;

public class AsyncSample : MonoBehaviour
{
    
    void Start()
    {
        Debug.Log("작업을 시작");
        Sample1();
        Debug.Log("프로세스 1 ");
    }

    private async void Sample1() 
    {
        Debug.Log("프로세스 2");
        await Task.Delay(5000);
        Debug.Log(" 프로세스 3");
    }

}
