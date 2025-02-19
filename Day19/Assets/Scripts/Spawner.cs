using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    public int monsterCount;
    public float monsterSpawnTime;
    public float summonRate = 5.0f; //�ش� ��ġ�� ������ ��� �����Ǵ� ���� (��)�� ��ġ���� �о�����.
    public float reRate = 2.0f;     //���� ��ġ�� �������� �����Ǵ� ������ ������ �� �ִ�.

    void Start()
    {
        StartCoroutine("SpawnMonster");
    }

    //action �׽�Ʈ
    void MonsterSample() {
        Debug.Log("����");
    }

    //�Ϲ����� ���� ���
    IEnumerator SpawnMonster()
    {

        Vector3 pos;

        for (int i = 0; i < monsterCount; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summonRate;
            pos.y = 0.0f;

            //������ �ʹ� �����ٸ�? ���Ҵ�
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

    //������Ʈ Ǯ�� ������� ����
    IEnumerator SpawnMonsterPooling()
    {

        Vector3 pos;

        for (int i = 0; i < monsterCount; i++)
        {
            pos = Vector3.zero + Random.insideUnitSphere * summonRate;
            pos.y = 0.0f;

            //������ �ʹ� �����ٸ�? ���Ҵ�
            while (Vector3.Distance(pos, Vector3.zero) <= reRate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summonRate;
                pos.y = 0.0f;
            }

            //������Ʈ ���� ���� ������Ʈ�� Ǯ�� ������� ��ȯ
            var go = BaseManager.POOL.PoolObject("Slime").GetGameObject();
        }
        yield return new WaitForSeconds(monsterSpawnTime);
        StartCoroutine("SpawnMonster");
    }


}
