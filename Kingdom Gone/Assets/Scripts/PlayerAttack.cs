using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Animator animator;

    private bool isAttacking = false;

    [Header("�ִϸ��̼� ���� ����")]
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
