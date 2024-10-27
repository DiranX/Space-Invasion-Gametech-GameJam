using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed;
    public int health;
    public bool asteroid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0, -1 * speed * Time.deltaTime);

        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if(transform.position.z < -20)
        {
            Destroy(gameObject);
        }

        if(asteroid == true)
        {
            transform.Rotate(0,0,2);
        }
    }

    public void EnemyHealth(int damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Skill>().PlayerHealth(25);
        }

        if (other.gameObject.CompareTag("Shield"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<Shield>().Usage -= 1;
        }
    }
}
