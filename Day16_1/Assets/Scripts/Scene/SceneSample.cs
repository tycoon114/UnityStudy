using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    //����Ƽ ������ ����Ŭ
    //����Ƽ������ ���� �ܰ���� ���� �ܰ������ �Լ��� ����
    //Awake,
    private void OnEnable()
    {
        Debug.Log("OnSceneLoaded Ȱ��ȭ");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Debug.Log("OnSceneLoaded ��Ȱ��ȭ");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"���� �ε�� �� {scene.name}  ");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            SceneManager.LoadScene("BRP Sample Scene");
        }
        if (Input.GetKeyDown(KeyCode.I)) 
        {
            SceneManager.LoadScene("BRP Sample Scene", LoadSceneMode.Additive);
        }
        if (Input.GetKeyDown(KeyCode.O)) 
        {
            StartCoroutine("LoadSceneC");
            //SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
        }
    }

    IEnumerator LoadSceneC() 
    { 
        yield return SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
    }

}
