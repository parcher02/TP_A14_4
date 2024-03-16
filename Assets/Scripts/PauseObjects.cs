using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseObjects : MonoBehaviour
{
    public static Boolean paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            if(gameObject.GetComponent<Button>() == null) {
                gameObject.GetComponent<Image>().enabled = false;
                gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }

        }
        else
        {
            if (gameObject.GetComponent<Button>() == null)
            {
                gameObject.GetComponent<Image>().enabled = true;
                gameObject.GetComponent<Rigidbody2D>().simulated = true;
            }
           
            
        }
    }
    public void buttonPressed()
    {
        paused = true;
    }
    public void backButtonPressed()
    {
        Debug.Log("Back button pressed");
        paused = false;
    }
}
