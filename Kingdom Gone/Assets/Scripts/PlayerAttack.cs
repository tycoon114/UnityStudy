using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimation playerAnimation;
    private Animator animator;

    private GameObject gunFire;

    private bool isAttacking = false;

    [Header("�ִϸ��̼� ���� ����")]
    public string aaaa = "asdf";


    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        //���⼭ �ڽ� ������Ʈ�� gunFire ��������
    }

    public void PerformAttack() {

        if (playerAnimation != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerAnimation.TriggerAttack();
                //�ѹ��� 5�߾� ������, 1~2���� �ٽ� �Ѿ��� ��������
                //�켱�� ���𰡿� ������ �ı��ǵ���


            }
        }
    }

    void Update()
    {
        
    }
}
