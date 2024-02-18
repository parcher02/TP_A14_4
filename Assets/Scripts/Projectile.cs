using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public float timeChange = 0.1f;
    float lastChange = 0;
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        transform.SetParent(canvas.transform, false);
        Invoke("DestroyProjectile", lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        lastChange += Time.deltaTime;
        try
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance);
            //Allows the projectile to move and if it collides with an enemy it will take damage away from the enemy 
            //if (hitInfo.collider.CompareTag("Enemy"))
            //{

            //    enemy = hitInfo.collider.gameObject.GetComponent<Enemy>();
            //    enemySprite = hitInfo.collider.gameObject.GetComponent<SpriteRenderer>();
            //    if (Vector2.Distance(enemy.transform.position, transform.position) < 1)
            //    {
            //        enemy.health -= damage;
            //        Debug.Log(enemy.health);
            //        DestroyProjectile();
            //    }
            //}
            transform.Translate(Vector2.left * speed * Time.deltaTime);
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
}
