using UnityEngine;
using System.Collections.Generic;
using System;


//Ǯ�� ���� �۾� �� �ʿ��� �������� �����ϰ� �ִ� �������̽�
public interface IPool
{
    Transform parent { get; set; }

    Queue<GameObject> pool { get; set; }

    GameObject GetGameObject(Action<GameObject> action = null);

    void ObjectReturn(GameObject gameObject, Action<GameObject> action = null);


}

public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue();

        obj.SetActive(true);
    }

    public void ObjectReturn(GameObject gameObject, Action<GameObject> action = null)
    {
        throw new NotImplementedException();
    }
}

public class PoolManager : MonoBehaviour
{
    public Dictionary<string, IPool> poolDicionary = new Dictionary<string, IPool>();

    public IPool PoolObject(string path)
    {
        //�ش� Ű�� ���ٸ� �߰�
        if (poolDicionary.ContainsKey(path) == false)
        {
            Add(path);
        }
        //��ųʸ���[Ű] = ��
        return poolDicionary[path];
    }

    public GameObject Add(string path)
    {
        //���޹��� �̸����� Ǯ ������Ʈ ����
        var obj = new GameObject(path + "Pool");

        //������Ʈ Ǯ ����
        ObjectPool objectPool = new ObjectPool();

        //��ο� ������Ʈ Ǯ�� ��ųʸ��� ����
        poolDicionary.Add(path, objectPool);

        //Ʈ������ ���� 
        objectPool.parent = obj.transform;

        return obj;

    }

}
