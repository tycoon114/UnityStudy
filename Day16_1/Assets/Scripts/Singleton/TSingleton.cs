using UnityEngine;




public class TSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance 
    {
        get
        {
            //�ν��Ͻ��� ��� �ִٸ� 
            if (instance == null)
            {
                //���� �� ������ �ش� Ÿ���� ������ �ִ� ������Ʈ�� ã�´�.
                //(T)�� ������ �ش� �������� ���·� �����ϱ� ����
                instance = FindAnyObjectByType<T>();
                
                //�׷����� ���� ��Ȳ�̶��/
                if (instance == null) 
                {
                    //���� ������Ʈ�� ����
                    var manager = new GameObject(typeof(T).Name);
                    //�Ŵ����� �ش� Ÿ���� ������Ʈ�ν� ����
                    instance = manager.AddComponent<T>();
                }

            }
            return instance;
        }
    }

    //protected ��� �������� ����
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
