using Unity.Netcode;
using UnityEngine;

public class NetworkUIManager : MonoBehaviour
{
    public void OnClickStartHost() { 
        NetworkManager.Singleton.StartHost();
        gameObject.SetActive(false);
    }

    public void OnClickStartClient()
    {
        NetworkManager.Singleton.StartClient();
        gameObject.SetActive(false);
    }

}
