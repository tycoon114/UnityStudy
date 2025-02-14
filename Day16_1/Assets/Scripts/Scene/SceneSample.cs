using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    //유니티 라이프 사이클
    //유니티에서는 시작 단계부터 종료 단계까지를 함수로 제공
    //Awake,
    private void OnEnable()
    {
        Debug.Log("OnSceneLoaded 활성화");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        Debug.Log("OnSceneLoaded 비활성화");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"현재 로드된 씬 {scene.name}  ");
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
