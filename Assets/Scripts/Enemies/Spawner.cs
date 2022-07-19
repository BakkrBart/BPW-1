using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public int waveNumber;
    public int enemySpawnAmount;
    public int enemiesKilled = 0;

    public GameObject[] spawners;
    public GameObject enemy;
    public Text wave;

    private void Start()
    {
        spawners = new GameObject[4];
        
        for(int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }

        StartWave();
    }

    private void Update()
    {
        if(enemiesKilled >= enemySpawnAmount)
        {
            NextWave();
        }
    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    private void StartWave()
    {
        waveNumber = 1;
        wave.text = waveNumber.ToString();
        enemySpawnAmount = 2;
        enemiesKilled = 0;

        for(int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    public void NextWave()
    {
        waveNumber++;
        wave.text = waveNumber.ToString();
        enemySpawnAmount += 2;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmount; i++)
        {
            SpawnEnemy();
        }
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        waveNumber = data.waveNumber;
        enemySpawnAmount = data.enemySpawnAmount;
    }
}
