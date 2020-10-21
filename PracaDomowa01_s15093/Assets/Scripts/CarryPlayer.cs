using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryPlayer : MonoBehaviour
{

    public List<Rigidbody2D> rigidbodies = new List<Rigidbody2D>();
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Add(rb);
        }
    }

    void OnCollisionExit(Collision col)
    {

        Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Remove(rb);
        }
    }

    void Add(Rigidbody2D rb)
    {
        if (!rigidbodies.Contains(rb))
        {
            rigidbodies.Add(rb);
        }
    }

    void Remove(Rigidbody2D rb)
    {
        if (rigidbodies.Contains(rb))
        {
            rigidbodies.Remove(rb);
        }
    }
}
