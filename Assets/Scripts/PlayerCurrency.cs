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
    {
        bricks += 100;
        text = GameObject.Find("Currency").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        viewBricks();
    }
    public void addBricks(int newBricks)
    {
        bricks += newBricks;
    }
    public void removeBricks(int bricks)
    {
        this.bricks -= bricks;
    }
    private void viewBricks()
    {
        text.text = "Bricks: " + bricks;
    }
}
