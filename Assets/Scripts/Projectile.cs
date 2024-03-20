using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    [HideInInspector] public int damage;
    public float timeChange = 0.1f;
    float lastChange = 0;
    private Canvas canvas;
    private StandardEnemy enemy;
    private LayerMask layerMask = 64; // Layer 6 0100 0000
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
            if (hitInfo)
            {
                
               enemy = hitInfo.collider.GetComponent<StandardEnemy>();
              //  Debug.Log(Vector2.Distance(enemy.transform.position, transform.position));
                if (Vector2.Distance(enemy.transform.position, transform.position) < 50)
                {
                    Debug.Log("enemy hit!");
                    enemy.health -= damage;
                    DestroyProjectile();
                }
                    
            }
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            
        }
        catch (NullReferenceException)
        {
            Debug.Log(2);
        }
    }
    void DestroyProjectile()
    {
        //Destroys the projectile
        Destroy(gameObject);
    }
}
