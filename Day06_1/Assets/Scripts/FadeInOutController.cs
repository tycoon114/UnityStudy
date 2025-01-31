using System.Collections;
using UnityEngine;

public class FadeInOutController : MonoBehaviour
{
    Renderer MyRend;
    void Start()
    {
        MyRend = gameObject.GetComponent<Renderer>();   
    }

    public void fIn() {
        StartCoroutine("fadeIn");
    }

    public void fOut() {
        StartCoroutine("fadeOut");
    }

    IEnumerator fadeIn() {
        float f = 0;
        while (f <=1)
        {
            f += 0.1f;

            Color ColorAlpha = MyRend.material.color;
            ColorAlpha.a = f;
            MyRend.material.color = ColorAlpha;
            yield return new WaitForSeconds(0.02f);

           
        }
        Debug.Log("In");

    }

    IEnumerator fadeOut()
    {
        float f = 1.0f;
        while (f > 0) {
            f -= 0.1f;

            Color ColorAlpha = MyRend.material.color;
            ColorAlpha.a = f;
            MyRend.material.color = ColorAlpha;
            yield return new WaitForSeconds(0.02f);
        }
        Debug.Log("Out");
    }

}
