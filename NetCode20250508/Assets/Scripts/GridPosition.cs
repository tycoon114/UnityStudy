using UnityEngine;

//마우스 버튼을 유니티 애플리케이션에 전달한다.
public class GridPosition : MonoBehaviour
{
    [SerializeField] private int _x;
    [SerializeField] private int _y;

    private void OnMouseDown()
    {
        Logger.Info("test1");
        Logger.Warning("test2");
        GameManager.Instance.ProcessInput(_x, _y);
    }
}
