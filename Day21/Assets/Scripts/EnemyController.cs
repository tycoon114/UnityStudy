using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    


    public int hp = 3;
    public float speed = 0.5f;
    public float patternDistance = 4.0f;

    public List<string> animeList = new List<string>
    {"EnemyIdle" ,"EnemyDown", "EnemyUp", "EnemyLeft","EnemyRight","EnemyDead" };

    string current = "";
    string previous = "";

    float h, v;

    public float z = -90.0f;

    Rigidbody2D rBody;

    bool isActive = false;
    public int arrangeId = 0;


    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            if (isActive)
            {
                float dx = player.transform.position.x - transform.position.x;
                float dy = player.transform.position.y - transform.position.y;
                float radian = Mathf.Atan2(dy, dx);
                float degree = radian * Mathf.Deg2Rad;

                if (degree > -45.0f && degree <= 45.0f)
                {
                    current = animeList[4]; //right
                }
                else if (degree > 45.0f && degree <= 135.0f)
                {
                    current = animeList[2]; //up
                }
                else if (degree > 135.0f && degree <= -45.0f)
                {
                    current = animeList[1]; //
                }
                else
                {
                    current = animeList[3]; //left
                }

                h = Mathf.Cos(radian) * speed;
                v = Mathf.Sin(radian) * speed;
            }
            else
            {
                float distance = Vector2.Distance(transform.position, player.transform.position);

                if (distance <= patternDistance)
                {
                    isActive = true;
                }

            }
        }
        else if (isActive) { 
            isActive = false;
            rBody.linearVelocity = Vector2.zero;
        }




    }


    private void FixedUpdate()
    {
        if (isActive && hp > 0) {
            rBody.linearVelocity = new Vector2(h, v);

            if (current != previous) { 
                previous = current;
                var animator = GetComponent<Animator>();
                animator.Play(current);

            }

        
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arrow") {
            hp--;
            if (hp == 0) { 
                GetComponent<CircleCollider2D>().enabled = false;
                rBody.linearVelocity = new Vector2(0, 0);

                var animator = (GetComponent<Animator>());
                animator.Play(animeList[5]);
                Destroy(gameObject, 0.5f);
            }
        }
    }

}
