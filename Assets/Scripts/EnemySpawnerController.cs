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
    public int waveNumber;
    private Canvas canvas;
    private int rng;
    private int timeBetweenSpawn = 3;
    private int numberOfEnemies = 10;
    public List<string> eneimes = new List<string>();
    public List<string> usableEneimes = new List<string>();
    [SerializeField] private List<string> unusedEneimes = new List<string>();
    private Vector3 location;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        lane1 = GameObject.Find("EnemyLane1").GetComponent<Transform>();
        lane2 = GameObject.Find("EnemyLane2").GetComponent<Transform>();
        lane3 = GameObject.Find("EnemyLane3").GetComponent<Transform>();
        while(waveNumber <= 50)
        {
            if (waveComplete == false && GameObject.FindGameObjectsWithTag("Enemy").Length >= 0)
            {

                StartCoroutine(createEnemy());
            }
            if (waveComplete == true)
            {
                waveComplete = false;
                numberOfEnemies += 2;
                waveNumber++;
            }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                waveComplete = true;
            }
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
    private void EnemySelector()
    {
        for(int i = 0; i < numberOfEnemies;i++)
        {
            int random = UnityEngine.Random.Range(1, usableEneimes.Capacity + 1);
            eneimes.Add(usableEneimes[random]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
