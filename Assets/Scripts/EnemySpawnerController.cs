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
    [SerializeField]private Boolean startOfRound = true;
    private int rng;
    private int timeBetweenSpawn = 2;
   [SerializeField] private float timeCounter;
    private int numberOfEnemies = 10;
    public List<GameObject> eneimes = new List<GameObject>();
    public List<GameObject> usableEneimes = new List<GameObject>();
    [SerializeField] private List<GameObject> unusedEneimes = new List<GameObject>();
    private Vector3 location;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        lane1 = GameObject.Find("EnemyLane1").GetComponent<Transform>();
        lane2 = GameObject.Find("EnemyLane2").GetComponent<Transform>();
        lane3 = GameObject.Find("EnemyLane3").GetComponent<Transform>();
        EnemySelector();
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
            int random = UnityEngine.Random.Range(0, usableEneimes.Count);
            Debug.Log(random);
            eneimes.Add(usableEneimes[random]);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(timeCounter > 0)
        {
            timeCounter -= Time.deltaTime;

        }
        else
        {
            timeCounter = timeBetweenSpawn;
            if(eneimes.Count > 0)
            {
            
                try
                {
                    enemy = Instantiate(eneimes[0], gameObject.transform);
                    eneimes.Remove(eneimes[0]);
                    startOfRound = false;
                    enemyCanvas = enemy.GetComponent<StandardEnemy>();
                    enemy.transform.SetParent(canvas.transform, false);
                    enemyCanvas.canvas = canvas;
                    rngSelector();
                    enemy.transform.position = location;
                    counter++;
                }
                catch (Exception)
                {

                }
                   
            
            }
        }
        if(GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && startOfRound == false && eneimes.Count == 0)
        {
            waveComplete = true;
        }
            if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0 && waveComplete == true)
        {                
            float wave = waveNumber % 3;
            Debug.Log("Wave Value: " + wave);
            if (wave == 0)
            {
                usableEneimes.Add(unusedEneimes[0]);
                unusedEneimes.Remove(unusedEneimes[0]);
            }
            waveComplete = false;
            startOfRound = true;
            numberOfEnemies += 2;
            waveNumber++;
        EnemySelector();
        }
    }
}
