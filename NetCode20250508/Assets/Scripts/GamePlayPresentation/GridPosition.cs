using UnityEngine;

//���콺 ��ư�� ����Ƽ ���ø����̼ǿ� �����Ѵ�.
public class GridPosition : MonoBehaviour
{
    [SerializeField] private int _x;
    [SerializeField] private int _y;

    private void OnMouseDown()
    {
        GameManager.Instance.ProcessInput(_x, _y);
    }
}
