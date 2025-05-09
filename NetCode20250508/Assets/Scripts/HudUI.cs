using System;
using UnityEngine;

public class HudUI : MonoBehaviour
{

    [SerializeField] private GameObject _circleArrow;
    [SerializeField] private GameObject _crossArrow;
    void Start()
    {
        _circleArrow.SetActive(false);
        _crossArrow.SetActive(true);

        GameManager.Instance.OnTurnChanged += ChangeArrow;
    }
    private void ChangeArrow(SquareState currentTurn)
    {
        switch (currentTurn)
        {
            case SquareState.None:
                _crossArrow.SetActive(false);
                _circleArrow.SetActive(false);
                break;
            case SquareState.Cross:
                _crossArrow.SetActive(true);
                _circleArrow.SetActive(false);
                break;
            case SquareState.Circle:
                _crossArrow.SetActive(false);
                _circleArrow.SetActive(true);
                break;

            default:
                throw new ArgumentOutOfRangeException($"{(int)currentTurn}");
        }
    }
}
