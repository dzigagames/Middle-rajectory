using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Move Controller
    [Header("\tPlayer Movement")]
    [Range(0.0f, 20.0f)]
    [SerializeField] private float speedPlayer = 5.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float horizontalInput;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float verticalInput;
    private GameObject focalPoint;
    #endregion

    #region All Components
    [Header("\tAll elements")]
    [SerializeField] private GameObject powerupIndicator;
    private Rigidbody playerRb;
    public bool hasPowerup = false;
    private float powerUpStrength = 15.0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // get all components
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speedPlayer);
        if (hasPowerup)
        {
            powerupIndicator.transform.position = transform.position + new Vector3(0, -0.7f, 0);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
