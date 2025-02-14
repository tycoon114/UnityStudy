using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class GoogleDriveAssetBundle : MonoBehaviour
{
    
    private string imageURL = "https://docs.google.com/uc?export=download&id=11uC-yq9pXuM7daNuRp7inK1H5MkQN6SA";

    public Image image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("DownLoadImage");
    }

    IEnumerator DownLoadImage() { 
        //url을 통해 텍스쳐를 리퀘스트를 요청
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURL);
        //리퀘스트 완료 대기
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Debug.Log("성공");

            //텍스쳐2D를 UI에 쓰기 위해 Sprite형태로 변경
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            image.sprite = sprite;
        }
        else {
            Debug.LogError("실패");
        }
    }

}
