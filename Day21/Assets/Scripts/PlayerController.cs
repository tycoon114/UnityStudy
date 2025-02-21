using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3.0f;

    public List<string> animeList = new List<string>
    {"PlayerDown", "PlayerUp", "PlayerLeft","PlayerRight","PlayerDead" };

    string current ="";
    string previous = "";

    float h, v;

    public float z = -90.0f;

    Rigidbody2D rBody;
    Animator animator;

    bool isMove = false;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        previous = animeList[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove == false) {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

        }

        Vector2 from = transform.position;
        Vector2 to = new Vector2(from.x + h, from.y + v);

        z = GetAngle(from, to);
        //������ ���� ����� �ִϸ��̼� ����
        //{"PlayerDown", "PlayerUp", "PlayerLeft","PlayerRight","PlayerDead"
        if (z >= -45 && z < 45)
        {
            //������
            current = animeList[3];
        }
        else if (z >= 45 && z <= 135)
        {
            //����
            current = animeList[1];
        }
        else if (z >= -135 && z <= -45)
        {
            //�Ʒ���
            current = animeList[0];
        }
        else
        {
            //����
            current = animeList[2];
        }

        if (current != previous)
        {
            previous = current;
            animator.Play(current);
        }
    }

    private void FixedUpdate() {
        rBody.linearVelocity = new Vector2(h, v) * speed;
    }


    /// <summary>
    /// from���� to ������ ���� ���
    /// </summary>
    /// <param name="from">������ġ A</param>
    /// <param name="to">������ ��ġ B</param>
    private float GetAngle(Vector2 from, Vector2 to)
    {
        float angle;
        if (h != 0 || v != 0)
        {
            //from�� to�� ���̸� ���
            float dx = to.x - from.x;
            float dy = to.y - from.y;

            float radian = Mathf.Atan2(dy, dx);
            angle = radian * Mathf.Rad2Deg;
        }
        else {
            angle = z;
        }
        return angle;

    }
}
