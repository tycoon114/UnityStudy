using UnityEngine;


public class GameVisualManager : MonoBehaviour
{
    //인스턴싱을 위한 프리팹이 필요하다.
    [SerializeField] private GameObject[] _markPrefabs;

    private void Start()
    {
        GameManager.Instance.OnBoardChanged += DrawMark;
    }

    private void OnDisable()
    {
        //GameManager.Instance.OnBoardChanged -= DrawMark;
    }


    private void DrawMark(int x, int y, SquareState squareState)
    {
        switch (squareState)
        {
            case SquareState.Circle:
                Instantiate(_markPrefabs[0], GetPosition(x,y), Quaternion.identity);
                break;
            case SquareState.Cross:
                Instantiate(_markPrefabs[1], GetPosition(x, y) , Quaternion.identity);
                break;
            default:
                Logger.Error($"잘못된 입력   {(int)squareState}");
                break;

        }
    }

    private Vector2 GetPosition(int x, int y)
    {

        int worldX = -3 + 3 * x;
        int worldY = 3 - 3 * y;

        return new Vector2(worldX, worldY);

    }


}
