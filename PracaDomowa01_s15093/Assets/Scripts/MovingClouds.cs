using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingClouds : MonoBehaviour
{

    float dirX, speed = 1f;
    bool limitR = true;
    //private Transform startPos, endpos;

    float limit;

    // Start is called before the first frame update

    void Start()
    {
        limit = transform.position.x;
        // nextPos = startPos.position;
        //Debug.Log("pos is " + limit);
    }

    void Update()
    {

        if (transform.position.x < (limit - 100f))
        {
            limitR = true;
        }
        if (transform.position.x > (limit + 100f))
        {
            limitR = false;
        }

        if (limitR)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
}
