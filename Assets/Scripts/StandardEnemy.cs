using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    public Boolean collided;
    [SerializeField] private float speed;
    private float x;
    public Canvas canvas;
    public int health;
    Animator animator;
    public Boolean attack;
    GameObject unit;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        x = transform.position.x;        
    }

    // Update is called once per frame
    void Update()
    {
        if (collided == false)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            x -= speed;
            animator.SetBool("Collided", false);
        }
        else
        {
            if (attack)
            {
                Destroy(unit);
            }
        }
        if(transform.position.x <= 90 || health <= 0)
        {
            Destroy(gameObject);
        }
     

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            unit = collision.gameObject;
            Debug.Log("Collided");
            collided = true;
            animator.SetBool("Collided", true);
           
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
