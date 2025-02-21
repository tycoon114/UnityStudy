using System;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float speed = 12.0f;
    public float delay = 0.25f;
    public GameObject bowPrefab;
    public GameObject arrowPrefab;

    bool inAttack = false;
    GameObject bowObject;
    
    
    void Start()
    {
        Vector3 pos = transform.position;
        bowObject = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObject.transform.SetParent(transform);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3")) {
            Attack();
        }

        float bowZ = -1;
        var playerController = GetComponent<PlayerController>();
        if (playerController.z > 30 && playerController.z < 150) {
            bowZ = 1;
        }
        bowObject.transform.rotation = Quaternion.Euler(0,0,playerController.z);
        bowObject.transform.position = new Vector3(transform.position.x,transform.position.y,bowZ);
    }

    private void Attack()
    {
        if (ItemKeeper.hasArrows > 0 && inAttack == false) { 
            ItemKeeper.hasArrows--;
            inAttack = true;

            var playerController = GetComponent<PlayerController> ();

            float z = playerController.z; // È¸Àü°¢

            var rotation = Quaternion.Euler(0, 0, z);

            var arrowObject = Instantiate(arrowPrefab, transform.position, rotation);
            
            float x = Mathf.Cos(z*Mathf.Deg2Rad);
            float y = Mathf.Sin(z*Mathf.Deg2Rad);

            Vector3 vector = new Vector3(x, y) * speed;

            var rBody = arrowObject.GetComponent<Rigidbody2D>();

            rBody.AddForce(vector,ForceMode2D.Impulse);

            Invoke("AttackChange",delay);


        }
    }

    public void AttackChange() => inAttack = false;

}
