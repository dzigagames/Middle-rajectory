using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new Vector3(0, 0, 1);
    [SerializeField] private float spinRotateSpeed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        if (Vector3.up == new Vector3(1, 0, 0))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(offset * Time.deltaTime * spinRotateSpeed);
    }
}
