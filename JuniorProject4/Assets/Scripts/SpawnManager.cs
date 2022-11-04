using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;

    #region Spawn Position
    private float spawnPositionX;
    private float spawnPositionZ;
    private Vector3 spawnPositionVector;
    private float spawnRange = 9.0f;
    #endregion

    #region Another Variables
    public int enemyCount;
    public int WaveNumber = 1;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab, SetSpawnPosition(), powerupPrefab.transform.rotation);
        SpawnEnemyWave(WaveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            WaveNumber++;
            SpawnEnemyWave(WaveNumber);
            Instantiate(powerupPrefab, SetSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 SetSpawnPosition()
    {
        spawnPositionX = Random.Range(-spawnRange, spawnRange);
        spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        spawnPositionVector = new Vector3(spawnPositionX, 0, spawnPositionZ);
        return spawnPositionVector;
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, SetSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }
}
