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
        enemySpawner = GameObject.Find("enemySpawner").GetComponent<EnemySpawnerController>();
        rb = this.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        x = transform.position.x;        
        tower = GameObject.Find("Tower").GetComponent<TowerHealth>();
        currency = GameObject.Find("Tower").GetComponent<PlayerCurrency>();
    }
    private void FixedUpdate()
    {
        
        //Moves enemy from the right to the left
        Vector2 direction = new Vector2(-1,0);
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        //If it collides with the tower it will destroy the enemy game object and damage the tower
        if (collidedWithTower && attack)
        {
            enemySpawner.enemyCount -= 1;
            Destroy(gameObject);
            tower.health -= damage;
        }
        if (health <= 0)
        {
            //If the enemies health goes below zero it destroy the enemy and give the player currency
            currency.addBricks(worth);
            enemySpawner.enemyCount -= 1;
            Destroy(gameObject);
        }
       

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Upon collision with a unit it will activate the attack animation and keep attacking until it dies or the unit dies
        if (collision.gameObject.tag == "Unit")
        {
            unit = collision.gameObject;
            Debug.Log("Collided");
            collided = true;
            animator.SetTrigger("Attack");
            attackCollider.GetComponent<EnemyAttack>().damage = damage; //Sends the damage it will cause to the collider
            attackCollider.GetComponent<EnemyAttack>().unit = unit; //Tells the collider which unit it needs to attack
            if (attack)
            {
                attackCollider.SetActive(true);             
            }
            else
            {
                attackCollider.SetActive(false);
            }
            if (unit.GetComponent<StandardPiece>().health <= 0)
            {
               //Once the units health goes below zero it will set the enemies animation to idle and destroy that unit
                animator.SetTrigger("Idle");
                Destroy(unit);

            }
          

        }
        //If the enemy collides with the tower it will attack once
        if(collision.gameObject.tag == "Defence")
        {
            collidedWithTower = true;
            animator.SetTrigger("Attack");
           
          
          
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Upon no longer attacking it will state in the debug that it is no longer colliding with a unit
        if (collision.gameObject.tag == "Unit")
            {
             Debug.Log("No Longer Collided");
             collided = false;
            }
    }
}
