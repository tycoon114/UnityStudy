using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Animator animator;

    private bool isAttacking = false;

    [Header("애니메이션 현재 상태")]
    public string aaaa = "asdf";


    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    public void PerformAttack() {

        if (playerAnimation != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerAnimation.TriggerAttack();
            }
        }
    }

    void Update()
    {
        
    }
}
