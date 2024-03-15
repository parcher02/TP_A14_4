using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class menu_scripts : MonoBehaviour
{

    public AudioMixer mixer;

    public void playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//when adding this to the main game insure that the game scense is set to 1 on the build settings 
    }

    public void quitactivegame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);//when adding this to the main game insure that the game scense is set to 0 on the build settings 
    }

    public void resetgame()
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void quitgame()
    {
       Application.Quit();
        Debug.Log("quit game");//quits the game 
    }

    public void setmusic (float musicvolume)
    {
        Debug.Log(musicvolume);//checks to see if volume slider has been chainged
        mixer.SetFloat("music", musicvolume);
    }

    public void setSFX(float SFXvolume)
    {
        Debug.Log(SFXvolume);//checks to see if volume slider has been chainged
        mixer.SetFloat("SFX", SFXvolume);
    }

}
