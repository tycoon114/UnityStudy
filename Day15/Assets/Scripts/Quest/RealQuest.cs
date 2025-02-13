using UnityEngine.UI;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;

public class RealQuest :MonoBehaviour
{
    public TextMeshProUGUI QuestContext;
    public GameObject QuestPanel;
    public Button NextButton;
    public RawImage NpcImage;
    public Button YesButton;

    public Queue<string> QuestDialog = new Queue<string>();

    public Queue<string> YourDialog = new Queue<string>();



    private void Start()
    {

        QuestPanel.gameObject.SetActive(false);
        QuestContext.gameObject.SetActive(false);
        NpcImage.gameObject.SetActive(false);
        NextButton.gameObject.SetActive(false);
        YesButton.gameObject.SetActive(false);


        QuestDialog.Enqueue("Äù½ºÆ® 1 µî·Ï");
        QuestDialog.Enqueue("Äù½ºÆ® 2 µî·Ï");

    }

    public void ShowQuest() {
        QuestPanel.SetActive(true);
        NpcImage.gameObject.SetActive(true);
        NextButton.gameObject.SetActive(true);
        QuestContext.gameObject.SetActive(true);
        
    }

    public void OnButtonClick() {


        QuestContext.GetComponent<TextMeshProUGUI>().text = QuestDialog.Peek();
        QuestDialog.Dequeue();

        if (QuestDialog.Count == 0)
        {
            NextButton.interactable = false;
            YesButton.gameObject.SetActive(true);
        }
    }



}
