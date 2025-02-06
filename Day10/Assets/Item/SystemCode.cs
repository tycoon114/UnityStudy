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
        //�� ������� ����� ����� ����Ƽ �ν����Ϳ��� ������ �ʽ��ϴ�.
        nameInputField.onEndEdit.AddListener(ValueChanged);
        descriptionInputField.onEndEdit.AddListener(DesValueChanged);
        //��ư�� interactablae �� ����ڿ��� ��ȣ�ۿ��� ���� �ϱ� ���� ���
        loadButton.interactable = interactable;
    }

    public void Sample() {
        Debug.Log("���� ���� ����ϴ�.");
    
    }


    /// <summary>
    /// �۾��� ������ �Ǿ��� �� ȣ��
    /// </summary>
    /// <param name="text"></param>
    void ValueChanged(string text) { 
        Debug.Log($"{text} �Է�");
        

       itemdata = new ItemData();

        text = itemdata.getItemName(text);

    }

    void DesValueChanged(string text)
    {
        Debug.Log($"{text} �Է�");


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
