using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerHealth : MonoBehaviour
{
    public int health = 100;
    TextMeshProUGUI text;
    Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Player&EnemyUI").GetComponent<Canvas>();
        text = GameObject.Find("Health").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Health: " + health + "/100";
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//when adding this to the main game insure that the game scense is set to 0 on the build settings 
        }
    }
}
