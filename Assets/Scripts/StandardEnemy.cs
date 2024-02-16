using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    public Boolean collided;
    private float x;
    public Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (collided == false)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            x -= 1;
        }
        if(transform.position.x <= 90)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            Debug.Log("Collided");
            collided = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            Debug.Log("No Longer Collided");
            collided = false;
        }
    }
}
