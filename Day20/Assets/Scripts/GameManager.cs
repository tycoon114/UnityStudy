using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject mainImage;
    public Sprite gameOverSprite;
    public Sprite gameClearSprite;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image image;

    //TimeController - �ð� ����
    public GameObject timeBar;
    public GameObject timeText;
    TimeController timeController;

    void Start()
    {

        timeController = GetComponent<TimeController>();

        if (timeController != null) {
            if (timeController.gameTime == 0.0f){ 
                timeBar.SetActive(false);
            }
        }

        //1�� �ڿ� �ش� �Լ��� ȣ��
        Invoke("InactiveImage", 1.0f);

        panel.SetActive(false);
    }

    void InactiveImage() { 
        mainImage.SetActive(false);
    }

    void Update()
    {
        if (PlayerController.state == "gameclear")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            restartButton.GetComponent<Button>().interactable = false;
            mainImage.GetComponent<Image>().sprite = gameClearSprite;

            PlayerController.state = "end";

            if (timeController != null) { 
                timeController.isTimeOver = true;
            }

        }
        else if (PlayerController.state == "gameover")
        {
            mainImage.SetActive(true);
            panel.SetActive(true);

            nextButton.GetComponent<Button>().interactable = false;
            mainImage.GetComponent<Image>().sprite = gameOverSprite;

            PlayerController.state = "end";

            if (timeController != null)
            {
                timeController.isTimeOver = true;
            }

        }
        else if (PlayerController.state == "playing")
        {
            //���� ���� �� �߰� ó���� �����Ҷ� ���

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            PlayerController playerController = player.GetComponent<PlayerController>();

            if (timeController != null) {
                if (timeController.gameTime > 0.0f) {
                    // ������ ǥ���ϵ��� ����
                    int time = (int)timeController.displayTime;
                    //�ð� ����
                    timeText.GetComponent<Text>().text =time.ToString();

                    if (time == 0) {
                        playerController.GameOver();
                    }

                }
            }


        }


    }
}
