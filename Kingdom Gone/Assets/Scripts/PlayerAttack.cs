using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Animator animator;

    private GameObject gunFire;

    private bool isAttacking = false;

    [Header("애니메이션 현재 상태")]
    public string aaaa = "asdf";


    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        //여기서 자식 컴포넌트의 gunFire 가져오기
    }

    public void PerformAttack() {

        if (playerAnimation != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerAnimation.TriggerAttack();
                //한번에 5발씩 나가고, 1~2초후 다시 총알이 나가도록
                //우선은 무언가에 닿으면 파괴되도록


            }
        }
    }

    void Update()
    {
        
    }
}
