using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_scripts : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//when adding this to the main game insure that the game scense is set to 1 on the build settings 
    }

    public void quitactivegame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//when adding this to the main game insure that the game scense is set to 0 on the build settings 
    }

    public void quitgame()
    {
       Application.Quit();
        Debug.Log("quit game");//quits the game 
    }
}
