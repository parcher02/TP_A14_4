using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    Rigidbody2D rb;
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
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        x = transform.position.x;        
    }
    private void FixedUpdate()
    {
        
        
        Vector2 direction = new Vector2(-1,0);
        rb.MovePosition((Vector2)transform.position + direction);
    }
    // Update is called once per frame
    void Update()
    {
        if (collided == false)
        {
            //transform.position = new Vector3(x, transform.position.y, transform.position.z);
            //x -= speed;
            animator.SetBool("Collided", false);
        }
        else
        {
            if (attack)
            {
                Destroy(unit);
               // animator.PlayInFixedTime("blobAttack", 0, 9.0f);
               // animator.SetBool("Collided", false);
                animator.SetTrigger("Idle");
            }
        }
        if(health <= 0)
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
          //  animator.PlayInFixedTime("blobMove", 0,9.0f);
            animator.SetTrigger("Attack");
          //  animator.SetBool("Collided", true);
           
        }
        if(collision.gameObject.tag == "Defence")
        {
            Destroy(gameObject);
            TowerHealth tower = collision.gameObject.GetComponent<TowerHealth>();
            tower.health -= 10;
          
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
