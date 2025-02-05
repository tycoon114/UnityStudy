using TMPro;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    //오브젝트 생성 스크립트
    // 마우스 클릭시 카메라의 스크린 지점을 통해 물체의 방향 설정
    //물체를 방향에 맞춰 발사하는 기능 호출

    public GameObject prefab;
    public float power = 1000.0f;
    GameObject scoreText; // 점수 
    public int score = 0;


    /// <summary>
    /// 점수 획득
    /// </summary>
    /// <param name="value"> 수치 </param>
    /// 
    private void Start()
    {

        scoreText = GameObject.Find("Score");

    }
    public void ScorePlus(int value)
    {
        score += value;
        SetScoreText();
    }

    void SetScoreText() {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"점수 : {score}";
    }

    void Update()
    {

        //마우스 0번 버튼 클릭 시, 0 ->왼쪽, 1 -> 오른쪽, 2 -> 휠
        if (Input.GetMouseButtonDown(0))
        {
            var thrown = Instantiate(prefab, transform.position, Quaternion.identity);

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray 가상의 레이저 포인트, 발사되는 시작 지점과 방향을 가지고 있다
            // 일반적으로는 벡터3의값, 2d는 벡터2

            //Vector3 origin = new Vector3(0, 0, 0);
            //Vector3 vecDirect = Vector3.forward;
            //Ray newRay = new Ray(origin,vecDirect);

            //ray는 데이터만 가지고있는 구조체, 기능적으로는 할수 있는것이 없다
            //Ray 를 이용한 방향 계산이나 레이케스트를 이용한 오브젝트 충돌 기능으로 홣용

            Vector3 direction = ray.direction;

            thrown.GetComponent<ObjectShooter>().Shoot(direction.normalized * power);
        }

    }
}
