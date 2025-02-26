using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    Vector3 dir;
    private void Start()
    {
        
        int rand = Random.Range(0, 10);

        if (rand < 3)
        {
            var target = GameObject.FindGameObjectWithTag("Player");

            dir = target.transform.position - transform.position;

            dir.Normalize(); //방향의 크기를 1로 설정
        }
        else {
            dir = Vector3.down;
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);

        
    }
}
