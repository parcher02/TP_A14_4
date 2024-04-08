using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject SpawnerType;
    private GameObject solider;
    private StandardPiece hasSoliderPlaced;
    private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Player&EnemyUI").GetComponent<Canvas>();
        createPiece();
    }

    // Update is called once per frame
    void Update()
    {//If a unit has been placed a new unit will be spawned in its place
        if (solider != null && hasSoliderPlaced.placed == true || hasSoliderPlaced.notPlaced == true)
        {
           createPiece();
        }

    }
    private void createPiece()
    {//Spawns the units with the required data needed to function
        solider = Instantiate(SpawnerType, gameObject.transform);
        hasSoliderPlaced = solider.GetComponent<StandardPiece>();
        solider.transform.SetParent(canvas.transform, false);
        hasSoliderPlaced.canvas = canvas;
        solider.transform.position = gameObject.transform.position;

    }
}
