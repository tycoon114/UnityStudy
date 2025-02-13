using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetQuest : MonoBehaviour
{
    public TextMeshProUGUI QuestText; // "E를 누르세요" UI


    public RealQuest realQuest;

    private bool isPlayerNear = false;

    void Start()
    {
        QuestText.gameObject.SetActive(false); // 시작 시 숨기기
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestText.gameObject.SetActive(true);
            isPlayerNear = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestText.gameObject.SetActive(false);
            isPlayerNear = false;
        }
    }

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {

            realQuest.ShowQuest(); // 퀘스트 시스템 실행
        }
    }
}
