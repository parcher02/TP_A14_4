using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//https://www.youtube.com/watch?v=BGr-7GZJNXg
public class StandardPiece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,IDragHandler
{
    Rigidbody2D rb;
    public Boolean placed;
    [SerializeField] public Canvas canvas;
    [SerializeField] private int health;
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
    Animator animator;
    public Boolean Shoot;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void FixedUpdate()
    {

     
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        shotPoint = transform.GetChild(0).GetComponent<Transform>();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
      
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
            canvasGroup.blocksRaycasts = false;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (placed == false)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }     
    }
    private void Update()
    {
        if (placed)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
            if (enemyInRange)
            {
                //if (Shoot)
                //{
                    if (timeBetweenShot <= 0)
                    {
                        Bullet = Instantiate(projectile, shotPoint.position, transform.rotation);
                        Bullet.transform.SetParent(canvas.transform, false);
                        Bullet.transform.position = shotPoint.position;
                        timeBetweenShot = startTimeBetweenShot;
                    }
                    else
                    {
                        timeBetweenShot -= Time.deltaTime;
                    }
                //}

            }
        }
        animator.SetBool("Placed", placed);
        animator.SetBool("Attack", enemyInRange);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInRange = true;
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
}
