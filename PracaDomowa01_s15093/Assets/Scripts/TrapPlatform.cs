using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            Destroy(gameObject, 1f);
            //Invoke("DropPlatform",0.5f);
        }
    }

    //void DropPlatform()
    //{
    //    rb.isKinematic = false;
    //}
}
