using UnityEngine;
using UnityEngine.EventSystems;



public class UinterSample : MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ŭ���� �����g���ϴ�.");
    }
}
