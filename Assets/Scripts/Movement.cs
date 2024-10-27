using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    float HorizontalMove;
    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >=2)
        {
            transform.position = new Vector3(2, transform.position.y, transform.position.z);
        }else if(transform.position.x <= -2)
        {
            transform.position = new Vector3(-2, transform.position.y, transform.position.z);
        }

        HorizontalMove = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(HorizontalMove * speed, 0, 0);

        transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -HorizontalMove * 20 );
    }
}
