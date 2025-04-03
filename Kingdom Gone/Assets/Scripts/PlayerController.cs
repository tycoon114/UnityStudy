using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private PlayerMovement movement;
    private PlayerAttack attack;
    private PlayerHealth health;

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        attack = GetComponent<PlayerAttack>();
        health = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        movement.HandleMovement();
        attack.PerformAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GameManager.Instance.AddCoin(10);
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("DeathZone"))
        {

        }
    }
}
