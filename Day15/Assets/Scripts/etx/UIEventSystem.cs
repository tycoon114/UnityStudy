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

        dialpgQueue.Enqueue("����Ʈ 1 ���");
        dialpgQueue.Enqueue("����Ʈ 2 ���");
        dialpgQueue.Enqueue("����Ʈ 3 ���");
        dialpgQueue.Enqueue("����Ʈ 4 ���");
        dialpgQueue.Enqueue("����Ʈ 5 ���");

    }


    public void SetText() {

        dialogText.GetComponent<TextMeshProUGUI>().text = dialpgQueue.Peek();
        dialpgQueue.Dequeue();
    }

}
