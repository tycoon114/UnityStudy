using UnityEngine;

public class Door : MonoBehaviour
{
    public int arrangeId = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ItemKeeper.hasKeys > 0)
        {
            ItemKeeper.hasKeys--;
            Destroy(gameObject);
        }
        else {
            Debug.Log("¿­¼è ¾øÀ½");
        
        }
    }

}
