using UnityEngine;




public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance 
    {
        get
        {
            //인스턴스가 비어 있다면 
            if (instance == null)
            {
                //게임 씬 내에서 해당 타입을 가지고 있는 오브젝트를 찾는다.
                //(T)인 이유는 해당 데이터의 형태로 변형하기 위함
                instance = FindAnyObjectByType<T>();
                
                //그럼에도 없는 상황이라면/
                if (instance == null) 
                {
                    //새로 오브젝트를 생성
                    var manager = new GameObject(typeof(T).Name);
                    //매니저에 해당 타입을 컴포넌트로써 연결
                    instance = manager.AddComponent<T>();
                }

            }
            return instance;
        }
    }

    //protected 상속 법위까지 적용
    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this) { 
            Destroy(gameObject);
        }

    }

}
