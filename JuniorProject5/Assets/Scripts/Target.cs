using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    #region All Components
    private Rigidbody targetRb;
    private GameManager gameManager;
    #endregion

    #region Spawn Settings
    private float minSpeed = 12.0f;
    private float maxSpeed = 17.0f;
    private float maxTorque = 13.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -6.0f;
    private float randForce;
    #endregion 

    [SerializeField] private int pointValue;
    [SerializeField] private ParticleSystem explosionPartical;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        // randomize our values
        randForce = Random.Range(minSpeed, maxSpeed);
        // set physics / toss
        targetRb.AddForce(Vector3.up * randForce, ForceMode.Impulse);
        targetRb.AddTorque(RandTorque(), RandTorque(), RandTorque(), ForceMode.Impulse);
        transform.position = RandSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnMouseDown()
    {
        if (gameManager.isGame)
        {
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionPartical, transform.position, explosionPartical.transform.rotation);
            Destroy(gameObject);

            if (gameObject.CompareTag("Bad"))
            {
                gameManager.GameOver();
            }
        }
        
    }

    private float RandTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandSpawnPos() 
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Sensor"))
        {
            Destroy(gameObject);
        }
    }
}
