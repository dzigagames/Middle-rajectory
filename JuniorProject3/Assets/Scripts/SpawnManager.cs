using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform parentObstacles;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript; // reference
    // Start is called before the first frame update
    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity, parentObstacles);
            Destroy(obstacle, 7.5f);
        }
    }
}
