using UnityEngine;
using System.Collections.Generic;
using System;


//풀에 대한 작업 시 필요한 정보들을 보관하고 있는 인터페이스
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
        if (action != null)
        {
            action?.Invoke(obj);
        }
        return obj;
    }

    public void ObjectReturn(GameObject gameObject, Action<GameObject> action = null)
    {
        pool.Enqueue(gameObject);
        gameObject.transform.parent = parent;
        gameObject.SetActive(false);

        //액션으로 전달받은 값이 있다면?
        if (action != null)
        {
            action?.Invoke(gameObject);
            //전달받은 액션을 실행합니다.
            //?는 null에 대한 설정
        }
    }

}

public class PoolManager
{
    public Dictionary<string, IPool> poolDicionary = new Dictionary<string, IPool>();

    public IPool PoolObject(string path)
    {
        //해당 키가 없다면 추가
        if (!poolDicionary.ContainsKey(path))
        {
            Add(path);
        }

        if (poolDicionary[path].pool.Count <= 0)
        {
            AddQ(path);
        }
        return poolDicionary[path];
    }




    public GameObject Add(string path)
    {
        //전달받은 이름으로 풀 오브젝트 생성
        var obj = new GameObject(path + "Pool");

        //오브젝트 풀 생성
        ObjectPool objectPool = new ObjectPool();

        //경로와 오브젝트 풀을 딕셔너리에 저장
        poolDicionary.Add(path, objectPool);

        //트랜스폼 설정 
        objectPool.parent = obj.transform;

        return obj;

    }

    public void AddQ(string path)
    {
        var go = BaseManager.instance.CreateFormPath(path);
        go.transform.parent = poolDicionary[path].parent;

        poolDicionary[path].ObjectReturn(go);
    }

}
