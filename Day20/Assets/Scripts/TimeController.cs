using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; // true �� ��� ī��Ʈ �ٿ� ����
    public float gameTime = 0;      // ���� ������ ���� ���Ӱ� (�ִ� �ð�)
    public bool isTimeOver = false;     //false �� ��� Ÿ�̸� �۵���
    public float displayTime = 0;  // ȭ�鿡 ǥ���� �ð�

    float times = 0;    //���� �ð�

    void Start()
    {
        //ī��Ʈ �ٿ��� ���� ���̶��, ǥ��� �ð��� ���� �ð����� ����
        if (isCountDown)
        {
            displayTime = gameTime;
        }
    }

    void Update()
    {
        if (isTimeOver == false) {
            times += Time.deltaTime;

            if (isCountDown)
            {
                displayTime = gameTime - times;

                if (displayTime <= 0.0f)
                {
                    displayTime = 0.0f;
                    isTimeOver = true;
                }
            }
            else { 
                displayTime = times;
                if (displayTime >= gameTime) {
                    displayTime = gameTime;
                    isTimeOver=true;
                }
            }
        }
    }
}
