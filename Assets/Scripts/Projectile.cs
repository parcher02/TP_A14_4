using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]  public Boolean isDemolitionist;
    public float speed;
    public float lifeTime;
    public float distance;
    [HideInInspector] public int damage;
    public float timeChange = 0.1f;
    float lastChange = 0;
    private Canvas canvas;
    private StandardEnemy enemy;
    private LayerMask layerMask = 64; // Layer 6 0100 0000
    private GameObject lasttarget;
    public GameObject unit;
    public GameObject target;

    private float unitX, targetX;

    private float dist, nextX;

    private float baseY, height;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Player&EnemyUI").GetComponent<Canvas>();
        //transform.SetParent(canvas.transform, false);
        Invoke("DestroyProjectile", lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        lastChange += Time.deltaTime;
        try
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, layerMask);  
            //Allows the projectile to move and if it collides with an enemy it will take damage away from the enemy
            if (hitInfo && isDemolitionist == false)
            {
                
               enemy = hitInfo.collider.GetComponent<StandardEnemy>();
              //  Debug.Log(Vector2.Distance(enemy.transform.position, transform.position));
                if (Vector2.Distance(enemy.transform.position, transform.position) < 50)
                {
                    Debug.Log("enemy hit!");
                    enemy.health -= damage;
                    DestroyProjectile();
                }
                    
            }else if(hitInfo && isDemolitionist)
            {
              //  if (Vector2.Distance(enemy.transform.position, transform.position) < 10)
              //  {
                    Debug.Log("grenade landed!");
                    gameObject.GetComponent<CircleCollider2D>().enabled = true;
             //   }             
            }
            if (isDemolitionist)
            {
                unitX = unit.transform.position.x;
                try
                {
                    targetX = target.transform.position.x;
                    dist = targetX - unitX;
                    nextX = Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime);
                    baseY = Mathf.Lerp(unit.transform.position.y, target.transform.position.y, (nextX - unitX) / dist);
                    height = -50 * (nextX - unitX) * (nextX - targetX) / (0.25f * dist * dist);

                    Vector3 movePosition = new Vector3(nextX, baseY + height, unit.transform.position.z);
                    transform.position = movePosition;
                }
                catch (MissingReferenceException)
                {
                    DestroyProjectile();
                }
                catch(UnassignedReferenceException)
                {
                    DestroyProjectile();
                }
                
               
            }
            else{
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            
            
        }
        catch (NullReferenceException)
        {
        }
    }
    void DestroyProjectile()
    {
        //Destroys the projectile
        Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("Grenade Hit!");
            enemy = collision.gameObject.GetComponent<StandardEnemy>();
            enemy.health -= damage;
            try
            {
                DestroyProjectile();
            }catch (Exception)
            {
                Debug.Log("Error!");
            }
        }
    }
    }
