using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class DialogScripts : MonoBehaviour
{

    public Queue<string> dialpgQueue = new Queue<string>();

    void Start()
    {
        dialpgQueue.Enqueue("����Ʈ 1 ���");
        dialpgQueue.Enqueue("����Ʈ 2 ���");
        dialpgQueue.Enqueue("����Ʈ 3 ���");
        dialpgQueue.Enqueue("����Ʈ 4 ���");
        dialpgQueue.Enqueue("����Ʈ 5 ���");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
