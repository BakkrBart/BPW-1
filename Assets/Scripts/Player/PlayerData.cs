using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int waveNumber;
    public int enemySpawnAmount;

    public PlayerData (Spawner spawner)
    {
        waveNumber = spawner.waveNumber;
        enemySpawnAmount = spawner.enemySpawnAmount;
    }
}
