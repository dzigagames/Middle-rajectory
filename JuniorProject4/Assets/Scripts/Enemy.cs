using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region Serializable Fields
    [Header("\tSpeed Controller")]
    [Range(0.0f, 7.0f)]
    [SerializeField] private float speedEnemy = 3.0f;
    #endregion

    #region All Components
    private Rigidbody enemyRb;
    private GameObject player;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speedEnemy);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
