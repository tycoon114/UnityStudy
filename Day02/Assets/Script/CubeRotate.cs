using UnityEngine;
/// <summary>
/// ť�� ȸ��
/// </summary>
public class CubeRotate : MonoBehaviour
{

    #region test
    //asd
    //ads
    //ad/asd

    //
    //

    #endregion
    #region ����
    public float x;
    public float y;
    private float z;
    #endregion


    #region �Լ�
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        z = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x * Time.deltaTime, y, z));

    }
    #endregion
}
