using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    private Color originalColor;
    private Renderer objectRenderer;
    public float colorChangeDuration = 0.5f;
    private float tutorialEnemyHp = 10.0f;


    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            StartCoroutine(ChangeColorTemporatily());
        }
    }

    IEnumerator ChangeColorTemporatily()
    {
        SoundManager.Instance.PlaySFX(SFXType.SFX_Hit);
        objectRenderer.material.color = Color.red;
        yield return new WaitForSeconds(colorChangeDuration);
        objectRenderer.material.color = originalColor;
    }

}
