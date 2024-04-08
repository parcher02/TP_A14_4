using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public int health = 100;
    Canvas canvas;
    public Slider slider;
    public GameObject gameover;
    private PauseObjects isGameover;
    // Start is called before the first frame update
    void Start()
    {
        isGameover = GameObject.Find("SettingButton").GetComponent<PauseObjects>();
        canvas = GameObject.Find("Player&EnemyUI").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //Updates the player health bar once per frame
        slider.value = health;
        if (health <=0)
       {
          gameover.SetActive(true); //Once the towers health goes below zero the game over screen is presented
            isGameover.buttonPressed();
       }
    }
   


}
