using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//https://www.youtube.com/watch?v=BGr-7GZJNXg
public class StandardPiece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,IDragHandler, IPointerClickHandler
{
    Rigidbody2D rb;
    public Boolean placed;
    [SerializeField] private Boolean isDemolitionist;
    public Canvas canvas;
    public int health;
    [SerializeField] private int damage;
    [SerializeField] private Color projectileColour;
    public Boolean clicked;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private float timeBetweenShot;
    public float startTimeBetweenShot;
    public GameObject projectile;
    private GameObject Bullet;
    private Transform shotPoint;
    public float offset;
    [SerializeField] private Boolean enemyInRange;
    private Vector3 originalPosition;
    Animator animator;
    public Boolean Shoot;
    public Boolean notPlaced;
    public PlayerCurrency currency;
    [SerializeField] public int cost;
     public GameObject enemy;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        currency = GameObject.Find("Tower").GetComponent<PlayerCurrency>();
        originalPosition = transform.position;
        animator = GetComponent<Animator>();
        shotPoint = transform.GetChild(0).GetComponent<Transform>();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {  
    }

    public void OnBeginDrag(PointerEventData eventData)
    { //Allows the unit to be dragged

        canvasGroup.blocksRaycasts = false;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    { //Checks to see if when a unit is dropped it is on a slot, if not it deletes the unit
        canvasGroup.blocksRaycasts = true;
        if (placed == false)
        {
            notPlaced = true;
            Destroy(gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {//Changes the position of the selected unit based the pointers coordinates
        if (placed == false && currency.bricks >= cost)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
       
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right && placed == true)
        {//If right click is used on a placed unit, it will delete it and give the player back half of the cost
            Debug.Log("DELETE");
            Destroy(gameObject);
            currency.addBricks(cost / 2);
        }
    }
        private void Update()
    {
        if (placed)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if (enemyInRange) // Checks if an enemy is within range
            {           
                    if (timeBetweenShot <= 0)
                    {// Shoots projectile and provides the object with the required data needed
                        Bullet = Instantiate(projectile, shotPoint.position, transform.rotation);
                        Bullet.GetComponent<Projectile>().damage = damage;
                        Bullet.GetComponent<Image>().color = projectileColour;
                        Bullet.GetComponent<Projectile>().isDemolitionist = isDemolitionist;
                    Bullet.GetComponent<Projectile>().target = enemy;
                    Bullet.GetComponent<Projectile>().unit = gameObject;
                        Bullet.transform.SetParent(canvas.transform, false);
                        Bullet.transform.position = shotPoint.position;
                        timeBetweenShot = startTimeBetweenShot;
                    }
                    else
                    {
                        timeBetweenShot -= Time.deltaTime;
                    }                                              
            }
        }
        animator.SetBool("Placed", placed); //Plays the animation when placed
        animator.SetBool("Attack", enemyInRange); //Plays the animation when attacking
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {//Activates the enemyInRange to allow the unit to shoot
            enemyInRange = true;
            if(enemy == null && placed == true)
            {
                Debug.Log("First enemy found!");
                enemy = collision.gameObject;
            }
            Debug.Log("Enemy in Range!");
        }
        else
        {
            enemyInRange = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemyInRange = false;
    }
    public void damageUnit(int damage)
    {//When the unit is being attacked it take damage
        Debug.Log(health + " " + damage);
        health -= damage;
    }
}
