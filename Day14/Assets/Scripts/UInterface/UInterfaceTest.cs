using UnityEngine;
using UnityEngine.EventSystems;

public class UInterfaceTest : MonoBehaviour, IDragHandler , IPointerClickHandler 
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbody 가져오기
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 forceDirection = new Vector3(0, 5, 0);
        rb.AddForce(forceDirection, ForceMode.Impulse);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector3 forceDirection = new Vector3(0, 5, 10);
        rb.AddForce(forceDirection, ForceMode.Impulse);
    }
}
