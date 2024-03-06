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
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        createPiece();
    }

    // Update is called once per frame
    void Update()
    {
        if (solider != null && hasSoliderPlaced.placed == true || hasSoliderPlaced.notPlaced == true)
        {
           createPiece();
        }

    }
    private void createPiece()
    {
        solider = Instantiate(SpawnerType, gameObject.transform);
        hasSoliderPlaced = solider.GetComponent<StandardPiece>();
        solider.transform.SetParent(canvas.transform, false);
        hasSoliderPlaced.canvas = canvas;
        solider.transform.position = gameObject.transform.position;

    }
}
