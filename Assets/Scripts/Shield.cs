using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int Usage;
    Collider parentCollider;

    private void Start()
    {
        parentCollider = GetComponentInParent<CapsuleCollider>();
    }

    public void Update()
    {
        parentCollider.enabled = false;
        if(Usage <= 0)
        {
            Usage = 3;
            gameObject.SetActive(false);
        }
    }
}
