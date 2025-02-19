using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int monsterCount;
    public float monsterSpawnTime;
    public float summonRate = 5.0f; //해당 수치를 수정할 경우 생성되는 영역 (구)의 위치값이 넓어진다.
    public float reRate = 2.0f;     //생성 위치를 기준으로 생성되는 영역을 설정할 수 있다.

    void Start()
    {
        StartCoroutine("SpawnMonster");
    }

    //action 테스트
    void MonsterSample() {
        Debug.Log("생성");
    }

    //일반적인 생성 방법
    IEnumerator SpawnMonster()
    {

        Vector3 pos;

        for (int i = 0; i < monsterCount; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summonRate;
            pos.y = 0.0f;

            //생성시 너무 가깝다면? 재할당
            while (Vector3.Distance(pos, Vector3.zero) <= reRate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summonRate;
                pos.y = 0.0f;
            }


            GameObject go = Instantiate(monsterPrefab, pos, Quaternion.identity);
        }
        yield return new WaitForSeconds(monsterSpawnTime);
        StartCoroutine("SpawnMonster");
    }

    //오브젝트 풀링 기법으로 생성
    IEnumerator SpawnMonsterPooling()
    {

        Vector3 pos;

        for (int i = 0; i < monsterCount; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summonRate;
            pos.y = 0.0f;

            //생성시 너무 가깝다면? 재할당
            while (Vector3.Distance(pos, Vector3.zero) <= reRate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summonRate;
                pos.y = 0.0f;
            }

            //오브젝트 명을 가진 오브젝트를 풀링 기법으로 소환
            var go = BaseManager.POOL.PoolObject("Slime").GetGameObject();
        }
        yield return new WaitForSeconds(monsterSpawnTime);
        StartCoroutine("SpawnMonster");
    }


}
