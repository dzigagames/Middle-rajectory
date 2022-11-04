using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [Header("Speed Controller")]
    [Space(6)]
    [SerializeField] float speedObstacle = 20.0f;
    private PlayerController playerControllerScript; // referance to PLayerController
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speedObstacle);
        }
        
    }
}
