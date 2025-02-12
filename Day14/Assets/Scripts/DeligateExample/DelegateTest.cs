using UnityEngine;

public class DelegateTest : MonoBehaviour
{

    Rigidbody rb;

     delegate void TestDelegate();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TestDelegate testDelegate =new TestDelegate(Force);

        testDelegate();
    }


    void Force() {
        Vector3 forceDirection = new Vector3(0, 5, 10);
        rb.AddForce(forceDirection, ForceMode.Impulse);
    }


}
