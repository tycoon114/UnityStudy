using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DataStructureSample : MonoBehaviour
{

    //스티링 형태만 등록가능한 큐
    public Queue<string> StringQueue = new Queue<string>();

    private void Start()
    {
        //1) 큐에 데이터 추가
        StringQueue.Enqueue("퀘스트 1 등록");
        StringQueue.Enqueue("퀘스트 2 등록");
        StringQueue.Enqueue("퀘스트 3 등록");
        StringQueue.Enqueue("퀘스트 4 등록");
        StringQueue.Enqueue("퀘스트 5 등록");

        foreach (string dialog in StringQueue) {

            Debug.Log(StringQueue.Peek()); // 현재 큐에 저장된 가장 맨 앞의 값을 리턴
        }
        Debug.Log(StringQueue.Dequeue()); // 추가적으로 맨 앞의 값을 제거
        Debug.Log(StringQueue.Dequeue()); 
        Debug.Log(StringQueue.Dequeue()); 
        Debug.Log(StringQueue.Dequeue()); 
        Debug.Log(StringQueue.Dequeue()); 


    }

}




