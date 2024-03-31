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
    [SerializeField] private int damage;
    private float x;
    public Canvas canvas;
    public int health;
    Animator animator;
    public Boolean attack;
    [SerializeField] GameObject unit;
    [SerializeField] private Boolean collidedWithTower;
    PlayerCurrency currency;
    TowerHealth tower;
    EnemySpawnerController enemySpawner;
    public int worth;
    public GameObject attackCollider;
    [HideInInspector] public Boolean repeatAnimation;
    // Start is called before the first frame update
    void Start()
    {
        //attackCollider = transform.GetChild(0).GetComponent<Transform>();
        enemySpawner = GameObject.Find("enemySpawner").GetComponent<EnemySpawnerController>();
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        x = transform.position.x;        
        tower = GameObject.Find("Tower").GetComponent<TowerHealth>();
        currency = GameObject.Find("Tower").GetComponent<PlayerCurrency>();
    }
    private void FixedUpdate()
    {
        
        
        Vector2 direction = new Vector2(-1,0);
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
            if (collided == false)
        {        
            animator.SetBool("Collided", false);
        }
        else
        {
            //if (attack)
            //{

            //    unit.GetComponent<StandardPiece>().damageUnit(damage);

            //    if (unit.GetComponent<StandardPiece>().health <= 0)
            //    {
            //        Debug.Log(unit.GetComponent<StandardPiece>().health);
            //        animator.SetTrigger("Idle");
            //        Destroy(unit);
            //    }


            //}
        
        }
        if (collidedWithTower && attack)
        {
            enemySpawner.enemyCount -= 1;
            Destroy(gameObject);
            tower.health -= damage;
        }
        if (health <= 0)
        {
            currency.addBricks(worth);
            enemySpawner.enemyCount -= 1;
            Destroy(gameObject);
        }
       

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            unit = collision.gameObject;
            Debug.Log("Collided");
            collided = true;
            animator.SetTrigger("Attack");
            attackCollider.GetComponent<EnemyAttack>().damage = damage;
            attackCollider.GetComponent<EnemyAttack>().unit = unit;
            if (attack)
            {
                attackCollider.SetActive(true);
              
                // unit.GetComponent<StandardPiece>().damageUnit(damage);




            }
            else
            {
                attackCollider.SetActive(false);
            }
            if (unit.GetComponent<StandardPiece>().health <= 0)
            {
                Debug.Log(unit.GetComponent<StandardPiece>().health);
                animator.SetTrigger("Idle");

                Destroy(unit);

            }
          

        }
        if(collision.gameObject.tag == "Defence")
        {
            collidedWithTower = true;
            animator.SetTrigger("Attack");
           
          
          
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
    public void attackUnit()
    {
        unit.GetComponent<StandardPiece>().damageUnit(damage);

        if (unit.GetComponent<StandardPiece>().health <= 0)
        {
            Debug.Log(unit.GetComponent<StandardPiece>().health);
            animator.SetTrigger("Idle");
            Destroy(unit);
        }
    }
}
