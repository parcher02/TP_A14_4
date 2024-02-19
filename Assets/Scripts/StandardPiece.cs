using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
//https://www.youtube.com/watch?v=BGr-7GZJNXg
public class StandardPiece : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler,IDragHandler
{
    public Boolean placed;
    [SerializeField] public Canvas canvas;
    [SerializeField] private int health;
    public Boolean clicked;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private float timeBetweenShot;
    public float startTimeBetweenShot;
    public GameObject projectile;
    private Transform shotPoint;
    public float offset;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        shotPoint = transform.GetChild(0).GetComponent<Transform>();
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
            if (timeBetweenShot <= 0)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBetweenShot = startTimeBetweenShot;
            }
            else
            {
                timeBetweenShot -= Time.deltaTime;
            }
        }
    }

}
