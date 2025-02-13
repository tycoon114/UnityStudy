using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEventSystem : MonoBehaviour
{
    GameObject dialogText;
    public Button nextButton;
    DialogScripts dialogScripts;

    public Queue<string> dialpgQueue = new Queue<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogText = GameObject.Find("Dialog Text");

        dialpgQueue.Enqueue("퀘스트 1 등록");
        dialpgQueue.Enqueue("퀘스트 2 등록");
        dialpgQueue.Enqueue("퀘스트 3 등록");
        dialpgQueue.Enqueue("퀘스트 4 등록");
        dialpgQueue.Enqueue("퀘스트 5 등록");

    }


    public void SetText() {

        dialogText.GetComponent<TextMeshProUGUI>().text = dialpgQueue.Peek();
        dialpgQueue.Dequeue();
    }

}
