using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int coinCount = 0;

    public TextMeshProUGUI coinText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        coinText.text = coinCount.ToString();
        SoundManager.Instance.PlaySFX(SFXType.SFX_Coin);
        PlayerPrefs.SetInt("Coin", coinCount);
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void ResetCoin()
    {
        coinCount = 0;
        coinText.text = coinCount.ToString();
        PlayerPrefs.SetInt("Coin", coinCount);
    }
}
