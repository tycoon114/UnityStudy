using UnityEngine;
/// <summary>
/// 큐브 회전
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
    #region 변수
    public float x;
    public float y;
    private float z;
    #endregion


    #region 함수
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
