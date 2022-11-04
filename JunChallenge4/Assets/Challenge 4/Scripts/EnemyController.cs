using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody enemyRb;
    private GameObject playerGoal;
    private float speedEnemy = 4.0f;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Enemy Goal");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speedEnemy);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
