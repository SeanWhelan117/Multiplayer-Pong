using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float velocity = 5.0f;
    public float randStartY;

    // Start is called before the first frame update
    void Start()
    {
        randStartY = Random.Range(-5, 5);
        transform.position = new Vector3(0.0f, randStartY, 0.0f);


        Rigidbody2D ballRB = GetComponent<Rigidbody2D>();
        Vector3 initialDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        ballRB.AddForce(initialDirection * velocity, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
