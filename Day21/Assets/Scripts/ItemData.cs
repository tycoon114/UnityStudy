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
            //아이템 획득 연출
            //1. 아이템이 공통적으로 가지고 있는 콜라이더 비활성화
            GetComponent<CircleCollider2D>().enabled = false;
            //2. 아이템이 공통적으로 가지고 있는 리지드바디를 통해 튀어 오르는 연출 표현
            var itemRBody = GetComponent<Rigidbody2D>();
            itemRBody.gravityScale = 2.0f;
            itemRBody.AddForce(new Vector2(0, 0), ForceMode2D.Impulse);
            Destroy(gameObject, 0.5f);


        }
    }
}
