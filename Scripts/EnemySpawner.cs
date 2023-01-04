using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab1;
    [SerializeField] private GameObject enemyPrefab2;
    [SerializeField] private GameObject enemyPrefab3;
    [SerializeField] private int nEnemiesInWave = 0;
    [SerializeField] private float SpawnEnemyWaitTime = 0.5f;
    [SerializeField] private bool isWaveSpawning = false;
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private float timer = 5f;
    [SerializeField] private Text timerText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text passedText;
    public int x;
    public int level = 0;

    private void Update(){
        timerText.text = "Timer: " + ((int)timer).ToString();
        levelText.text = "Level: " + ((int)level).ToString();
        //passedText.text = "LEVEL PASSED!!!";
        if(timer <= 0){
            StartCoroutine(SpawnWave());
            timer = spawnTimer;
            level++;
            passedText.enabled = true;
            new WaitForSeconds(2f);
            passedText.enabled = false;
        }
        if(!isWaveSpawning)
            //passedText.text = "LEVEL PASSED!!!";
            timer -= Time.deltaTime;
    }

    IEnumerator SpawnWave(){
        isWaveSpawning = true;
        nEnemiesInWave++;
        //if(nEnemiesInWave <= level){
            for (int i = 0; i < nEnemiesInWave; i++){
                x = Random.Range(1, 4);
                if(x == 1)
                    SpawnEnemy1();
                if(x == 2)
                    SpawnEnemy2();
                if(x == 3)
                    SpawnEnemy3();

                //level++;
                // wait for .5 secs
                yield return new WaitForSeconds(SpawnEnemyWaitTime);
            }
        //}
        //level++;
        isWaveSpawning = false;
        //passedText.text = "LEVEL PASSED!!!";
    }

    private void SpawnEnemy1(){
        Instantiate(enemyPrefab1, transform);
    }

    private void SpawnEnemy2(){
        Instantiate(enemyPrefab2, transform);
    }

    private void SpawnEnemy3(){
        Instantiate(enemyPrefab3, transform);
    }
}
