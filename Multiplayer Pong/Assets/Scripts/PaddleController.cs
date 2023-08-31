using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float paddleSpeed = 5.0f;
    public float boundaryY = 6.0f;

    public int paddle = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the left paddle
        if(paddle == 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                MovePaddle(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MovePaddle(Vector3.down);
            }
        }


        // Move the right paddle
        if (paddle == 1)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MovePaddle(Vector3.up);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                MovePaddle(Vector3.down);
            }
        }
    }
   
    void MovePaddle(Vector3 direction)
    {
        // newPos
        Vector3 newPosition = transform.position + direction * paddleSpeed * Time.deltaTime;

        // Stay in area
        newPosition.y = Mathf.Clamp(newPosition.y, -boundaryY, boundaryY);

        // ApplynewPos
        transform.position = newPosition;
    }
}
