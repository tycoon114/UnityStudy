using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DataStructureSample : MonoBehaviour
{

    //��Ƽ�� ���¸� ��ϰ����� ť
    public Queue<string> StringQueue = new Queue<string>();

    private void Start()
    {
        //1) ť�� ������ �߰�
        StringQueue.Enqueue("����Ʈ 1 ���");
        StringQueue.Enqueue("����Ʈ 2 ���");
        StringQueue.Enqueue("����Ʈ 3 ���");
        StringQueue.Enqueue("����Ʈ 4 ���");
        StringQueue.Enqueue("����Ʈ 5 ���");

        foreach (string dialog in StringQueue) {

            Debug.Log(StringQueue.Peek()); // ���� ť�� ����� ���� �� ���� ���� ����
        }
        Debug.Log(StringQueue.Dequeue()); // �߰������� �� ���� ���� ����
        Debug.Log(StringQueue.Dequeue()); 
        Debug.Log(StringQueue.Dequeue()); 
        Debug.Log(StringQueue.Dequeue()); 
        Debug.Log(StringQueue.Dequeue()); 


    }

}




