using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalInput;
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float xRange = 10.0f;
    [SerializeField] private GameObject pizzaPrefab;
    [SerializeField] private Transform parentPizza;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject obj = Instantiate(pizzaPrefab, transform.position, Quaternion.identity, parentPizza);
            Destroy(obj, 3.0f);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Game Over");
    }
}
