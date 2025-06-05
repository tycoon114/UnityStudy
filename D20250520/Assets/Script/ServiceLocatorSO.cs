using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "ServiceLocatorSO", menuName = "Scriptable Objects/ServiceLocatorSO")]
public class ServiceLocatorSO : ScriptableObject
{
    [SerializeField] private string _userInventotyPath;
    public IInventoryService InventoryService { get; private set; }

    public void Bootstrap()
    { 
        string path = Path.Combine
    }

}
