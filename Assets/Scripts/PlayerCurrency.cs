using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCurrency : MonoBehaviour
{
    public int bricks; //In-game currency
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {//Starts the player off with 100 bricks
        bricks += 100;
        text = GameObject.Find("Currency").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        viewBricks();
    }
    public void addBricks(int newBricks)
    {//Adds bricks when a wave is over or an enemy has been killed
        bricks += newBricks;
    }
    public void removeBricks(int bricks)
    {//Removes bricks when a unit is bought
        this.bricks -= bricks;
    }
    private void viewBricks()
    {//Updates the numbers bricks a player has once per frame
        text.text = "Bricks: " + bricks;
    }
}
