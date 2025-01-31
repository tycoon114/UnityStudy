using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour
{
    public Text message;
    [SerializeField][TextArea]private string context;
    [SerializeField] private float delay = 0.2f; //읽는 속도

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnMessageButtonClick() {
        StartCoroutine("Typing");
    }

    public void ByTwo() {
        if (delay == 0.2f)
        {
            delay = 0.1f;
        }
        else {
            delay = 0.2f;
        }
    }

    IEnumerator Typing() {

        message.text = "";

        int typingCount = 0;


        while (typingCount != context.Length) {

            if (typingCount < context.Length) {
                message.text += context[typingCount].ToString();
                typingCount++;
             }
            yield return new WaitForSeconds(delay);
        }

        
    }
}
