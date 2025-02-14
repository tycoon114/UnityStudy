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
        //url�� ���� �ؽ��ĸ� ������Ʈ�� ��û
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageURL);
        //������Ʈ �Ϸ� ���
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Debug.Log("����");

            //�ؽ���2D�� UI�� ���� ���� Sprite���·� ����
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f);
            image.sprite = sprite;
        }
        else {
            Debug.LogError("����");
        }
    }

}
