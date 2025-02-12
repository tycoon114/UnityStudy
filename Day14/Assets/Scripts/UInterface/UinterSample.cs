using UnityEngine;
using UnityEngine.EventSystems;



public class UinterSample : MonoBehaviour , IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("클릭을 진행헸습니다.");
    }
}
