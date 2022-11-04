using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> animalsPrefabes;
    [SerializeField] private Transform parentAnimals;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomAnimal()
    {
        Vector3 spawnVector = new Vector3(Random.Range(-10.0f, 10.0f), transform.position.y, transform.position.z);
        GameObject objAnimal = Instantiate(animalsPrefabes[Random.Range(0, animalsPrefabes.Capacity)], spawnVector, transform.rotation, parentAnimals);
        Destroy(objAnimal, 5.0f);
    } 


} 
