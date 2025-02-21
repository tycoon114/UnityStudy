using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static int hp = 3;
    static bool inDamage = false;
    string state;

    public float speed = 3.0f;

    public List<string> animeList = new List<string>
    { "PlayerDown", "PlayerUp", "PlayerLeft","PlayerRight","PlayerDead" };

    string current = "";
    string previous = "";

    float h, v;

    public float z = -90.0f;

    Rigidbody2D rBody;
    Animator animator;

    bool isMove = false;

    void Start()
    {
        state = "playing";
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        previous = animeList[0];
    }

    // Update is called once per frame
    void Update()
    {

        if (state != "playing" || inDamage)
        {
            return;
        }




        if (isMove == false)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

        }

        Vector2 from = transform.position;
        Vector2 to = new Vector2(from.x + h, from.y + v);

        z = GetAngle(from, to);
        //각도에 따라 방향과 애니메이션 설정
        //{"PlayerDown", "PlayerUp", "PlayerLeft","PlayerRight","PlayerDead"
        if (z > -45 && z <= 45)
        {
            //오른쪽
            current = animeList[3];
        }
        else if (z > 45 && z <= 135)
        {
            //위쪽
            current = animeList[1];
        }
        else if (z > 135 && z <= -45)
        {
            //아래쪽
            current = animeList[0];
        }
        else
        {
            //왼쪽
            current = animeList[2];
        }

        if (current != previous)
        {
            previous = current;
            animator.Play(current);
        }
    }

    private void FixedUpdate()
    {

        if (state != "playing" || inDamage)
        {
            return;
        }

        if (inDamage)
        {
            float value = MathF.Sin(Time.time * 50);
            if (value > 0)
            {
                GetComponent<SpriteRenderer>().enabled = true;
            }
            else {
                GetComponent<SpriteRenderer>().enabled = false;
            }
            return;
        }

        rBody.linearVelocity = new Vector2(h, v) * speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") { 
            GetDamage(collision.gameObject);
        }
    }

    private void GetDamage(GameObject enemy)
    {
        if (state == "playing") {
            hp--;
            if (hp > 0)
            {
                rBody.linearVelocity = new Vector2(0, 0);

                Vector3 to = (transform.position - enemy.transform.position).normalized;
                rBody.AddForce(new Vector2(to.x * 4, to.y * 4), ForceMode2D.Impulse);
                inDamage = true;

                Invoke("OnDamageExit", 0.25f);
            }
            else {
                GameOver();
            }
        
        }
    }

    public void OnDamageExit() { 
        inDamage = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    private void GameOver()
    {
        state = "gameover";
        GetComponent<CircleCollider2D>().enabled = false;
        rBody.linearVelocity = new Vector2(0, 0);
        rBody.gravityScale = 1;
        rBody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        GetComponent<Animator>().Play(animeList[4]);
        Destroy(gameObject, 1.0f);

    }


    /// <summary>
    /// from에서 to 까지의 각도 계산
    /// </summary>
    /// <param name="from">시작위치 A</param>
    /// <param name="to">마무리 위치 B</param>
    private float GetAngle(Vector2 from, Vector2 to)
    {
        float angle;
        if (h != 0 || v != 0)
        {
            //from과 to의 차이를 계산
            float dx = to.x - from.x;
            float dy = to.y - from.y;

            float radian = Mathf.Atan2(dy, dx);
            angle = radian * Mathf.Rad2Deg;
        }
        else
        {
            angle = z;
        }
        return angle;

    }
}
