using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SystemCode : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_InputField descriptionInputField;

    public ItemData itemdata;
    public ItemData inputData;

    public Button saveButton;
    public Button loadButton;
    public Button deleteButton;
    
    
    
    public bool interactable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //이 방식으로 등록한 기능은 유니티 인스펙터에서 보이지 않습니다.
        nameInputField.onEndEdit.AddListener(ValueChanged);
        descriptionInputField.onEndEdit.AddListener(DesValueChanged);
        //버튼의 interactablae 은 사용자와의 상호작용을 제어 하기 위해 사용
        loadButton.interactable = interactable;
    }

    public void Sample() {
        Debug.Log("값이 변경 됬습니다.");
    
    }


    /// <summary>
    /// 작업이 마무리 되었을 때 호출
    /// </summary>
    /// <param name="text"></param>
    void ValueChanged(string text) { 
        Debug.Log($"{text} 입력");
        

       itemdata = new ItemData();

        text = itemdata.getItemName(text);

    }

    void DesValueChanged(string text)
    {
        Debug.Log($"{text} 입력");


        itemdata = new ItemData();

        text = itemdata.getItemDescript(text);
        string test = itemdata.setItemName(nameInputField.text);

        Debug.Log(test);
    }


    public void saveData() {


        itemdata = new ItemData();
        string name = itemdata.setItemName(nameInputField.text);
        string desc = itemdata.setItemDes(descriptionInputField.text);

        itemdata = new ItemData(name, desc);
    
       
        PlayerPrefs.Save();
    }

}
