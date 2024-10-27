using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modifikator : MonoBehaviour
{
    public int ID;
    public float speed;
    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        ID = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, -1 * speed * Time.deltaTime);
        star.transform.Rotate(0, 0, 1);

        if (transform.position.z < -20)
        {
            Destroy(gameObject);
        }
    }
}
