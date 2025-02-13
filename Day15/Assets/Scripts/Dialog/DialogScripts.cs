using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DialogScripts : MonoBehaviour
{

    public Queue<string> dialpgQueue = new Queue<string>();

    void Start()
    {
        dialpgQueue.Enqueue("퀘스트 1 등록");
        dialpgQueue.Enqueue("퀘스트 2 등록");
        dialpgQueue.Enqueue("퀘스트 3 등록");
        dialpgQueue.Enqueue("퀘스트 4 등록");
        dialpgQueue.Enqueue("퀘스트 5 등록");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
