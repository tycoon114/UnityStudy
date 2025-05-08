using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get;
        private set;
    }

    public void ProcessInput(int x, int y)
    {
        Logger.Info($"{x}   and  {y}");
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
    }




}
