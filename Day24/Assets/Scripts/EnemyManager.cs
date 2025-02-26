using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    float currentTime;
    public float createTime = 1.0f;

    public GameObject enemyFactory;
    float min = 1, max = 5;

    private void Start()
    {
        createTime = Random.Range(min, max);
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= createTime) {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = transform.position;

            currentTime = 0;
            createTime = Random.Range(min, max);
        }

    }


}


