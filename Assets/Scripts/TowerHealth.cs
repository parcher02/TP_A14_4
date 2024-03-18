using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour
{
    public int health = 100;
    //TextMeshProUGUI text;
    Canvas canvas;
    public Slider slider;
   public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Player&EnemyUI").GetComponent<Canvas>();
        //text = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        //text.text = "Health: " + health + "/100";
        if (health <=0)
       {
          gameover.SetActive(true);
       }
    }
   


}
