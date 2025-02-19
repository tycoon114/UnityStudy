using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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
            //������ �Լ��� ���°��
            //var go = BaseManager.POOL.PoolObject("Monster").GetGameObject();

            //������Ʈ ���� ���� ������Ʈ�� Ǯ�� ������� ��ȯ, ������ �Լ��� �ִ� ���
            var go = BaseManager.POOL.PoolObject("Monster").GetGameObject((x) =>
            {
                x.GetComponent<Monster>().MonsterSample();
            });
        }
        yield return new WaitForSeconds(monsterSpawnTime);
        StartCoroutine("SpawnMonster");
    }


}
