using System.Collections;
using UnityEngine;


public enum ItemType
{
    Arrows, Key, Life
}
public class ItemData : MonoBehaviour
{
    public ItemType type;
    public int count = 1;
    public int arrangeId = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (type)
            {
                case ItemType.Arrows:
                    ArrowShoot shoot = collision.gameObject.GetComponent<ArrowShoot>();
                    ItemKeeper.hasArrows += count;
                    break;
                case ItemType.Key:
                    ItemKeeper.hasKeys += count;
                    break;
                case ItemType.Life:
                    if (PlayerController.hp < 3)
                    {
                        PlayerController.hp++;
                    }
                    break;
            }
            //������ ȹ�� ����
            //1. �������� ���������� ������ �ִ� �ݶ��̴� ��Ȱ��ȭ
            GetComponent<CircleCollider2D>().enabled = false;
            //2. �������� ���������� ������ �ִ� ������ٵ� ���� Ƣ�� ������ ���� ǥ��
            var itemRBody = GetComponent<Rigidbody2D>();
            itemRBody.gravityScale = 2.0f;
            itemRBody.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);


        }
    }
}
