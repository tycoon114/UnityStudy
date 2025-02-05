using TMPro;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    //������Ʈ ���� ��ũ��Ʈ
    // ���콺 Ŭ���� ī�޶��� ��ũ�� ������ ���� ��ü�� ���� ����
    //��ü�� ���⿡ ���� �߻��ϴ� ��� ȣ��

    public GameObject prefab;
    public float power = 1000.0f;
    GameObject scoreText; // ���� 
    public int score = 0;


    /// <summary>
    /// ���� ȹ��
    /// </summary>
    /// <param name="value"> ��ġ </param>
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
        scoreText.GetComponent<TextMeshProUGUI>().text = $"���� : {score}";
    }

    void Update()
    {

        //���콺 0�� ��ư Ŭ�� ��, 0 ->����, 1 -> ������, 2 -> ��
        if (Input.GetMouseButtonDown(0))
        {
            var thrown = Instantiate(prefab, transform.position, Quaternion.identity);

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray ������ ������ ����Ʈ, �߻�Ǵ� ���� ������ ������ ������ �ִ�
            // �Ϲ������δ� ����3�ǰ�, 2d�� ����2

            //Vector3 origin = new Vector3(0, 0, 0);
            //Vector3 vecDirect = Vector3.forward;
            //Ray newRay = new Ray(origin,vecDirect);

            //ray�� �����͸� �������ִ� ����ü, ��������δ� �Ҽ� �ִ°��� ����
            //Ray �� �̿��� ���� ����̳� �����ɽ�Ʈ�� �̿��� ������Ʈ �浹 ������� �b��

            Vector3 direction = ray.direction;

            thrown.GetComponent<ObjectShooter>().Shoot(direction.normalized * power);
        }

    }
}
