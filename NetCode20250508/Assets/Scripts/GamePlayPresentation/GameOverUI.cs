using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textUI;
    private void Start()
    {
        GameManager.Instance.OnGameDone += setText;
        gameObject.SetActive(false);
    }

    private void setText(GameOverState state)
    {
        if (state == GameOverState.Tie)
        {
            _textUI.text = "Tie";
        }
        else
        {
            _textUI.text = $"{state}  is Winner";
        }

        gameObject.SetActive(true);
    }
}
