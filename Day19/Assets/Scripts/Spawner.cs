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
        StartCoroutine("SpawnMonsterPooling");
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
            var go = BaseManager.POOL.PoolObject("Monster").GetGameObject((result) =>
            {
               result.GetComponent<Monster>().MonsterSample();
                result.transform.position = pos;
                result.transform.LookAt(Vector3.zero);
            }); 
            StartCoroutine(ReturnMonsterPooling(go));
        }
       


        yield return new WaitForSeconds(monsterSpawnTime);
        StartCoroutine("SpawnMonsterPooling");
    }

    IEnumerator ReturnMonsterPooling(GameObject ob) {
        yield return new WaitForSeconds(1.0f);
        BaseManager.POOL.poolDicionary["Monster"].ObjectReturn(ob);
    }


}
