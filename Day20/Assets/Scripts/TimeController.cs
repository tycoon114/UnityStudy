using UnityEngine;

public class TimeController : MonoBehaviour
{
    public bool isCountDown = true; // true 일 경우 카운트 다운 진행
    public float gameTime = 0;      // 실제 진행할 게임 ㅅㅣ간 (최대 시간)
    public bool isTimeOver = false;     //false 일 경우 타이머 작동중
    public float displayTime = 0;  // 화면에 표시할 시간

    float times = 0;    //현재 시간

    void Start()
    {
        //카운트 다운이 진행 중이라면, 표기된 시간을 게임 시간으로 설정
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
