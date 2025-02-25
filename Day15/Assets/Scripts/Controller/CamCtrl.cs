using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

[System.Serializable]
public class SphericalCoordinates
{
    private float radius, azimuth, elevation;

    public float Azimuth
    {
        get { return azimuth; }
        private set
        {
            azimuth = Mathf.Repeat(value, maxAzimuth_Rad - minAzimuth_Rad);
        }
    }

    public float Elevation
    {
        get { return elevation; }
        private set
        {
            elevation = Mathf.Clamp(value, minElevation_Rad, maxElevation_Rad);
        }
    }

    //Azimuth range
    public float minAzimuth_Deg = 0f;
    private float minAzimuth_Rad;

    public float maxAzimuth_Deg = 360f;
    private float maxAzimuth_Rad;

    //Elevation rages
    public float minElevation_Deg = -20f;
    private float minElevation_Rad;

    public float maxElevation_Deg = 40f;
    private float maxElevation_Rad;

    public SphericalCoordinates(Vector3 _camCoordinate, float _radius)
    {
        //������ ���� ��(�ִ�, �ּ�)�� ���Ѵ�.
        minAzimuth_Rad = Mathf.Deg2Rad * minAzimuth_Deg;
        maxAzimuth_Rad = Mathf.Deg2Rad * maxAzimuth_Deg;
        //�Ӱ� ���� ��(�ִ�, �ּ�)�� ���Ѵ�.
        minElevation_Rad = Mathf.Deg2Rad * minElevation_Deg;
        maxElevation_Rad = Mathf.Deg2Rad * maxElevation_Deg;

        radius = _radius;
        //���Լ��� �������� �Ӱ��� ���Ѵ�.
        Azimuth = Mathf.Atan2(_camCoordinate.z, _camCoordinate.x);
        Elevation = Mathf.Asin(_camCoordinate.y / radius);
    }

    public Vector3 toCartesian
    {
        get
        {
            //camera position = (r cos�� cos��, r sin��, r cos�� sin��)
            float t = radius * Mathf.Cos(Elevation);
            return new Vector3(t * Mathf.Cos(Azimuth),
                radius * Mathf.Sin(Elevation), t * Mathf.Sin(Azimuth));
        }
    }

    public SphericalCoordinates Rotate(float newAzimuth, float newElevation)
    {
        Azimuth += newAzimuth;
        Elevation += newElevation;
        return this;
    }
}

public class CamCtrl : MonoBehaviour
{
    private Vector3 lookPosition;
    public Vector3 targetCamPos = new Vector3(0, 0.5f, -4);
    private Camera mainCamera;


    public Transform PlayerTr;
    public SphericalCoordinates sphericalCoordinates;

    void Start()
    {
        //ī�޶� ��ġ ����� ���� x, y, z��ǥ�� ������ r���� �Ѱ��ش�.
        sphericalCoordinates = new SphericalCoordinates(targetCamPos, Mathf.Abs(targetCamPos.z));
        transform.position = sphericalCoordinates.toCartesian + PlayerTr.position;
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * -1;
        float vertical = Input.GetAxis("Mouse Y") * -1;



        //�÷��̾� ��ġ���� ���ݴ� �������� �ڸ���� �����.
        lookPosition = new Vector3(PlayerTr.position.x +0.5f,
        PlayerTr.position.y + targetCamPos.y, PlayerTr.position.z);

        //�÷��̾� �߽����� ���� ������ǥ�� ī�޶� ��ġ�� ����
        transform.position = sphericalCoordinates.Rotate
            (horizontal * Time.deltaTime, vertical * Time.deltaTime).toCartesian + lookPosition;

       // Debug.DrawRay(transform.position, -targetCamPos, Color.red);

        //��ǥ�������� ī�޶� ������
        transform.LookAt(lookPosition);
       
        
        RaycastHit hit;
        Vector3 dir = transform.position - PlayerTr.transform.position;
        Debug.DrawRay(PlayerTr.transform.position, dir.normalized * dir.magnitude, Color.red);


    }
}
