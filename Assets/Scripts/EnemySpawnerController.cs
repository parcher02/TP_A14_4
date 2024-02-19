using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField]  private GameObject enemyType;
    private Transform lane1, lane2, lane3;
    private GameObject enemy;
    private StandardEnemy enemyCanvas;
    public Boolean waveComplete;
    private Canvas canvas;
    private int rng;
    private int timeBetweenSpawn = 3;
        private int numberOfEnemies = 10;
    private Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        lane1 = GameObject.Find("EnemyLane1").GetComponent<Transform>();
        lane2 = GameObject.Find("EnemyLane2").GetComponent<Transform>();
        lane3 = GameObject.Find("EnemyLane3").GetComponent<Transform>();
        if (waveComplete == false) { 
        
                StartCoroutine(createEnemy());
            }
        
    }
    private IEnumerator createEnemy()
        {
        for (int i = 1; i < numberOfEnemies; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            enemy = Instantiate(enemyType, gameObject.transform);
            enemyCanvas = enemy.GetComponent<StandardEnemy>();
            enemy.transform.SetParent(canvas.transform, false);
            enemyCanvas.canvas = canvas;
            rngSelector();
            enemy.transform.position = location;       
        }
    }
    private void rngSelector()
    {
        rng = UnityEngine.Random.Range(1, 4);
        if(rng == 1) { 
        location = lane1.transform.position;
        }else if(rng == 2)
        {
            location = lane2.transform.position;
        }
        else if(rng == 3)
        {
            location = lane3.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
